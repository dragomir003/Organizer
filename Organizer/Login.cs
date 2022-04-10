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
        enum LoginResult
        {
            Success = 0,
            Fail,
        }

        SqlConnection conn;

        public Login()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.AppSettings["dbConnString"]);

            AcceptButton = btnLogin;
        }

        private string ValidateUsername()
        {
            var username = tbUsername.Text.Trim();

            return username.Length > 32 ? null : username;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = ValidateUsername();
            if (username == null)
            {
                MessageBox.Show("Korisnicko ime nije dobro. Mozda je predugacko?");
                return;
            }

            conn.Open();
            SqlCommand validate = new SqlCommand("select dbo.ValidateLogin('" + username + "');", conn);
            LoginResult result = (LoginResult)(int)validate.ExecuteScalar();

            conn.Close();

            if (result == LoginResult.Fail)
            {
                MessageBox.Show("Korisnicko ime: " + username + " ne postoji.\nProbajte registraciju.");
                return;
            }

            Visible = false;
            new Dashboard(username).ShowDialog();

            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = ValidateUsername();
            if (username == null)
            {
                MessageBox.Show("Korisnicko ime nije dobro. Mozda je predugacko?");
                return;
            }

            conn.Open();
            SqlCommand validate = new SqlCommand("declare @res int; exec @res = Register '" + username + "'; select @res;", conn);
            LoginResult result = (LoginResult)(int)validate.ExecuteScalar();
            conn.Close();

            if (result == LoginResult.Fail)
            {
                MessageBox.Show("Ne mozete se registrovati na dato korisnicko ime: " + username + ". Morate se ulogovati.");
                return;
            }

            Visible = false;
            new Dashboard(username).ShowDialog();

            Close();
        }
    }
}
