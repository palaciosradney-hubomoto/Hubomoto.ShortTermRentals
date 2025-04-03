using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            // Hide certain TabPages when FormMain is loaded
            //materialTabControl1.TabPages.Remove(tabPageAnalysis); // Hide "Analysis" tab
            //materialTabControl1.TabPages.Remove(tabPageKPIs); // Hide "KPIs" tab
            //materialTabControl1.TabPages.Remove(tabPageProperties); // Hide "Properties" tab
            //materialTabControl1.TabPages.Remove(tabPageUsers); // Hide "Users" tab
            //materialTabControl1.TabPages.Remove(tabPageDownload); // Hide "Download" tab

            // Optionally, show certain tabs at some later point
            // tabControl1.TabPages.Add(tabPageDataEntry); // Show it again later

            
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

   
    }
}
