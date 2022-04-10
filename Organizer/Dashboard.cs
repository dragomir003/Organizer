using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Organizer
{
    public partial class Dashboard : Form
    {
        SqlConnection conn;

        DataTable dashboard;

        string username;

        public Dashboard(string username)
        {
            InitializeComponent();

            this.username = username;

            Visible = false;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConfigurationManager.AppSettings["dbConnString"]);

            lblTitle.Text = username;

            SqlDataAdapter adapter = new SqlDataAdapter("select * from GetProjectsBasic('" + username + "');", conn);

            dashboard = new DataTable();
            adapter.Fill(dashboard);

            for (int i = 0; i < dashboard.Rows.Count; ++i)
            {
                lbProjects.Items.Add(dashboard.Rows[i]["naziv"].ToString() + " ---- " + dashboard.Rows[i]["opis"].ToString());
            }
            
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            Visible = false;
            new Project().ShowDialog();
            Visible = true;
        }

        private void lbProjects_DoubleClick(object sender, EventArgs e)
        {
            var id = (int)(dashboard.Rows[lbProjects.SelectedIndex]["id"]);
            Visible = false;
            new Project(id).ShowDialog();
            Visible = true;
        }
    }
}
