using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;

namespace ShortTermRentals
{
    public partial class FormLogin : MaterialForm
    {
        public FormLogin()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme
               (
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.Blue200,
                TextShade.WHITE
               );

            // Example of changing the color of MaterialLabel
            LBError.ForeColor = Color.Red;  // Setting custom color to red
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void BTNLogin_Click(object sender, EventArgs e)
        {
            string username = TBUsername.Text;
            string password = TBPassword.Text;

            if (AuthenticateUser(username, password))
            {
                // Optional: show welcome message or log user session
                FormMain formMain = new FormMain();
                this.Hide();
                formMain.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Connection string from your app.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to check credentials and get user details
                    string query = @"SELECT `First Name`, `Middle Name`, `Last Name`, `Privilege`
                             FROM Users
                             WHERE Username = @username AND BINARY Password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Build full name
                                string firstName = reader["First Name"].ToString();
                                string middleName = reader["Middle Name"].ToString();
                                string lastName = reader["Last Name"].ToString();
                                string privilege = reader["Privilege"].ToString();

                                string fullName = $"{firstName} {middleName} {lastName}".Trim();

                                // Save to global session
                                Session.Username = username;
                                Session.FullName = fullName;
                                Session.Privilege = privilege;

                                return true; // Login successful
                            }
                            else
                            {
                                return false; // Invalid credentials
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
