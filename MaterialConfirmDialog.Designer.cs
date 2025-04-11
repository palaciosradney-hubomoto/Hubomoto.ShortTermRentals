namespace ShortTermRentals
{
    partial class MaterialConfirmDialog
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
            this.materialLabelMessage = new MaterialSkin.Controls.MaterialLabel();
            this.BTNYes = new MaterialSkin.Controls.MaterialButton();
            this.BTNNo = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialLabelMessage
            // 
            this.materialLabelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabelMessage.Depth = 0;
            this.materialLabelMessage.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabelMessage.Location = new System.Drawing.Point(6, 34);
            this.materialLabelMessage.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelMessage.Name = "materialLabelMessage";
            this.materialLabelMessage.Padding = new System.Windows.Forms.Padding(5);
            this.materialLabelMessage.Size = new System.Drawing.Size(286, 80);
            this.materialLabelMessage.TabIndex = 0;
            this.materialLabelMessage.Text = "materialLabel1";
            this.materialLabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTNYes
            // 
            this.BTNYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNYes.AutoSize = false;
            this.BTNYes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTNYes.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BTNYes.Depth = 0;
            this.BTNYes.HighEmphasis = true;
            this.BTNYes.Icon = null;
            this.BTNYes.Location = new System.Drawing.Point(5, 120);
            this.BTNYes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BTNYes.MouseState = MaterialSkin.MouseState.HOVER;
            this.BTNYes.Name = "BTNYes";
            this.BTNYes.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BTNYes.Size = new System.Drawing.Size(140, 36);
            this.BTNYes.TabIndex = 1;
            this.BTNYes.Text = "yes";
            this.BTNYes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BTNYes.UseAccentColor = false;
            this.BTNYes.UseVisualStyleBackColor = true;
            this.BTNYes.Click += new System.EventHandler(this.BTNYes_Click);
            // 
            // BTNNo
            // 
            this.BTNNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNNo.AutoSize = false;
            this.BTNNo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTNNo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BTNNo.Depth = 0;
            this.BTNNo.HighEmphasis = true;
            this.BTNNo.Icon = null;
            this.BTNNo.Location = new System.Drawing.Point(153, 120);
            this.BTNNo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BTNNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.BTNNo.Name = "BTNNo";
            this.BTNNo.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BTNNo.Size = new System.Drawing.Size(140, 36);
            this.BTNNo.TabIndex = 2;
            this.BTNNo.Text = "No";
            this.BTNNo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BTNNo.UseAccentColor = false;
            this.BTNNo.UseVisualStyleBackColor = true;
            this.BTNNo.Click += new System.EventHandler(this.BTNNo_Click);
            // 
            // MaterialConfirmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 165);
            this.Controls.Add(this.BTNNo);
            this.Controls.Add(this.BTNYes);
            this.Controls.Add(this.materialLabelMessage);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "MaterialConfirmDialog";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmation";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabelMessage;
        private MaterialSkin.Controls.MaterialButton BTNYes;
        private MaterialSkin.Controls.MaterialButton BTNNo;
    }
}