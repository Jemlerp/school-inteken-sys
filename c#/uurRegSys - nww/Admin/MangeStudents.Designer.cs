namespace Admin {
    partial class MangeStudents {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing&&(components!=null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonRefreshOverview = new System.Windows.Forms.Button();
            this.textBoxUpdateANaam = new System.Windows.Forms.TextBox();
            this.textBoxUpdateNFCID = new System.Windows.Forms.TextBox();
            this.textBoxUpdateVNaam = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxUpdateIsVanSchoolAf = new System.Windows.Forms.CheckBox();
            this.buttonUpdateSaveUpdate = new System.Windows.Forms.Button();
            this.buttonUpdateGetNFCIDFromSerial = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonNewClear = new System.Windows.Forms.Button();
            this.buttonNewSave = new System.Windows.Forms.Button();
            this.buttonNewGetNFCIDFromSerial = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNewVNaam = new System.Windows.Forms.TextBox();
            this.textBoxNewANaam = new System.Windows.Forms.TextBox();
            this.textBoxNewNFCID = new System.Windows.Forms.TextBox();
            this.textBoxUpdateID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.Size = new System.Drawing.Size(756, 844);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // buttonRefreshOverview
            // 
            this.buttonRefreshOverview.Location = new System.Drawing.Point(764, 15);
            this.buttonRefreshOverview.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRefreshOverview.Name = "buttonRefreshOverview";
            this.buttonRefreshOverview.Size = new System.Drawing.Size(100, 28);
            this.buttonRefreshOverview.TabIndex = 5;
            this.buttonRefreshOverview.Text = "refresh";
            this.buttonRefreshOverview.UseVisualStyleBackColor = true;
            this.buttonRefreshOverview.Click += new System.EventHandler(this.buttonRefreshOverview_Click);
            // 
            // textBoxUpdateANaam
            // 
            this.textBoxUpdateANaam.Location = new System.Drawing.Point(88, 112);
            this.textBoxUpdateANaam.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUpdateANaam.Name = "textBoxUpdateANaam";
            this.textBoxUpdateANaam.Size = new System.Drawing.Size(161, 22);
            this.textBoxUpdateANaam.TabIndex = 6;
            // 
            // textBoxUpdateNFCID
            // 
            this.textBoxUpdateNFCID.Location = new System.Drawing.Point(88, 193);
            this.textBoxUpdateNFCID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUpdateNFCID.Name = "textBoxUpdateNFCID";
            this.textBoxUpdateNFCID.Size = new System.Drawing.Size(161, 22);
            this.textBoxUpdateNFCID.TabIndex = 7;
            // 
            // textBoxUpdateVNaam
            // 
            this.textBoxUpdateVNaam.Location = new System.Drawing.Point(88, 80);
            this.textBoxUpdateVNaam.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUpdateVNaam.Name = "textBoxUpdateVNaam";
            this.textBoxUpdateVNaam.Size = new System.Drawing.Size(161, 22);
            this.textBoxUpdateVNaam.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBoxUpdateID);
            this.panel1.Controls.Add(this.checkBoxUpdateIsVanSchoolAf);
            this.panel1.Controls.Add(this.buttonUpdateSaveUpdate);
            this.panel1.Controls.Add(this.buttonUpdateGetNFCIDFromSerial);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxUpdateVNaam);
            this.panel1.Controls.Add(this.textBoxUpdateANaam);
            this.panel1.Controls.Add(this.textBoxUpdateNFCID);
            this.panel1.Location = new System.Drawing.Point(801, 458);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 325);
            this.panel1.TabIndex = 9;
            // 
            // checkBoxUpdateIsVanSchoolAf
            // 
            this.checkBoxUpdateIsVanSchoolAf.AutoSize = true;
            this.checkBoxUpdateIsVanSchoolAf.Location = new System.Drawing.Point(128, 21);
            this.checkBoxUpdateIsVanSchoolAf.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxUpdateIsVanSchoolAf.Name = "checkBoxUpdateIsVanSchoolAf";
            this.checkBoxUpdateIsVanSchoolAf.Size = new System.Drawing.Size(121, 21);
            this.checkBoxUpdateIsVanSchoolAf.TabIndex = 24;
            this.checkBoxUpdateIsVanSchoolAf.Text = "isVanSchoolAf";
            this.checkBoxUpdateIsVanSchoolAf.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateSaveUpdate
            // 
            this.buttonUpdateSaveUpdate.Location = new System.Drawing.Point(25, 241);
            this.buttonUpdateSaveUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUpdateSaveUpdate.Name = "buttonUpdateSaveUpdate";
            this.buttonUpdateSaveUpdate.Size = new System.Drawing.Size(107, 41);
            this.buttonUpdateSaveUpdate.TabIndex = 22;
            this.buttonUpdateSaveUpdate.Text = "Update";
            this.buttonUpdateSaveUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdateSaveUpdate.Click += new System.EventHandler(this.buttonUpdateSaveUpdate_Click);
            // 
            // buttonUpdateGetNFCIDFromSerial
            // 
            this.buttonUpdateGetNFCIDFromSerial.Location = new System.Drawing.Point(88, 158);
            this.buttonUpdateGetNFCIDFromSerial.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUpdateGetNFCIDFromSerial.Name = "buttonUpdateGetNFCIDFromSerial";
            this.buttonUpdateGetNFCIDFromSerial.Size = new System.Drawing.Size(163, 28);
            this.buttonUpdateGetNFCIDFromSerial.TabIndex = 13;
            this.buttonUpdateGetNFCIDFromSerial.Text = "Get From Serial";
            this.buttonUpdateGetNFCIDFromSerial.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1  edit panle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 197);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "NFCID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "aNaam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "vNaam";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.buttonNewClear);
            this.panel2.Controls.Add(this.buttonNewSave);
            this.panel2.Controls.Add(this.buttonNewGetNFCIDFromSerial);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBoxNewVNaam);
            this.panel2.Controls.Add(this.textBoxNewANaam);
            this.panel2.Controls.Add(this.textBoxNewNFCID);
            this.panel2.Location = new System.Drawing.Point(801, 65);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 325);
            this.panel2.TabIndex = 10;
            // 
            // buttonNewClear
            // 
            this.buttonNewClear.Location = new System.Drawing.Point(204, 241);
            this.buttonNewClear.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNewClear.Name = "buttonNewClear";
            this.buttonNewClear.Size = new System.Drawing.Size(107, 41);
            this.buttonNewClear.TabIndex = 23;
            this.buttonNewClear.Text = "Clear";
            this.buttonNewClear.UseVisualStyleBackColor = true;
            // 
            // buttonNewSave
            // 
            this.buttonNewSave.Location = new System.Drawing.Point(25, 241);
            this.buttonNewSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNewSave.Name = "buttonNewSave";
            this.buttonNewSave.Size = new System.Drawing.Size(107, 41);
            this.buttonNewSave.TabIndex = 22;
            this.buttonNewSave.Text = "Save";
            this.buttonNewSave.UseVisualStyleBackColor = true;
            // 
            // buttonNewGetNFCIDFromSerial
            // 
            this.buttonNewGetNFCIDFromSerial.Location = new System.Drawing.Point(88, 148);
            this.buttonNewGetNFCIDFromSerial.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNewGetNFCIDFromSerial.Name = "buttonNewGetNFCIDFromSerial";
            this.buttonNewGetNFCIDFromSerial.Size = new System.Drawing.Size(163, 28);
            this.buttonNewGetNFCIDFromSerial.TabIndex = 13;
            this.buttonNewGetNFCIDFromSerial.Text = "Get From Serial";
            this.buttonNewGetNFCIDFromSerial.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "label5 new User";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 187);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "NFCID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 92);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "aNaam";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 60);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "vNaam";
            // 
            // textBoxNewVNaam
            // 
            this.textBoxNewVNaam.Location = new System.Drawing.Point(88, 57);
            this.textBoxNewVNaam.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNewVNaam.Name = "textBoxNewVNaam";
            this.textBoxNewVNaam.Size = new System.Drawing.Size(161, 22);
            this.textBoxNewVNaam.TabIndex = 8;
            // 
            // textBoxNewANaam
            // 
            this.textBoxNewANaam.Location = new System.Drawing.Point(88, 89);
            this.textBoxNewANaam.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNewANaam.Name = "textBoxNewANaam";
            this.textBoxNewANaam.Size = new System.Drawing.Size(161, 22);
            this.textBoxNewANaam.TabIndex = 6;
            // 
            // textBoxNewNFCID
            // 
            this.textBoxNewNFCID.Location = new System.Drawing.Point(88, 183);
            this.textBoxNewNFCID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNewNFCID.Name = "textBoxNewNFCID";
            this.textBoxNewNFCID.Size = new System.Drawing.Size(161, 22);
            this.textBoxNewNFCID.TabIndex = 7;
            // 
            // textBoxUpdateID
            // 
            this.textBoxUpdateID.Enabled = false;
            this.textBoxUpdateID.Location = new System.Drawing.Point(88, 50);
            this.textBoxUpdateID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUpdateID.Name = "textBoxUpdateID";
            this.textBoxUpdateID.Size = new System.Drawing.Size(161, 22);
            this.textBoxUpdateID.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(261, 55);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "id";
            // 
            // MangeStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1284, 844);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonRefreshOverview);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MangeStudents";
            this.Text = "MangeStudents";
            this.Load += new System.EventHandler(this.MangeStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonRefreshOverview;
        private System.Windows.Forms.TextBox textBoxUpdateANaam;
        private System.Windows.Forms.TextBox textBoxUpdateNFCID;
        private System.Windows.Forms.TextBox textBoxUpdateVNaam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonUpdateGetNFCIDFromSerial;
        private System.Windows.Forms.CheckBox checkBoxUpdateIsVanSchoolAf;
        private System.Windows.Forms.Button buttonUpdateSaveUpdate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonNewClear;
        private System.Windows.Forms.Button buttonNewSave;
        private System.Windows.Forms.Button buttonNewGetNFCIDFromSerial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNewVNaam;
        private System.Windows.Forms.TextBox textBoxNewANaam;
        private System.Windows.Forms.TextBox textBoxNewNFCID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxUpdateID;
    }
}