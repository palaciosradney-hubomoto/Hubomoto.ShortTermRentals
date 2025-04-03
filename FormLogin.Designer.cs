namespace ShortTermRentals
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.TBUsername = new MaterialSkin.Controls.MaterialTextBox2();
            this.TBPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.BTNLogin = new MaterialSkin.Controls.MaterialButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LBError = new MaterialSkin.Controls.MaterialLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TBUsername
            // 
            this.TBUsername.AnimateReadOnly = true;
            this.TBUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TBUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TBUsername.Depth = 0;
            this.TBUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TBUsername.HelperText = "Username";
            this.TBUsername.HideSelection = true;
            this.TBUsername.Hint = "Username";
            this.TBUsername.LeadingIcon = null;
            this.TBUsername.Location = new System.Drawing.Point(27, 97);
            this.TBUsername.MaxLength = 32767;
            this.TBUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.TBUsername.Name = "TBUsername";
            this.TBUsername.PasswordChar = '\0';
            this.TBUsername.PrefixSuffixText = null;
            this.TBUsername.ReadOnly = false;
            this.TBUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TBUsername.SelectedText = "";
            this.TBUsername.SelectionLength = 0;
            this.TBUsername.SelectionStart = 0;
            this.TBUsername.ShortcutsEnabled = true;
            this.TBUsername.ShowAssistiveText = true;
            this.TBUsername.Size = new System.Drawing.Size(250, 52);
            this.TBUsername.TabIndex = 1;
            this.TBUsername.TabStop = false;
            this.TBUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TBUsername.TrailingIcon = null;
            this.TBUsername.UseSystemPasswordChar = false;
            this.TBUsername.UseTallSize = false;
            // 
            // TBPassword
            // 
            this.TBPassword.AnimateReadOnly = false;
            this.TBPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TBPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TBPassword.Depth = 0;
            this.TBPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TBPassword.HelperText = "Password";
            this.TBPassword.HideSelection = true;
            this.TBPassword.Hint = "Password";
            this.TBPassword.LeadingIcon = null;
            this.TBPassword.Location = new System.Drawing.Point(27, 155);
            this.TBPassword.MaxLength = 32767;
            this.TBPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.PasswordChar = '●';
            this.TBPassword.PrefixSuffixText = null;
            this.TBPassword.ReadOnly = false;
            this.TBPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TBPassword.SelectedText = "";
            this.TBPassword.SelectionLength = 0;
            this.TBPassword.SelectionStart = 0;
            this.TBPassword.ShortcutsEnabled = true;
            this.TBPassword.ShowAssistiveText = true;
            this.TBPassword.Size = new System.Drawing.Size(250, 52);
            this.TBPassword.TabIndex = 2;
            this.TBPassword.TabStop = false;
            this.TBPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TBPassword.TrailingIcon = null;
            this.TBPassword.UseSystemPasswordChar = true;
            this.TBPassword.UseTallSize = false;
            // 
            // BTNLogin
            // 
            this.BTNLogin.AutoSize = false;
            this.BTNLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTNLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BTNLogin.Depth = 0;
            this.BTNLogin.HighEmphasis = true;
            this.BTNLogin.Icon = null;
            this.BTNLogin.Location = new System.Drawing.Point(76, 216);
            this.BTNLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BTNLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.BTNLogin.Name = "BTNLogin";
            this.BTNLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BTNLogin.Size = new System.Drawing.Size(153, 39);
            this.BTNLogin.TabIndex = 3;
            this.BTNLogin.Text = "LOGIN";
            this.BTNLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BTNLogin.UseAccentColor = false;
            this.BTNLogin.UseVisualStyleBackColor = true;
            this.BTNLogin.Click += new System.EventHandler(this.BTNLogin_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 336);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LBError);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.TBUsername);
            this.panel2.Controls.Add(this.TBPassword);
            this.panel2.Controls.Add(this.BTNLogin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(270, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 336);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(27, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // LBError
            // 
            this.LBError.Depth = 0;
            this.LBError.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LBError.ForeColor = System.Drawing.Color.Red;
            this.LBError.Location = new System.Drawing.Point(6, 283);
            this.LBError.MouseState = MaterialSkin.MouseState.HOVER;
            this.LBError.Name = "LBError";
            this.LBError.Size = new System.Drawing.Size(296, 53);
            this.LBError.TabIndex = 5;
            this.LBError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.BTNLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(578, 403);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormLogin";
            this.Sizable = false;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox2 TBUsername;
        private MaterialSkin.Controls.MaterialTextBox2 TBPassword;
        private MaterialSkin.Controls.MaterialButton BTNLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel LBError;
    }
}