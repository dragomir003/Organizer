using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Organizer
{
    public partial class Dashboard : Form
    {
        SqlConnection conn;

        DataTable dashboard;

        public Dashboard()
        {
            InitializeComponent();

            Visible = false;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConfigurationManager.AppSettings["dbConnString"]);

            lblTitle.Text = Program.Username;
            lbProjects.Items.Clear();

            SqlDataAdapter adapter = new SqlDataAdapter($"select * from GetProjectsBasic('{Program.Username}');", conn);

            dashboard = new DataTable();
            adapter.Fill(dashboard);

            for (int i = 0; i < dashboard.Rows.Count; ++i)
            {
                lbProjects.Items.Add(dashboard.Rows[i]["naziv"].ToString() + " ---- " + dashboard.Rows[i]["opis"].ToString());
            }

        }

        private void btnNewProject_Click(object sender, EventArgs e) => new Project().Show();

        private void lbProjects_DoubleClick(object sender, EventArgs e)
        {
            var id = (int)dashboard.Rows[lbProjects.SelectedIndex]["id"];
            new Project(id).Show();
        }
    }
}
