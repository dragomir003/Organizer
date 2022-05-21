using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

namespace Organizer
{
    public partial class Project : Form
    {
        static readonly string korisnik_username = "username";
        static readonly string korisnik_id = "id";
        struct ProjectData
        {
            public int id;
            public string name;
            public string description;
            public DateTime start;
            public DateTime? end;
            public DateTime? expectedEnd;

            public SqlDataAdapter peopleAdapter;
            public DataTable people;

            public ProjectData(SqlConnection conn)
            {
                id = 0;
                name = "";
                description = "";
                start = DateTime.Now;
                end = null;
                expectedEnd = null;

                people = new DataTable();

                peopleAdapter = new SqlDataAdapter($"select Korisnik.id as {korisnik_id}, Korisnik.username as {korisnik_username} from Korisnik;", conn);

                peopleAdapter.Fill(people);
            }

            public ProjectData(SqlConnection conn, int projectId)
            {
                conn.Open();
                var readerBasicData = new SqlCommand($"select * from Projekat where id = {projectId};", conn).ExecuteReader();

                readerBasicData.Read();

                name = readerBasicData["naziv"].ToString();
                description = readerBasicData["opis"].ToString();
                id = (int)readerBasicData["id"];

                start = Convert.ToDateTime(readerBasicData["pocetak"].ToString());

                try
                {
                    end = Convert.ToDateTime(readerBasicData["kraj"].ToString());
                }
                catch (FormatException e)
                {
                    end = null;
                }

                try
                {
                    expectedEnd = Convert.ToDateTime(readerBasicData["ocekivaniKraj"].ToString());
                }
                catch (FormatException e)
                {
                    expectedEnd = null;
                }

                readerBasicData.Close();
                conn.Close();

                people = new DataTable();

                peopleAdapter = new SqlDataAdapter($"select Korisnik.id as {korisnik_id}, Korisnik.username as {korisnik_username} from Korisnik;", conn);

                peopleAdapter.Fill(people);
            }
        }

        ProjectData data;
        bool isCreatingNewProject;

        SqlConnection conn;

        public Project()
        {
            InitializeComponent();
            isCreatingNewProject = true;

            conn = new SqlConnection(ConfigurationManager.AppSettings["dbConnString"]);

            data = new ProjectData(conn);

            DisplayData();

            SetAvailable();
        }

        public Project(int projectId)
        {
            InitializeComponent();
            isCreatingNewProject = false;

            conn = new SqlConnection(ConfigurationManager.AppSettings["dbConnString"]);

            data = new ProjectData(conn, projectId);

            DisplayData();
            SetAvailable();
        }

        private void Project_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void DisplayData()
        {
            tbProjName.Text = data.name;
            tbProjDesc.Text = data.description;

            clbPeople.DataSource = data.people;
            clbPeople.ValueMember = korisnik_id;
            clbPeople.DisplayMember = korisnik_username;
            
            clbPeople.SelectedValue = Program.UserId;

            dtpStart.Value = data.start;

            dtpExpectedEnd.Value = data.expectedEnd is null ? data.start : (DateTime)data.expectedEnd;

            if (!isCreatingNewProject)
            {
                var people = new DataTable();
                var peopleAdapter = new SqlDataAdapter($"select * from ClanoviProjekta({data.id});", conn);
                peopleAdapter.Fill(people);

                for (var i = 0; i < people.Rows.Count; ++i)
                {
                    clbPeople.SelectedValue = people.Rows[i][korisnik_id];
                    clbPeople.SetItemChecked(clbPeople.SelectedIndex, true);
                }

                clbPeople.SelectedValue = Program.UserId;
            }
            else
            {
                clbPeople.SetItemChecked(clbPeople.SelectedIndex, true);
            }
        }

        private void SetAvailable()
        {
            if (isCreatingNewProject)
            {
                btnCreateProject.Enabled = true;
                btnChangeProject.Enabled = false;
            } else
            {
                btnChangeProject.Enabled = true;
                btnCreateProject.Enabled = false;
            }
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            if (!ValidateAll())
            {
                MessageBox.Show("Nisu sva polja popunjena");
                return;
            }

            data.name = tbProjName.Text;
            data.description = tbProjDesc.Text;

            data.start = dtpStart.Value;
            if (dtpExpectedEnd.Value == dtpStart.Value)
                data.expectedEnd = null;
            else
                data.expectedEnd = dtpExpectedEnd.Value;

            var commAddProj = new SqlCommand($@"insert into Projekat(naziv, opis, pocetak, ocekivaniKraj)
                                                values ('{data.name}',
                                                        '{data.description}',
                                                        '{(SqlDateTime)data.start}',
                                                        '{(data.expectedEnd is null ? 
                                                            "null" :
                                                            ((SqlDateTime)data.expectedEnd).ToString())}'
                                                );", conn);

