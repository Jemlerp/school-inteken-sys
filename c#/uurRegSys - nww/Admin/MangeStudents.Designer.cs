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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonRefreshOverview = new System.Windows.Forms.Button();
            this.textBoxUpdateANaam = new System.Windows.Forms.TextBox();
            this.textBoxUpdateNFCID = new System.Windows.Forms.TextBox();
            this.textBoxUpdateVNaam = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxUpdateID = new System.Windows.Forms.TextBox();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.Size = new System.Drawing.Size(567, 686);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // buttonRefreshOverview
            // 
            this.buttonRefreshOverview.Location = new System.Drawing.Point(573, 12);
            this.buttonRefreshOverview.Name = "buttonRefreshOverview";
            this.buttonRefreshOverview.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshOverview.TabIndex = 5;
            this.buttonRefreshOverview.Text = "refresh";
            this.buttonRefreshOverview.UseVisualStyleBackColor = true;
            this.buttonRefreshOverview.Click += new System.EventHandler(this.buttonRefreshOverview_Click);
            // 
            // textBoxUpdateANaam
            // 
            this.textBoxUpdateANaam.Location = new System.Drawing.Point(66, 91);
            this.textBoxUpdateANaam.Name = "textBoxUpdateANaam";
            this.textBoxUpdateANaam.Size = new System.Drawing.Size(122, 20);
            this.textBoxUpdateANaam.TabIndex = 6;
            // 
            // textBoxUpdateNFCID
            // 
            this.textBoxUpdateNFCID.Location = new System.Drawing.Point(66, 157);
            this.textBoxUpdateNFCID.Name = "textBoxUpdateNFCID";
            this.textBoxUpdateNFCID.Size = new System.Drawing.Size(122, 20);
            this.textBoxUpdateNFCID.TabIndex = 7;
            // 
            // textBoxUpdateVNaam
            // 
            this.textBoxUpdateVNaam.Location = new System.Drawing.Point(66, 65);
            this.textBoxUpdateVNaam.Name = "textBoxUpdateVNaam";
            this.textBoxUpdateVNaam.Size = new System.Drawing.Size(122, 20);
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
            this.panel1.Location = new System.Drawing.Point(601, 372);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 264);
            this.panel1.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(196, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "id";
            // 
            // textBoxUpdateID
            // 
            this.textBoxUpdateID.Enabled = false;
            this.textBoxUpdateID.Location = new System.Drawing.Point(66, 41);
            this.textBoxUpdateID.Name = "textBoxUpdateID";
            this.textBoxUpdateID.Size = new System.Drawing.Size(122, 20);
            this.textBoxUpdateID.TabIndex = 25;
            // 
            // checkBoxUpdateIsVanSchoolAf
            // 
            this.checkBoxUpdateIsVanSchoolAf.AutoSize = true;
            this.checkBoxUpdateIsVanSchoolAf.Location = new System.Drawing.Point(96, 17);
            this.checkBoxUpdateIsVanSchoolAf.Name = "checkBoxUpdateIsVanSchoolAf";
            this.checkBoxUpdateIsVanSchoolAf.Size = new System.Drawing.Size(95, 17);
            this.checkBoxUpdateIsVanSchoolAf.TabIndex = 24;
            this.checkBoxUpdateIsVanSchoolAf.Text = "isVanSchoolAf";
            this.checkBoxUpdateIsVanSchoolAf.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateSaveUpdate
            // 
            this.buttonUpdateSaveUpdate.Location = new System.Drawing.Point(19, 196);
            this.buttonUpdateSaveUpdate.Name = "buttonUpdateSaveUpdate";
            this.buttonUpdateSaveUpdate.Size = new System.Drawing.Size(80, 33);
            this.buttonUpdateSaveUpdate.TabIndex = 22;
            this.buttonUpdateSaveUpdate.Text = "Update";
            this.buttonUpdateSaveUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdateSaveUpdate.Click += new System.EventHandler(this.buttonUpdateSaveUpdate_Click);
            // 
            // buttonUpdateGetNFCIDFromSerial
            // 
            this.buttonUpdateGetNFCIDFromSerial.Location = new System.Drawing.Point(66, 128);
            this.buttonUpdateGetNFCIDFromSerial.Name = "buttonUpdateGetNFCIDFromSerial";
            this.buttonUpdateGetNFCIDFromSerial.Size = new System.Drawing.Size(122, 23);
            this.buttonUpdateGetNFCIDFromSerial.TabIndex = 13;
            this.buttonUpdateGetNFCIDFromSerial.Text = "Get From Serial";
            this.buttonUpdateGetNFCIDFromSerial.UseVisualStyleBackColor = true;
            this.buttonUpdateGetNFCIDFromSerial.Click += new System.EventHandler(this.buttonUpdateGetNFCIDFromSerial_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1  edit panle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "NFCID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "aNaam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
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
            this.panel2.Location = new System.Drawing.Point(601, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 264);
            this.panel2.TabIndex = 10;
            // 
            // buttonNewClear
            // 
            this.buttonNewClear.Location = new System.Drawing.Point(153, 196);
            this.buttonNewClear.Name = "buttonNewClear";
            this.buttonNewClear.Size = new System.Drawing.Size(80, 33);
            this.buttonNewClear.TabIndex = 23;
            this.buttonNewClear.Text = "Clear";
            this.buttonNewClear.UseVisualStyleBackColor = true;
            // 
            // buttonNewSave
            // 
            this.buttonNewSave.Location = new System.Drawing.Point(19, 196);
            this.buttonNewSave.Name = "buttonNewSave";
            this.buttonNewSave.Size = new System.Drawing.Size(80, 33);
            this.buttonNewSave.TabIndex = 22;
            this.buttonNewSave.Text = "Save";
            this.buttonNewSave.UseVisualStyleBackColor = true;
            this.buttonNewSave.Click += new System.EventHandler(this.buttonNewSave_Click);
            // 
            // buttonNewGetNFCIDFromSerial
            // 
            this.buttonNewGetNFCIDFromSerial.Location = new System.Drawing.Point(66, 120);
            this.buttonNewGetNFCIDFromSerial.Name = "buttonNewGetNFCIDFromSerial";
            this.buttonNewGetNFCIDFromSerial.Size = new System.Drawing.Size(122, 23);
            this.buttonNewGetNFCIDFromSerial.TabIndex = 13;
            this.buttonNewGetNFCIDFromSerial.Text = "Get From Serial";
            this.buttonNewGetNFCIDFromSerial.UseVisualStyleBackColor = true;
            this.buttonNewGetNFCIDFromSerial.Click += new System.EventHandler(this.buttonNewGetNFCIDFromSerial_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "label5 new User";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "NFCID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "aNaam";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(195, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "vNaam";
            // 
            // textBoxNewVNaam
            // 
            this.textBoxNewVNaam.Location = new System.Drawing.Point(66, 46);
            this.textBoxNewVNaam.Name = "textBoxNewVNaam";
            this.textBoxNewVNaam.Size = new System.Drawing.Size(122, 20);
            this.textBoxNewVNaam.TabIndex = 8;
            // 
            // textBoxNewANaam
            // 
            this.textBoxNewANaam.Location = new System.Drawing.Point(66, 72);
            this.textBoxNewANaam.Name = "textBoxNewANaam";
            this.textBoxNewANaam.Size = new System.Drawing.Size(122, 20);
            this.textBoxNewANaam.TabIndex = 6;
            // 
            // textBoxNewNFCID
            // 
            this.textBoxNewNFCID.Location = new System.Drawing.Point(66, 149);
            this.textBoxNewNFCID.Name = "textBoxNewNFCID";
            this.textBoxNewNFCID.Size = new System.Drawing.Size(122, 20);
            this.textBoxNewNFCID.TabIndex = 7;
            // 
            // MangeStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(963, 686);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonRefreshOverview);
            this.Controls.Add(this.dataGridView1);
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