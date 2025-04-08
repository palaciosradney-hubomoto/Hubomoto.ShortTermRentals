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
            // Initialize background worker
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
        }

        private void BTNLogin_Click(object sender, EventArgs e)
        {

            string username = TBUsername.PrefixSuffixText + TBUsername.Text;
            string password = TBPassword.Text;

            // Show the "Signing in..." message
            LBError.Text = "Signing in...";
            LBError.Visible = true;

            // Disable login button to prevent multiple clicks
            BTNLogin.Enabled = false;
            TBUsername.Enabled = false;
            TBPassword.Enabled = false;
            CBShowPassword.Enabled = false;
            PBLoading.Visible = true;

            // Start background worker to authenticate user
            backgroundWorker1.RunWorkerAsync(new { Username = username, Password = password });

            //string username = TBUsername.Text;
            //string password = TBPassword.Text;

            //if (AuthenticateUser(username, password))
            //{
            //    // Optional: show welcome message or log user session
            //    FormMain formMain = new FormMain();
            //    this.Hide();
            //    formMain.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        
        // The actual authentication happens here in the background thread
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (dynamic)e.Argument;
            string username = args.Username;
            string password = args.Password;

            // Perform authentication (this code is exactly the same as AuthenticateUser method)
            bool loginSuccess = AuthenticateUser(username, password);

            e.Result = loginSuccess;  // Return the result of authentication to the completed event
        }

        // After the background work completes, update the UI on the main thread
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Hide "Signing in..." message
            LBError.Visible = false;

            // Enable the login button again
            BTNLogin.Enabled = true;
            TBUsername.Enabled = true;
            TBPassword.Enabled = true;
            CBShowPassword.Enabled = true;
            PBLoading.Visible = false;

            // Check if login was successful or failed
            if (e.Error != null)
            {
                // Handle error
                MessageBox.Show("An error occurred: " + e.Error.Message);
                return;
            }

            if ((bool)e.Result)
            {
                // If login is successful, proceed to FormMain
                FormMain formMain = new FormMain();
                this.Hide();
                formMain.Show();
            }
            else
            {
                // Show error if login fails
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Primary and fallback connection strings
            string[] connectionStrings = new string[]
            {
        System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString,
        System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnectionStringTest"].ConnectionString
            };

            foreach (string connStr in connectionStrings)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();

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
                                    return false; // Credentials invalid, no need to try next connection
                                }
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Try next connection string if available
                    continue;
                }
                
            }

            // All connection attempts failed
            MessageBox.Show("Unable to connect to the database. Please check your connection.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void CBShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CBShowPassword.Checked)
            {
                // Show password: set UseSystemPasswordChar to false, and clear PasswordChar
                TBPassword.UseSystemPasswordChar = false;
                TBPassword.PasswordChar = '\0';  // Clears the bullet character (set to null)
            }
            else
            {
                // Hide password: set UseSystemPasswordChar to true, and reset PasswordChar to bullet
                TBPassword.UseSystemPasswordChar = true;
                TBPassword.PasswordChar = '•';  // Sets the bullet character
            }

            // Optionally, check the current state of the password visibility
            //LBError.Text=$"Password visibility: {TBPassword.UseSystemPasswordChar}";
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