            var commGetId = new SqlCommand($"select id from Projekat where naziv = '{data.name}';", conn);
            Func<int, Func<int, SqlCommand>> createBuliderForCommandToAddMember = (int projId) => ((int korisnikId) => new SqlCommand($"exec DodajClanstvoBasic {korisnikId}, {projId}", conn));

            conn.Open();

            commAddProj.ExecuteNonQuery();
            data.id = (int)commGetId.ExecuteScalar();

            var buliderForCommandToAddMember = createBuliderForCommandToAddMember(data.id);
            
            for (var i = 0; i < clbPeople.Items.Count; ++i)
            {
                var shouldJoin = clbPeople.GetItemChecked(i);
                if (!shouldJoin) continue;

                clbPeople.SelectedIndex = i;

                var korisnik = (int)clbPeople.SelectedValue;

                buliderForCommandToAddMember(korisnik).ExecuteNonQuery();
            }

            conn.Close();

            Close();
        }

        private bool ValidateAll()
        {
            return !(string.IsNullOrEmpty(tbProjDesc.Text) || string.IsNullOrEmpty(tbProjName.Text) || clbPeople.CheckedIndices.Count == 0);
        }

        private void btnChangeProject_Click(object sender, EventArgs e)
        {
            if (!ValidateAll())
            {
                MessageBox.Show("Nisu sva polja popunjena");
                return;
            }

            var deletedSelf = false;

            data.name = tbProjName.Text;
            data.description = tbProjDesc.Text;

            data.start = dtpStart.Value;
            if (dtpExpectedEnd.Value == dtpStart.Value)
                data.expectedEnd = null;
            else
                data.expectedEnd = dtpExpectedEnd.Value;

            var commUpdateProj = new SqlCommand($@"update Projekat set
                                                        naziv = '{data.name}',
                                                        opis = '{data.description}',
                                                        pocetak = '{data.start}',
                                                        ocekivaniKraj = '{(data.expectedEnd is null ?
                                                                            "null" :
                                                                            ((SqlDateTime)data.expectedEnd).ToString())
                                                                         }'
                                                   where id = {data.id};", conn);

            Func<int, SqlCommand> createMembershipDeleter = id => new SqlCommand($"delete from Clanstvo where projekat = {data.id} and korisnik = {id};", conn);
            Func<int, SqlCommand> createMembershipInserter = id => new SqlCommand($"exec DodajClanstvoBasic {id}, {data.id}", conn);

            var currentMembers = new List<int>();

            conn.Open();

            var currentMembersReader = new SqlCommand($"select {korisnik_id} from ClanoviProjekta({data.id});", conn).ExecuteReader();
            while (currentMembersReader.Read())
                currentMembers.Add((int)currentMembersReader[korisnik_id]);
            currentMembersReader.Close();

            commUpdateProj.ExecuteNonQuery();

            for (var i = 0; i < clbPeople.Items.Count; ++i)
            {
                var isMember = clbPeople.GetItemChecked(i);
                clbPeople.SelectedIndex = i;
                var id = (int)clbPeople.SelectedValue;

                if ((currentMembers.Contains(id) && isMember) || (!currentMembers.Contains(id) && !isMember))
                    continue;

                if (currentMembers.Contains(id) && !isMember)
                {
                    createMembershipDeleter(id).ExecuteNonQuery();
                    if (id == Program.UserId) deletedSelf = true;
                    continue;
                }

                if (!currentMembers.Contains(id) && isMember)
                {
                    createMembershipInserter(id).ExecuteNonQuery();
                    continue;
                }
            }

            conn.Close();

            if (deletedSelf)
                Close();
        }

        private void Project_Load(object sender, EventArgs e)
        {
            dtpStart.CustomFormat       = "dd-MM-yy HH:mm:ss";
            dtpExpectedEnd.CustomFormat = "dd-MM-yy HH:mm:ss";
        }
    }
}
