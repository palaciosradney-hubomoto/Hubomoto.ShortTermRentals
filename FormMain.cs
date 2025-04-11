using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortTermRentals
{
    public partial class FormMain : MaterialForm
    {
        // Primary and fallback connection strings
        string[] connectionStrings = new string[]
        {
        System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString,
        System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnectionStringTest"].ConnectionString
        };

        public FormMain()
        {
            InitializeComponent();

            ControlUtils.SetDoubleBuffer(flowLayoutPanel1, true);

            var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
			materialSkinManager.ColorScheme = new ColorScheme
               (
                Primary.BlueGrey800,
                Primary.BlueGrey900, 
                Primary.BlueGrey500, 
                Accent.Blue700,
                TextShade.WHITE
               );

            ApplyTabAccessRules();
            
        }

        private void BTNLogout_Click(object sender, EventArgs e)
        {
            // Show the custom confirmation dialog
            MaterialConfirmDialog confirmDialog = new MaterialConfirmDialog("Are you sure you want to log out?");
            confirmDialog.ShowDialog();  // Show the dialog as a modal window

            // Check if the user clicked "Yes"
            if (confirmDialog.IsConfirmed)
            {
                // Dispose FormMain
                this.Dispose();  // Close FormMain

                // Show FormLogin
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
            }
        }

        private void ApplyTabAccessRules()
        {
            string role = Session.Privilege;

            switch (role)
            {
                case "Admin":
                    // Admin sees all tabs
                    this.Text = $"HUBOMOTO Short Term Rentals : {Session.FullName} [{role}]";
                    break;

                case "Booking Specialist":
                    // Hide admin-only tabs
                    materialTabControl1.TabPages.Remove(tabPageAnalysis); // Hide "Analysis" tab
                    materialTabControl1.TabPages.Remove(tabPageKPIs); // Hide "KPIs" tab
                    materialTabControl1.TabPages.Remove(tabPageProperties); // Hide "Properties" tab
                    materialTabControl1.TabPages.Remove(tabPageUsers); // Hide "Users" tab
                    materialTabControl1.TabPages.Remove(tabPageDownload); // Hide "Download" tab
                    this.Text = $"HUBOMOTO Short Term Rentals : {Session.FullName} [{role}]";
                    break;

                case "Viewer":
                    // Only allow basic view access
                    materialTabControl1.TabPages.Remove(tabPageHome);
                    materialTabControl1.TabPages.Remove(tabPageDataEntry);
                    materialTabControl1.TabPages.Remove(tabPageAnalysis);
                    materialTabControl1.TabPages.Remove(tabPageKPIs);
                    materialTabControl1.TabPages.Remove(tabPageManageData);
                    materialTabControl1.TabPages.Remove(tabPageUsers);
                    materialTabControl1.TabPages.Remove(tabPageProperties);
                    materialTabControl1.TabPages.Remove(tabPageDownload);
                    this.Text = $"HUBOMOTO Short Term Rentals : {Session.FullName} [{role}]";
                    break;

                default:
                    // Fallback (hide sensitive tabs)
                    materialTabControl1.TabPages.Remove(tabPageHome);
                    materialTabControl1.TabPages.Remove(tabPageDataEntry);
                    materialTabControl1.TabPages.Remove(tabPageAnalysis);
                    materialTabControl1.TabPages.Remove(tabPageKPIs);
                    materialTabControl1.TabPages.Remove(tabPageManageData);
                    materialTabControl1.TabPages.Remove(tabPageUsers);
                    materialTabControl1.TabPages.Remove(tabPageProperties);
                    materialTabControl1.TabPages.Remove(tabPageDownload);
                    this.Text = $"HUBOMOTO Short Term Rentals : {Session.FullName} [{role}]";
                    break;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ask for confirmation to close the application
            MaterialConfirmDialog confirmDialog = new MaterialConfirmDialog("Are you sure you want to exit?");
            confirmDialog.ShowDialog();  // Show the dialog as a modal window

            // If the user clicks "Yes", exit the application
            if (confirmDialog.IsConfirmed)
            {
                // This will be handled in FormClosed, for a smoother exit
                e.Cancel = false;
                this.Dispose();
                FormLogin formLogin = new FormLogin();
                formLogin.ShowDialog();
            }
            else
            {
                e.Cancel = true; // Cancel the form closing if the user chooses "No"
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
           
        }

        private void BTNSubmit_Click(object sender, EventArgs e)
        {
            // List to store names of empty textboxes
            List<string> emptyFields = new List<string>();

            // Check if each field is empty and add the corresponding field name to the list
            if (string.IsNullOrWhiteSpace(TBGuestName.Text))
                emptyFields.Add("Guest Name");
            if (string.IsNullOrWhiteSpace(TBPax.Text))
                emptyFields.Add("Pax");
            if (string.IsNullOrWhiteSpace(TBPaymentAmount.Text))
                emptyFields.Add("Payment Amount");
            if (string.IsNullOrWhiteSpace(TBPaymentStatus.Text))
                emptyFields.Add("Payment Status");
            if (string.IsNullOrWhiteSpace(TBPropertyLocation.Text))
                emptyFields.Add("Property Location");
            if (string.IsNullOrWhiteSpace(TBRoomType.Text))
                emptyFields.Add("Room Type");
            if (string.IsNullOrWhiteSpace(TBOTAType.Text))
                emptyFields.Add("OTA Type");
            if (string.IsNullOrWhiteSpace(TBAdditionalGuestRequest.Text))
                emptyFields.Add("Additional Guest Request");
            if (string.IsNullOrWhiteSpace(TBBookedDate.Text))
                emptyFields.Add("Booked Date");
            if (string.IsNullOrWhiteSpace(TBBookedDateRangeFrom.Text))
                emptyFields.Add("Booked Date Range From");
            if (string.IsNullOrWhiteSpace(TBBookedDateRangeTo.Text))
                emptyFields.Add("Booked Date Range To");

            // If there are any empty fields, show a message box with the list of empty fields
            if (emptyFields.Count > 0)
            {
                string message = "The following fields are empty:\n\n" + string.Join("\n", emptyFields);
                MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further processing if there are empty fields
            }

            // If no fields are empty, proceed with further validation (dates, duplicates, etc.)

            // Handle date range conversion
            DateTime bookedDate, fromDate, toDate;
            bool isBookedDateValid = DateTime.TryParse(TBBookedDate.Text, out bookedDate);
            bool isFromDateValid = DateTime.TryParse(TBBookedDateRangeFrom.Text, out fromDate);
            bool isToDateValid = DateTime.TryParse(TBBookedDateRangeTo.Text, out toDate);

            if (!isFromDateValid || !isToDateValid)
            {
                MessageBox.Show("Please enter valid dates for the range.", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further processing if dates are invalid
            }

            // Step 1: Check if duplicate exists
            if (CheckDuplicate(TBGuestName.Text, bookedDate))
            {
                MessageBox.Show("Duplicate entry found. This record already exists.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Step 2: Insert data if no duplicates are found
                InsertData(TBGuestName.Text, int.Parse(TBPax.Text), decimal.Parse(TBPaymentAmount.Text), TBPaymentStatus.Text,
                    bookedDate, TBPropertyLocation.Text, TBRoomType.Text, TBOTAType.Text, TBAdditionalGuestRequest.Text, fromDate, toDate);
            }
        }

        private bool CheckDuplicate(string guestName, DateTime bookedDate)
        {
            string query = "SELECT COUNT(*) FROM Rentals WHERE `Guest Name` = @guestName AND `Booked Date` = @bookedDate";

            using (MySqlConnection conn = new MySqlConnection(GetAvailableConnectionString()))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@guestName", guestName);
                        cmd.Parameters.AddWithValue("@bookedDate", bookedDate);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0; // If count is greater than 0, a duplicate exists
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking for duplicates: " + ex.Message);
                    return true; // Assume error as a duplicate to prevent insertion
                }
            }
        }

        private void InsertData(string guestName, int pax, decimal paymentAmount, string paymentStatus, DateTime bookedDate, string propertyLocation, string roomType, string otaType, string additionalGuestRequest, DateTime fromDate, DateTime toDate)
        {
            string query = "INSERT INTO Rentals (`Guest Name`, `Pax`, `Payment Amount`, `Payment Status`, `Booked Date`, `Property Location`, `Room Type`, `OTA Type`, `Additional Guest Request`, `Booked From`, `Booked To`) " +
                           "VALUES (@guestName, @pax, @paymentAmount, @paymentStatus, @bookedDate, @propertyLocation, @roomType, @otaType, @additionalGuestRequest, @fromDate, @toDate)";

            using (MySqlConnection conn = new MySqlConnection(GetAvailableConnectionString()))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@guestName", guestName);
                        cmd.Parameters.AddWithValue("@pax", pax);
                        cmd.Parameters.AddWithValue("@paymentAmount", paymentAmount);
                        cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
                        cmd.Parameters.AddWithValue("@bookedDate", bookedDate);
                        cmd.Parameters.AddWithValue("@propertyLocation", propertyLocation);
                        cmd.Parameters.AddWithValue("@roomType", roomType);
                        cmd.Parameters.AddWithValue("@otaType", otaType);
                        cmd.Parameters.AddWithValue("@additionalGuestRequest", additionalGuestRequest);
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        cmd.ExecuteNonQuery(); // Executes the insert query
                        MessageBox.Show("Record successfully inserted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting data: " + ex.Message);
                }
            }
        }

        // Method to get the available connection string (primary or fallback)
        private string GetAvailableConnectionString()
        {
            foreach (var connectionString in connectionStrings)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open(); // Try to open the connection
                        return connectionString; // Return the connection string that worked
                    }
                }
                catch
                {
                    // If connection fails, move to the next connection string
                    continue;
                }
            }

            // If both connection strings fail, throw an exception
            throw new Exception("Unable to connect to both databases.");
        }

        private void DTPBookedDateRangeFrom_ValueChanged(object sender, EventArgs e)
        {
            TBBookedDateRangeFrom.Text = DTPBookedDateRangeFrom.Value.ToString();
        }

        private void DTPBookedDateRangeTo_ValueChanged(object sender, EventArgs e)
        {
            TBBookedDateRangeTo.Text = DTPBookedDateRangeTo.Value.ToString();
        }

        private void DTPBookedDate_ValueChanged(object sender, EventArgs e)
        {
            TBBookedDate.Text = DTPBookedDate.Value.ToString();
        }
               
        private void TBPax_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers (0-9) and control characters (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  // Ignore invalid key press
            }
        }

        private void TBPaymentAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow numbers (0-9), backspace, and one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;  // Ignore invalid key press
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && TBPaymentAmount.Text.Contains("."))
            {
                e.Handled = true;  // Ignore the second decimal point
            }
        }

        private void BTNClear_Click(object sender, EventArgs e)
        {
            // Call the function to clear all textboxes
            ClearAllTextBoxes();
        }

        private void ClearAllTextBoxes()
        {
            TBGuestName.Clear();
            TBPax.Clear();
            TBPaymentAmount.Clear();
            TBPaymentStatus.Clear();
            TBPropertyLocation.Clear();
            TBRoomType.Clear();
            TBOTAType.Clear();
            TBAdditionalGuestRequest.Clear();
            TBBookedDate.Clear();
            TBBookedDateRangeFrom.Clear();
            TBBookedDateRangeTo.Clear();
        }
    }
}
