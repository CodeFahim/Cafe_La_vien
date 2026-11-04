namespace Cafe_La_Vien
{
    partial class FormCashier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCashier));
            this.pnlCashier = new System.Windows.Forms.Panel();
            this.pnlCashierButtons = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnLogOutCashier = new System.Windows.Forms.Button();
            this.btnSaleHistoryCashier = new System.Windows.Forms.Button();
            this.btnProductManage = new System.Windows.Forms.Button();
            this.btnProfileCashier = new System.Windows.Forms.Button();
            this.lblCashierPanel = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pnlCashier.SuspendLayout();
            this.pnlCashierButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCashier
            // 
            this.pnlCashier.BackColor = System.Drawing.Color.Transparent;
            this.pnlCashier.Controls.Add(this.pnlCashierButtons);
            this.pnlCashier.Controls.Add(this.lblCashierPanel);
            this.pnlCashier.Controls.Add(this.pictureBox7);
            this.pnlCashier.Location = new System.Drawing.Point(12, 12);
            this.pnlCashier.Name = "pnlCashier";
            this.pnlCashier.Size = new System.Drawing.Size(776, 426);
            this.pnlCashier.TabIndex = 1;
            // 
            // pnlCashierButtons
            // 
            this.pnlCashierButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlCashierButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCashierButtons.Controls.Add(this.pictureBox4);
            this.pnlCashierButtons.Controls.Add(this.pictureBox1);
            this.pnlCashierButtons.Controls.Add(this.pictureBox6);
            this.pnlCashierButtons.Controls.Add(this.pictureBox5);
            this.pnlCashierButtons.Controls.Add(this.btnLogOutCashier);
            this.pnlCashierButtons.Controls.Add(this.btnSaleHistoryCashier);
            this.pnlCashierButtons.Controls.Add(this.btnProductManage);
            this.pnlCashierButtons.Controls.Add(this.btnProfileCashier);
            this.pnlCashierButtons.ForeColor = System.Drawing.Color.White;
            this.pnlCashierButtons.Location = new System.Drawing.Point(57, 49);
            this.pnlCashierButtons.Name = "pnlCashierButtons";
            this.pnlCashierButtons.Size = new System.Drawing.Size(676, 359);
            this.pnlCashierButtons.TabIndex = 2;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Image = global::Cafe_La_Vien.Properties.Resources.stats;
            this.pictureBox4.Location = new System.Drawing.Point(24, 193);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(62, 53);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Cafe_La_Vien.Properties.Resources.profile;
            this.pictureBox1.Location = new System.Drawing.Point(24, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.White;
            this.pictureBox6.Image = global::Cafe_La_Vien.Properties.Resources.logout_sign_out_icon_in_line_style_vector;
            this.pictureBox6.Location = new System.Drawing.Point(389, 295);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(43, 41);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 12;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Image = global::Cafe_La_Vien.Properties.Resources.self_service__1_;
            this.pictureBox5.Location = new System.Drawing.Point(13, 107);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(85, 71);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // btnLogOutCashier
            // 
            this.btnLogOutCashier.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogOutCashier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOutCashier.FlatAppearance.BorderSize = 0;
            this.btnLogOutCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOutCashier.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOutCashier.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogOutCashier.Image = global::Cafe_La_Vien.Properties.Resources.red_solid_color;
            this.btnLogOutCashier.Location = new System.Drawing.Point(282, 295);
            this.btnLogOutCashier.Name = "btnLogOutCashier";
            this.btnLogOutCashier.Size = new System.Drawing.Size(150, 41);
            this.btnLogOutCashier.TabIndex = 6;
            this.btnLogOutCashier.Text = "Log Out";
            this.btnLogOutCashier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOutCashier.UseVisualStyleBackColor = false;
            this.btnLogOutCashier.Click += new System.EventHandler(this.btnLogOutCashier_Click);
            // 
            // btnSaleHistoryCashier
            // 
            this.btnSaleHistoryCashier.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnSaleHistoryCashier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaleHistoryCashier.FlatAppearance.BorderSize = 0;
            this.btnSaleHistoryCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaleHistoryCashier.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaleHistoryCashier.ForeColor = System.Drawing.Color.Black;
            this.btnSaleHistoryCashier.Location = new System.Drawing.Point(113, 202);
            this.btnSaleHistoryCashier.Name = "btnSaleHistoryCashier";
            this.btnSaleHistoryCashier.Size = new System.Drawing.Size(180, 44);
            this.btnSaleHistoryCashier.TabIndex = 5;
            this.btnSaleHistoryCashier.Text = "Sales Record";
            this.btnSaleHistoryCashier.UseVisualStyleBackColor = false;
            this.btnSaleHistoryCashier.Click += new System.EventHandler(this.btnSaleHistoryCashier_Click);
            // 
            // btnProductManage
            // 
            this.btnProductManage.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnProductManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductManage.FlatAppearance.BorderSize = 0;
            this.btnProductManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductManage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductManage.ForeColor = System.Drawing.Color.Black;
            this.btnProductManage.Location = new System.Drawing.Point(113, 123);
            this.btnProductManage.Name = "btnProductManage";
            this.btnProductManage.Size = new System.Drawing.Size(180, 35);
            this.btnProductManage.TabIndex = 4;
            this.btnProductManage.Text = "Take Order";
            this.btnProductManage.UseVisualStyleBackColor = false;
            this.btnProductManage.Click += new System.EventHandler(this.btnProductManage_Click);
            // 
            // btnProfileCashier
            // 
            this.btnProfileCashier.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnProfileCashier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfileCashier.FlatAppearance.BorderSize = 0;
            this.btnProfileCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfileCashier.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfileCashier.ForeColor = System.Drawing.Color.Black;
            this.btnProfileCashier.Location = new System.Drawing.Point(113, 38);
            this.btnProfileCashier.Name = "btnProfileCashier";
            this.btnProfileCashier.Size = new System.Drawing.Size(180, 39);
            this.btnProfileCashier.TabIndex = 1;
            this.btnProfileCashier.Text = "User Profile";
            this.btnProfileCashier.UseVisualStyleBackColor = false;
            this.btnProfileCashier.Click += new System.EventHandler(this.btnProfileCashier_Click);
            // 
            // lblCashierPanel
            // 
            this.lblCashierPanel.BackColor = System.Drawing.Color.Transparent;
            this.lblCashierPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCashierPanel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashierPanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCashierPanel.Location = new System.Drawing.Point(298, 0);
            this.lblCashierPanel.Name = "lblCashierPanel";
            this.lblCashierPanel.Size = new System.Drawing.Size(182, 37);
            this.lblCashierPanel.TabIndex = 0;
            this.lblCashierPanel.Text = "Cashier Panel";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::Cafe_La_Vien.Properties.Resources.Dark_Brown_Vintage_Retro_Coffee_Shop_Logo2;
            this.pictureBox7.Location = new System.Drawing.Point(661, -37);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(132, 125);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 13;
            this.pictureBox7.TabStop = false;
            // 
            // FormCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cafe_La_Vien.Properties.Resources.A_warm_and_inviting_cafe_interior_with_a_rustic__bohemian_aesthetic__Sunlight_streams_through_large_windows__illuminating_wooden_tables_and_comfortable_seating__Shelves_are_adorned_with_plants_and_artisanal_decor2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlCashier);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier Panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCashier_FormClosed);
            this.pnlCashier.ResumeLayout(false);
            this.pnlCashierButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCashier;
        private System.Windows.Forms.Panel pnlCashierButtons;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnLogOutCashier;
        private System.Windows.Forms.Button btnSaleHistoryCashier;
        private System.Windows.Forms.Button btnProductManage;
        private System.Windows.Forms.Button btnProfileCashier;
        private System.Windows.Forms.Label lblCashierPanel;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}