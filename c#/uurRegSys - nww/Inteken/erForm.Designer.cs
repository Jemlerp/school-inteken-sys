namespace Inteken {
    partial class erForm {
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
            this.textBoxZoekOp = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelOmschrijving = new System.Windows.Forms.Label();
            this.textBoxOmschrijving = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelAchterNaam = new System.Windows.Forms.Label();
            this.labelVoorNaam = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAnuleeruiteken = new System.Windows.Forms.Button();
            this.buttonTekenIn = new System.Windows.Forms.Button();
            this.buttonTekenUit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxZoekOp
            // 
            this.textBoxZoekOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZoekOp.Location = new System.Drawing.Point(573, 74);
            this.textBoxZoekOp.Name = "textBoxZoekOp";
            this.textBoxZoekOp.Size = new System.Drawing.Size(100, 26);
            this.textBoxZoekOp.TabIndex = 0;
            this.textBoxZoekOp.TextChanged += new System.EventHandler(this.textBoxZoekOp_TextChanged);
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
            this.dataGridView1.Size = new System.Drawing.Size(567, 641);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(568, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Zoek Op";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(584, 594);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label ping response from server";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(572, 10);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(93, 39);
            this.buttonRefresh.TabIndex = 8;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // labelOmschrijving
            // 
            this.labelOmschrijving.AutoSize = true;
            this.labelOmschrijving.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOmschrijving.Location = new System.Drawing.Point(12, 66);
            this.labelOmschrijving.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOmschrijving.Name = "labelOmschrijving";
            this.labelOmschrijving.Size = new System.Drawing.Size(86, 18);
            this.labelOmschrijving.TabIndex = 14;
            this.labelOmschrijving.Text = "omschijving";
            this.labelOmschrijving.Visible = false;
            // 
            // textBoxOmschrijving
            // 
            this.textBoxOmschrijving.Enabled = false;
            this.textBoxOmschrijving.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOmschrijving.Location = new System.Drawing.Point(15, 86);
            this.textBoxOmschrijving.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxOmschrijving.Multiline = true;
            this.textBoxOmschrijving.Name = "textBoxOmschrijving";
            this.textBoxOmschrijving.Size = new System.Drawing.Size(224, 70);
            this.textBoxOmschrijving.TabIndex = 13;
            this.textBoxOmschrijving.Visible = false;
            this.textBoxOmschrijving.TextChanged += new System.EventHandler(this.textBoxOmschrijving_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(15, 162);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 54);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Niets",
            "Ziek",
            "StudieVerlof",
            "FlexibelVerlof",
            "Excursie",
            "Anders",
            "Laat"});
            this.comboBox1.Location = new System.Drawing.Point(15, 27);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(224, 37);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelAchterNaam
            // 
            this.labelAchterNaam.AutoSize = true;
            this.labelAchterNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAchterNaam.Location = new System.Drawing.Point(116, 43);
            this.labelAchterNaam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAchterNaam.Name = "labelAchterNaam";
            this.labelAchterNaam.Size = new System.Drawing.Size(70, 25);
            this.labelAchterNaam.TabIndex = 15;
            this.labelAchterNaam.Text = "label5";
            // 
            // labelVoorNaam
            // 
            this.labelVoorNaam.AutoSize = true;
            this.labelVoorNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVoorNaam.Location = new System.Drawing.Point(116, 13);
            this.labelVoorNaam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVoorNaam.Name = "labelVoorNaam";
            this.labelVoorNaam.Size = new System.Drawing.Size(70, 25);
            this.labelVoorNaam.TabIndex = 16;
            this.labelVoorNaam.Text = "label6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Voornaam";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Achternaam";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelAchterNaam);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labelVoorNaam);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(573, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 363);
            this.panel1.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Info;
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.buttonSave);
            this.panel3.Controls.Add(this.textBoxOmschrijving);
            this.panel3.Controls.Add(this.labelOmschrijving);
            this.panel3.Location = new System.Drawing.Point(14, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 252);
            this.panel3.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "Reden Van Afwezighijd";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.buttonAnuleeruiteken);
            this.panel2.Controls.Add(this.buttonTekenIn);
            this.panel2.Controls.Add(this.buttonTekenUit);
            this.panel2.Location = new System.Drawing.Point(280, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(143, 252);
            this.panel2.TabIndex = 19;
            // 
            // buttonAnuleeruiteken
            // 
            this.buttonAnuleeruiteken.Enabled = false;
            this.buttonAnuleeruiteken.Location = new System.Drawing.Point(17, 167);
            this.buttonAnuleeruiteken.Name = "buttonAnuleeruiteken";
            this.buttonAnuleeruiteken.Size = new System.Drawing.Size(106, 71);
            this.buttonAnuleeruiteken.TabIndex = 2;
            this.buttonAnuleeruiteken.Text = "Anuleer Uit Teken";
            this.buttonAnuleeruiteken.UseVisualStyleBackColor = true;
            this.buttonAnuleeruiteken.Click += new System.EventHandler(this.buttonTekenInOFUit_Click);
            // 
            // buttonTekenIn
            // 
            this.buttonTekenIn.Enabled = false;
            this.buttonTekenIn.Location = new System.Drawing.Point(17, 13);
            this.buttonTekenIn.Name = "buttonTekenIn";
            this.buttonTekenIn.Size = new System.Drawing.Size(106, 71);
            this.buttonTekenIn.TabIndex = 1;
            this.buttonTekenIn.Text = "Teken in";
            this.buttonTekenIn.UseVisualStyleBackColor = true;
            this.buttonTekenIn.Click += new System.EventHandler(this.buttonTekenInOFUit_Click);
            // 
            // buttonTekenUit
            // 
            this.buttonTekenUit.Location = new System.Drawing.Point(17, 90);
            this.buttonTekenUit.Name = "buttonTekenUit";
            this.buttonTekenUit.Size = new System.Drawing.Size(106, 71);
            this.buttonTekenUit.TabIndex = 0;
            this.buttonTekenUit.Text = "Teken uit";
            this.buttonTekenUit.UseVisualStyleBackColor = true;
            this.buttonTekenUit.Click += new System.EventHandler(this.buttonTekenInOFUit_Click);
            // 
            // erForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1073, 641);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxZoekOp);
            this.Name = "erForm";
            this.Text = "shindemasu";
            this.Load += new System.EventHandler(this.erForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxZoekOp;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelOmschrijving;
        private System.Windows.Forms.TextBox textBoxOmschrijving;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelAchterNaam;
        private System.Windows.Forms.Label labelVoorNaam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonTekenIn;
        private System.Windows.Forms.Button buttonTekenUit;
        private System.Windows.Forms.Button buttonAnuleeruiteken;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
    }
}