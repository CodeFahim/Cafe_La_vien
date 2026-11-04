namespace Cafe_La_Vien
{
    partial class FormCustomerPanel
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
            this.dgvUserView = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblCustomerHistory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUserView
            // 
            this.dgvUserView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserView.BackgroundColor = System.Drawing.Color.BurlyWood;
            this.dgvUserView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserView.Location = new System.Drawing.Point(82, 71);
            this.dgvUserView.Name = "dgvUserView";
            this.dgvUserView.ReadOnly = true;
            this.dgvUserView.RowHeadersWidth = 51;
            this.dgvUserView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserView.Size = new System.Drawing.Size(452, 253);
            this.dgvUserView.TabIndex = 26;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(122, 354);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(142, 32);
            this.btnBack.TabIndex = 27;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnShowAll.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAll.Location = new System.Drawing.Point(351, 354);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(142, 32);
            this.btnShowAll.TabIndex = 28;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            // 
            // lblCustomerHistory
            // 
            this.lblCustomerHistory.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCustomerHistory.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerHistory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCustomerHistory.Location = new System.Drawing.Point(192, 9);
            this.lblCustomerHistory.Name = "lblCustomerHistory";
            this.lblCustomerHistory.Size = new System.Drawing.Size(215, 37);
            this.lblCustomerHistory.TabIndex = 29;
            this.lblCustomerHistory.Text = "Customer History";
            // 
            // FormCustomerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.BackgroundImage = global::Cafe_La_Vien.Properties.Resources.Screenshot_2025_09_13_1125182;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(642, 440);
            this.Controls.Add(this.lblCustomerHistory);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvUserView);
            this.Name = "FormCustomerPanel";
            this.Text = "FormCustomerPanel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUserView;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label lblCustomerHistory;
    }
}