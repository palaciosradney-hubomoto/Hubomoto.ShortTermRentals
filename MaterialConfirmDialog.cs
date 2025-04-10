﻿using System;
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

namespace ShortTermRentals
{
    public partial class MaterialConfirmDialog : MaterialForm
    {
        public bool IsConfirmed { get; private set; }

        public MaterialConfirmDialog(string message)
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

            materialLabelMessage.Text = message;

        }

        private void BTNYes_Click(object sender, EventArgs e)
        {
            IsConfirmed = true;
            this.Close();
        }

        private void BTNNo_Click(object sender, EventArgs e)
        {
            IsConfirmed = false;
            this.Close();
        }
    }
}
