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
    public partial class Login : Form
    {
        SqlConnection conn;
        public Login()
        {
            InitializeComponent();

            conn = new SqlConnection(ConfigurationManager.AppSettings["dbConnString"]);

            conn.Open();

            MessageBox.Show(conn.State == ConnectionState.Open ? "Allright" : "Not allright");

            conn.Close();
        }


    }
}
