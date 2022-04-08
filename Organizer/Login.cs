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

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand validate = new SqlCommand("select dbo.ValidateLogin('" + tbUsername.Text + "');", conn);
            LoginResult result = (LoginResult)(int)validate.ExecuteScalar();

            conn.Close();

            if (result == LoginResult.Fail)
            {
                MessageBox.Show("Korisnicko ime: " + tbUsername.Text + " ne postoji.\nProbajte registraciju.");
                return;
            }

            MessageBox.Show("TODO: Open next form with correct credentials");        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand validate = new SqlCommand("declare @res int; exec @res = Register '" + tbUsername.Text + "'; select @res;", conn);
            LoginResult result = (LoginResult)(int)validate.ExecuteScalar();
            conn.Close();

            if (result == LoginResult.Fail)
            {
                MessageBox.Show("Ne mozete se registrovati na dato korisnicko ime: " + tbUsername.Text + ". Morate se ulogovati.");
                return;
            }

            MessageBox.Show("TODO: Open next form with correct credentials");
        }
    }
}
