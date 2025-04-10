using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortTermRentals
{
    public partial class FormMain : MaterialForm
    {
       
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
                    materialTabControl1.TabPages.Remove(tabPageLogout);
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
    }
}
