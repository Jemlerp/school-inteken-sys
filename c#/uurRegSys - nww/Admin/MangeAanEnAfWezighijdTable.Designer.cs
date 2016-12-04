namespace Admin {
    partial class MangeAanEnAfWezighijdTable {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewEr = new System.Windows.Forms.DataGridView();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.panelaanwezigcontorls = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonAANUpdateDelete = new System.Windows.Forms.Button();
            this.checkBoxAANUpdateZetNietsOpUIteken = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxAANUpdateID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePickerAANUpdateDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxAANUpdateIsAanwezig = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerAANUpdateTimeUit = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerAANUpdateTimeIn = new System.Windows.Forms.DateTimePicker();
            this.textBoxAANUpdateUserID = new System.Windows.Forms.TextBox();
            this.buttonAANUpdateUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxAANNewZetNietsOpUitekene = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerAANNewDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxAANNewIsAanwezig = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePickerAANNewTimeUit = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePickerAANNewTimeIn = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAANNewUserID = new System.Windows.Forms.TextBox();
            this.buttonAANNewSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelafwezigControlls = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonAfNewSave = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.dateTimePickerAfNewDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxAFNewUserID = new System.Windows.Forms.TextBox();
            this.comboBoxAfNewRedenAfwezighijd = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxAfNewOmschrijvingafwezighijs = new System.Windows.Forms.TextBox();
            this.labelAfNewRedenAfwezig = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.buttonAfUpdateDelete = new System.Windows.Forms.Button();
            this.buttonAfUpdateUpdate = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dateTimePickerAFUpdateDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxAfUpdateUserID = new System.Windows.Forms.TextBox();
            this.textBoxAFUpdateID = new System.Windows.Forms.TextBox();
            this.comboBoxAFUpdateRedenAfdwezighijd = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxAFUpdateOmschrijving = new System.Windows.Forms.TextBox();
            this.labelAFUpdateOmschijvinf = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBoxUseAllBetweenDates = new System.Windows.Forms.CheckBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.panelaanwezigcontorls.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelafwezigControlls.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "AanwezighijdTable",
            "AfwezighTable"});
            this.listBox1.Location = new System.Drawing.Point(19, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(201, 64);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(19, 88);
            this.dateTimePicker1.MaxDate = new System.DateTime(4200, 4, 20, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2016, 3, 19, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(201, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dataGridViewEr
            // 
            this.dataGridViewEr.AllowUserToAddRows = false;
            this.dataGridViewEr.AllowUserToDeleteRows = false;
            this.dataGridViewEr.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewEr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEr.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewEr.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEr.MultiSelect = false;
            this.dataGridViewEr.Name = "dataGridViewEr";
            this.dataGridViewEr.ReadOnly = true;
            this.dataGridViewEr.RowHeadersVisible = false;
            this.dataGridViewEr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEr.ShowCellErrors = false;
            this.dataGridViewEr.ShowCellToolTips = false;
            this.dataGridViewEr.ShowEditingIcon = false;
            this.dataGridViewEr.Size = new System.Drawing.Size(601, 807);
            this.dataGridViewEr.TabIndex = 5;
            this.dataGridViewEr.SelectionChanged += new System.EventHandler(this.dataGridViewEr_SelectionChanged);
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.AllowUserToResizeColumns = false;
            this.dataGridViewUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewUsers.Location = new System.Drawing.Point(253, 0);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            this.dataGridViewUsers.RowHeadersVisible = false;
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.ShowCellErrors = false;
            this.dataGridViewUsers.ShowCellToolTips = false;
            this.dataGridViewUsers.Size = new System.Drawing.Size(327, 807);
            this.dataGridViewUsers.TabIndex = 6;
            this.dataGridViewUsers.SelectionChanged += new System.EventHandler(this.dataGridViewUsers_SelectionChanged);
            // 
            // panelaanwezigcontorls
            // 
            this.panelaanwezigcontorls.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelaanwezigcontorls.Controls.Add(this.panel3);
            this.panelaanwezigcontorls.Controls.Add(this.label1);
            this.panelaanwezigcontorls.Controls.Add(this.panel2);
            this.panelaanwezigcontorls.Location = new System.Drawing.Point(10, 204);
            this.panelaanwezigcontorls.Name = "panelaanwezigcontorls";
            this.panelaanwezigcontorls.Size = new System.Drawing.Size(237, 502);
            this.panelaanwezigcontorls.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Info;
            this.panel3.Controls.Add(this.buttonAANUpdateDelete);
            this.panel3.Controls.Add(this.checkBoxAANUpdateZetNietsOpUIteken);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.textBoxAANUpdateID);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.dateTimePickerAANUpdateDate);
            this.panel3.Controls.Add(this.checkBoxAANUpdateIsAanwezig);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.dateTimePickerAANUpdateTimeUit);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.dateTimePickerAANUpdateTimeIn);
            this.panel3.Controls.Add(this.textBoxAANUpdateUserID);
            this.panel3.Controls.Add(this.buttonAANUpdateUpdate);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(19, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 233);
            this.panel3.TabIndex = 2;
            // 
            // buttonAANUpdateDelete
            // 
            this.buttonAANUpdateDelete.Location = new System.Drawing.Point(147, 4);
            this.buttonAANUpdateDelete.Name = "buttonAANUpdateDelete";
            this.buttonAANUpdateDelete.Size = new System.Drawing.Size(50, 32);
            this.buttonAANUpdateDelete.TabIndex = 24;
            this.buttonAANUpdateDelete.Text = "Delete";
            this.buttonAANUpdateDelete.UseVisualStyleBackColor = true;
            this.buttonAANUpdateDelete.Click += new System.EventHandler(this.buttonAANUpdateDelete_Click);
            // 
            // checkBoxAANUpdateZetNietsOpUIteken
            // 
            this.checkBoxAANUpdateZetNietsOpUIteken.AutoSize = true;
            this.checkBoxAANUpdateZetNietsOpUIteken.Location = new System.Drawing.Point(62, 144);
            this.checkBoxAANUpdateZetNietsOpUIteken.Name = "checkBoxAANUpdateZetNietsOpUIteken";
            this.checkBoxAANUpdateZetNietsOpUIteken.Size = new System.Drawing.Size(64, 17);
            this.checkBoxAANUpdateZetNietsOpUIteken.TabIndex = 23;
            this.checkBoxAANUpdateZetNietsOpUIteken.Text = "zetNiets";
            this.checkBoxAANUpdateZetNietsOpUIteken.UseVisualStyleBackColor = true;
            this.checkBoxAANUpdateZetNietsOpUIteken.CheckedChanged += new System.EventHandler(this.checkBoxAANUpdateZetNietsOpUIteken_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(123, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "ID";
            // 
            // textBoxAANUpdateID
            // 
            this.textBoxAANUpdateID.Enabled = false;
            this.textBoxAANUpdateID.Location = new System.Drawing.Point(18, 20);
            this.textBoxAANUpdateID.Name = "textBoxAANUpdateID";
            this.textBoxAANUpdateID.Size = new System.Drawing.Size(100, 20);
            this.textBoxAANUpdateID.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Date";
            // 
            // dateTimePickerAANUpdateDate
            // 
            this.dateTimePickerAANUpdateDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerAANUpdateDate.Location = new System.Drawing.Point(18, 82);
            this.dateTimePickerAANUpdateDate.MaxDate = new System.DateTime(4200, 4, 20, 0, 0, 0, 0);
            this.dateTimePickerAANUpdateDate.MinDate = new System.DateTime(2016, 3, 19, 0, 0, 0, 0);
            this.dateTimePickerAANUpdateDate.Name = "dateTimePickerAANUpdateDate";
            this.dateTimePickerAANUpdateDate.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerAANUpdateDate.TabIndex = 19;
            // 
            // checkBoxAANUpdateIsAanwezig
            // 
            this.checkBoxAANUpdateIsAanwezig.AutoSize = true;
            this.checkBoxAANUpdateIsAanwezig.Location = new System.Drawing.Point(17, 191);
            this.checkBoxAANUpdateIsAanwezig.Name = "checkBoxAANUpdateIsAanwezig";
            this.checkBoxAANUpdateIsAanwezig.Size = new System.Drawing.Size(79, 17);
            this.checkBoxAANUpdateIsAanwezig.TabIndex = 18;
            this.checkBoxAANUpdateIsAanwezig.Text = "isAanwezig";
            this.checkBoxAANUpdateIsAanwezig.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Time uit";
            // 
            // dateTimePickerAANUpdateTimeUit
            // 
            this.dateTimePickerAANUpdateTimeUit.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerAANUpdateTimeUit.Location = new System.Drawing.Point(18, 161);
            this.dateTimePickerAANUpdateTimeUit.MaxDate = new System.DateTime(4200, 4, 20, 0, 0, 0, 0);
            this.dateTimePickerAANUpdateTimeUit.MinDate = new System.DateTime(2016, 3, 19, 0, 0, 0, 0);
            this.dateTimePickerAANUpdateTimeUit.Name = "dateTimePickerAANUpdateTimeUit";
            this.dateTimePickerAANUpdateTimeUit.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerAANUpdateTimeUit.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Time in";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "User ID";
            // 
            // dateTimePickerAANUpdateTimeIn
            // 
            this.dateTimePickerAANUpdateTimeIn.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerAANUpdateTimeIn.Location = new System.Drawing.Point(18, 121);
            this.dateTimePickerAANUpdateTimeIn.MaxDate = new System.DateTime(4200, 4, 20, 0, 0, 0, 0);
            this.dateTimePickerAANUpdateTimeIn.MinDate = new System.DateTime(2016, 3, 19, 0, 0, 0, 0);
            this.dateTimePickerAANUpdateTimeIn.Name = "dateTimePickerAANUpdateTimeIn";
            this.dateTimePickerAANUpdateTimeIn.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerAANUpdateTimeIn.TabIndex = 11;
            // 
            // textBoxAANUpdateUserID
            // 
            this.textBoxAANUpdateUserID.Location = new System.Drawing.Point(18, 42);
            this.textBoxAANUpdateUserID.Name = "textBoxAANUpdateUserID";
            this.textBoxAANUpdateUserID.Size = new System.Drawing.Size(100, 20);
            this.textBoxAANUpdateUserID.TabIndex = 3;
            // 
            // buttonAANUpdateUpdate
            // 
            this.buttonAANUpdateUpdate.Location = new System.Drawing.Point(109, 193);
            this.buttonAANUpdateUpdate.Name = "buttonAANUpdateUpdate";
            this.buttonAANUpdateUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonAANUpdateUpdate.TabIndex = 2;
            this.buttonAANUpdateUpdate.Text = "Update";
            this.buttonAANUpdateUpdate.UseVisualStyleBackColor = true;
            this.buttonAANUpdateUpdate.Click += new System.EventHandler(this.buttonAANUpdateUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Update entry";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "aanwezig controls";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.checkBoxAANNewZetNietsOpUitekene);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.dateTimePickerAANNewDate);
            this.panel2.Controls.Add(this.checkBoxAANNewIsAanwezig);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.dateTimePickerAANNewTimeUit);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.dateTimePickerAANNewTimeIn);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxAANNewUserID);
            this.panel2.Controls.Add(this.buttonAANNewSave);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(19, 255);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 232);
            this.panel2.TabIndex = 1;
            // 
            // checkBoxAANNewZetNietsOpUitekene
            // 
            this.checkBoxAANNewZetNietsOpUitekene.AutoSize = true;
            this.checkBoxAANNewZetNietsOpUitekene.Location = new System.Drawing.Point(65, 124);
            this.checkBoxAANNewZetNietsOpUitekene.Name = "checkBoxAANNewZetNietsOpUitekene";
            this.checkBoxAANNewZetNietsOpUitekene.Size = new System.Drawing.Size(64, 17);
            this.checkBoxAANNewZetNietsOpUitekene.TabIndex = 28;
            this.checkBoxAANNewZetNietsOpUitekene.Text = "zetNiets";
            this.checkBoxAANNewZetNietsOpUitekene.UseVisualStyleBackColor = true;
            this.checkBoxAANNewZetNietsOpUitekene.CheckedChanged += new System.EventHandler(this.checkBoxAANNewZetNietsOpUitekene_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Date";
            // 
            // dateTimePickerAANNewDate
            // 
            this.dateTimePickerAANNewDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerAANNewDate.Location = new System.Drawing.Point(18, 62);
            this.dateTimePickerAANNewDate.MaxDate = new System.DateTime(4200, 4, 20, 0, 0, 0, 0);
            this.dateTimePickerAANNewDate.MinDate = new System.DateTime(2016, 3, 19, 0, 0, 0, 0);
            this.dateTimePickerAANNewDate.Name = "dateTimePickerAANNewDate";
            this.dateTimePickerAANNewDate.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerAANNewDate.TabIndex = 26;
            // 
            // checkBoxAANNewIsAanwezig
            // 
            this.checkBoxAANNewIsAanwezig.AutoSize = true;
            this.checkBoxAANNewIsAanwezig.Location = new System.Drawing.Point(18, 171);
            this.checkBoxAANNewIsAanwezig.Name = "checkBoxAANNewIsAanwezig";
            this.checkBoxAANNewIsAanwezig.Size = new System.Drawing.Size(79, 17);
            this.checkBoxAANNewIsAanwezig.TabIndex = 25;
            this.checkBoxAANNewIsAanwezig.Text = "isAanwezig";
            this.checkBoxAANNewIsAanwezig.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Time uit";
            // 
            // dateTimePickerAANNewTimeUit
            // 
            this.dateTimePickerAANNewTimeUit.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerAANNewTimeUit.Location = new System.Drawing.Point(18, 141);
            this.dateTimePickerAANNewTimeUit.MaxDate = new System.DateTime(4200, 4, 20, 0, 0, 0, 0);
            this.dateTimePickerAANNewTimeUit.MinDate = new System.DateTime(2016, 3, 19, 0, 0, 0, 0);
            this.dateTimePickerAANNewTimeUit.Name = "dateTimePickerAANNewTimeUit";
            this.dateTimePickerAANNewTimeUit.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerAANNewTimeUit.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Time in";
            // 
            // dateTimePickerAANNewTimeIn
            // 
            this.dateTimePickerAANNewTimeIn.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerAANNewTimeIn.Location = new System.Drawing.Point(18, 101);
            this.dateTimePickerAANNewTimeIn.MaxDate = new System.DateTime(4200, 4, 20, 0, 0, 0, 0);
            this.dateTimePickerAANNewTimeIn.MinDate = new System.DateTime(2016, 3, 19, 0, 0, 0, 0);
            this.dateTimePickerAANNewTimeIn.Name = "dateTimePickerAANNewTimeIn";
            this.dateTimePickerAANNewTimeIn.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerAANNewTimeIn.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "User ID";
            // 
            // textBoxAANNewUserID
            // 
            this.textBoxAANNewUserID.Location = new System.Drawing.Point(18, 25);
            this.textBoxAANNewUserID.Name = "textBoxAANNewUserID";
            this.textBoxAANNewUserID.Size = new System.Drawing.Size(100, 20);
            this.textBoxAANNewUserID.TabIndex = 11;
            // 
            // buttonAANNewSave
            // 
            this.buttonAANNewSave.Location = new System.Drawing.Point(108, 197);
            this.buttonAANNewSave.Name = "buttonAANNewSave";
            this.buttonAANNewSave.Size = new System.Drawing.Size(75, 23);
            this.buttonAANNewSave.TabIndex = 1;
            this.buttonAANNewSave.Text = "Save";
            this.buttonAANNewSave.UseVisualStyleBackColor = true;
            this.buttonAANNewSave.Click += new System.EventHandler(this.buttonAANNewSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "new entry";
            // 
            // panelafwezigControlls
            // 
            this.panelafwezigControlls.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelafwezigControlls.Controls.Add(this.panel6);
            this.panelafwezigControlls.Controls.Add(this.label2);
            this.panelafwezigControlls.Controls.Add(this.panel5);
            this.panelafwezigControlls.Location = new System.Drawing.Point(10, 204);
            this.panelafwezigControlls.Name = "panelafwezigControlls";
            this.panelafwezigControlls.Size = new System.Drawing.Size(237, 502);
            this.panelafwezigControlls.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Info;
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.buttonAfNewSave);
            this.panel6.Controls.Add(this.label21);
            this.panel6.Controls.Add(this.dateTimePickerAfNewDate);
            this.panel6.Controls.Add(this.textBoxAFNewUserID);
            this.panel6.Controls.Add(this.comboBoxAfNewRedenAfwezighijd);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.textBoxAfNewOmschrijvingafwezighijs);
            this.panel6.Controls.Add(this.labelAfNewRedenAfwezig);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Location = new System.Drawing.Point(19, 264);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 223);
            this.panel6.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(15, 46);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "date";
            // 
            // buttonAfNewSave
            // 
            this.buttonAfNewSave.Location = new System.Drawing.Point(109, 184);
            this.buttonAfNewSave.Name = "buttonAfNewSave";
            this.buttonAfNewSave.Size = new System.Drawing.Size(75, 23);
            this.buttonAfNewSave.TabIndex = 32;
            this.buttonAfNewSave.Text = "Save";
            this.buttonAfNewSave.UseVisualStyleBackColor = true;
            this.buttonAfNewSave.Click += new System.EventHandler(this.buttonAfNewSave_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(123, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 31;
            this.label21.Text = "User ID";
            // 
            // dateTimePickerAfNewDate
            // 
            this.dateTimePickerAfNewDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerAfNewDate.Location = new System.Drawing.Point(18, 62);
            this.dateTimePickerAfNewDate.MaxDate = new System.DateTime(4200, 4, 20, 0, 0, 0, 0);
            this.dateTimePickerAfNewDate.MinDate = new System.DateTime(2016, 3, 19, 0, 0, 0, 0);
            this.dateTimePickerAfNewDate.Name = "dateTimePickerAfNewDate";
            this.dateTimePickerAfNewDate.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerAfNewDate.TabIndex = 30;
            // 
            // textBoxAFNewUserID
            // 
            this.textBoxAFNewUserID.Location = new System.Drawing.Point(18, 21);
            this.textBoxAFNewUserID.Name = "textBoxAFNewUserID";
            this.textBoxAFNewUserID.Size = new System.Drawing.Size(100, 20);
            this.textBoxAFNewUserID.TabIndex = 29;
            // 
            // comboBoxAfNewRedenAfwezighijd
            // 
            this.comboBoxAfNewRedenAfwezighijd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAfNewRedenAfwezighijd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAfNewRedenAfwezighijd.FormattingEnabled = true;
            this.comboBoxAfNewRedenAfwezighijd.Items.AddRange(new object[] {
            "Niets",
            "Ziek",
            "StudieVerlof",
            "FlexibelVerlof",
            "Excursie",
            "Anders",
            "Laat"});
            this.comboBoxAfNewRedenAfwezighijd.Location = new System.Drawing.Point(18, 100);
            this.comboBoxAfNewRedenAfwezighijd.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxAfNewRedenAfwezighijd.Name = "comboBoxAfNewRedenAfwezighijd";
            this.comboBoxAfNewRedenAfwezighijd.Size = new System.Drawing.Size(154, 23);
            this.comboBoxAfNewRedenAfwezighijd.TabIndex = 25;
            this.comboBoxAfNewRedenAfwezighijd.SelectedIndexChanged += new System.EventHandler(this.comboBoxAfNewRedenAfwezighijd_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(15, 85);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 13);
            this.label17.TabIndex = 28;
            this.label17.Text = "Reden Van Afwezighijd";
            // 
            // textBoxAfNewOmschrijvingafwezighijs
            // 
            this.textBoxAfNewOmschrijvingafwezighijs.Enabled = false;
            this.textBoxAfNewOmschrijvingafwezighijs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAfNewOmschrijvingafwezighijs.Location = new System.Drawing.Point(18, 139);
            this.textBoxAfNewOmschrijvingafwezighijs.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAfNewOmschrijvingafwezighijs.Multiline = true;
            this.textBoxAfNewOmschrijvingafwezighijs.Name = "textBoxAfNewOmschrijvingafwezighijs";
            this.textBoxAfNewOmschrijvingafwezighijs.Size = new System.Drawing.Size(154, 40);
            this.textBoxAfNewOmschrijvingafwezighijs.TabIndex = 26;
            // 
            // labelAfNewRedenAfwezig
            // 
            this.labelAfNewRedenAfwezig.AutoSize = true;
            this.labelAfNewRedenAfwezig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAfNewRedenAfwezig.Location = new System.Drawing.Point(15, 125);
            this.labelAfNewRedenAfwezig.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAfNewRedenAfwezig.Name = "labelAfNewRedenAfwezig";
            this.labelAfNewRedenAfwezig.Size = new System.Drawing.Size(62, 13);
            this.labelAfNewRedenAfwezig.TabIndex = 27;
            this.labelAfNewRedenAfwezig.Text = "omschijving";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "New Entry";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "afwezig controls";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Info;
            this.panel5.Controls.Add(this.label22);
            this.panel5.Controls.Add(this.buttonAfUpdateDelete);
            this.panel5.Controls.Add(this.buttonAfUpdateUpdate);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.dateTimePickerAFUpdateDate);
            this.panel5.Controls.Add(this.textBoxAfUpdateUserID);
            this.panel5.Controls.Add(this.textBoxAFUpdateID);
            this.panel5.Controls.Add(this.comboBoxAFUpdateRedenAfdwezighijd);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.textBoxAFUpdateOmschrijving);
            this.panel5.Controls.Add(this.labelAFUpdateOmschijvinf);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Location = new System.Drawing.Point(19, 16);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 242);
            this.panel5.TabIndex = 1;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(14, 66);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(28, 13);
            this.label22.TabIndex = 34;
            this.label22.Text = "date";
            // 
            // buttonAfUpdateDelete
            // 
            this.buttonAfUpdateDelete.Location = new System.Drawing.Point(147, 4);
            this.buttonAfUpdateDelete.Name = "buttonAfUpdateDelete";
            this.buttonAfUpdateDelete.Size = new System.Drawing.Size(50, 32);
            this.buttonAfUpdateDelete.TabIndex = 25;
            this.buttonAfUpdateDelete.Text = "Delete";
            this.buttonAfUpdateDelete.UseVisualStyleBackColor = true;
            this.buttonAfUpdateDelete.Click += new System.EventHandler(this.buttonAfUpdateDelete_Click);
            // 
            // buttonAfUpdateUpdate
            // 
            this.buttonAfUpdateUpdate.Location = new System.Drawing.Point(109, 206);
            this.buttonAfUpdateUpdate.Name = "buttonAfUpdateUpdate";
            this.buttonAfUpdateUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonAfUpdateUpdate.TabIndex = 33;
            this.buttonAfUpdateUpdate.Text = "Update";
            this.buttonAfUpdateUpdate.UseVisualStyleBackColor = true;
            this.buttonAfUpdateUpdate.Click += new System.EventHandler(this.buttonAfUpdateUpdate_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(121, 45);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 13);
            this.label20.TabIndex = 29;
            this.label20.Text = "User ID";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(123, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 13);
            this.label19.TabIndex = 28;
            this.label19.Text = "ID";
            // 
            // dateTimePickerAFUpdateDate
            // 
            this.dateTimePickerAFUpdateDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerAFUpdateDate.Location = new System.Drawing.Point(18, 82);
            this.dateTimePickerAFUpdateDate.MaxDate = new System.DateTime(4200, 4, 20, 0, 0, 0, 0);
            this.dateTimePickerAFUpdateDate.MinDate = new System.DateTime(2016, 3, 19, 0, 0, 0, 0);
            this.dateTimePickerAFUpdateDate.Name = "dateTimePickerAFUpdateDate";
            this.dateTimePickerAFUpdateDate.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerAFUpdateDate.TabIndex = 27;
            // 
            // textBoxAfUpdateUserID
            // 
            this.textBoxAfUpdateUserID.Location = new System.Drawing.Point(18, 42);
            this.textBoxAfUpdateUserID.Name = "textBoxAfUpdateUserID";
            this.textBoxAfUpdateUserID.Size = new System.Drawing.Size(100, 20);
            this.textBoxAfUpdateUserID.TabIndex = 26;
            // 
            // textBoxAFUpdateID
            // 
            this.textBoxAFUpdateID.Enabled = false;
            this.textBoxAFUpdateID.Location = new System.Drawing.Point(18, 20);
            this.textBoxAFUpdateID.Name = "textBoxAFUpdateID";
            this.textBoxAFUpdateID.Size = new System.Drawing.Size(100, 20);
            this.textBoxAFUpdateID.TabIndex = 25;
            // 
            // comboBoxAFUpdateRedenAfdwezighijd
            // 
            this.comboBoxAFUpdateRedenAfdwezighijd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAFUpdateRedenAfdwezighijd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAFUpdateRedenAfdwezighijd.FormattingEnabled = true;
            this.comboBoxAFUpdateRedenAfdwezighijd.Items.AddRange(new object[] {
            "Niets",
            "Ziek",
            "StudieVerlof",
            "FlexibelVerlof",
            "Excursie",
            "Anders",
            "Laat"});
            this.comboBoxAFUpdateRedenAfdwezighijd.Location = new System.Drawing.Point(18, 120);
            this.comboBoxAFUpdateRedenAfdwezighijd.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxAFUpdateRedenAfdwezighijd.Name = "comboBoxAFUpdateRedenAfdwezighijd";
            this.comboBoxAFUpdateRedenAfdwezighijd.Size = new System.Drawing.Size(154, 23);
            this.comboBoxAFUpdateRedenAfdwezighijd.TabIndex = 21;
            this.comboBoxAFUpdateRedenAfdwezighijd.SelectedIndexChanged += new System.EventHandler(this.comboBoxAfNewRedenAfwezighijd_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(14, 105);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Reden Van Afwezighijd";
            // 
            // textBoxAFUpdateOmschrijving
            // 
            this.textBoxAFUpdateOmschrijving.Enabled = false;
            this.textBoxAFUpdateOmschrijving.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAFUpdateOmschrijving.Location = new System.Drawing.Point(18, 161);
            this.textBoxAFUpdateOmschrijving.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAFUpdateOmschrijving.Multiline = true;
            this.textBoxAFUpdateOmschrijving.Name = "textBoxAFUpdateOmschrijving";
            this.textBoxAFUpdateOmschrijving.Size = new System.Drawing.Size(154, 40);
            this.textBoxAFUpdateOmschrijving.TabIndex = 22;
            // 
            // labelAFUpdateOmschijvinf
            // 
            this.labelAFUpdateOmschijvinf.AutoSize = true;
            this.labelAFUpdateOmschijvinf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAFUpdateOmschijvinf.Location = new System.Drawing.Point(15, 145);
            this.labelAFUpdateOmschijvinf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAFUpdateOmschijvinf.Name = "labelAFUpdateOmschijvinf";
            this.labelAFUpdateOmschijvinf.Size = new System.Drawing.Size(62, 13);
            this.labelAFUpdateOmschijvinf.TabIndex = 23;
            this.labelAFUpdateOmschijvinf.Text = "omschijving";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Update Entry";
            // 
            // checkBoxUseAllBetweenDates
            // 
            this.checkBoxUseAllBetweenDates.AutoSize = true;
            this.checkBoxUseAllBetweenDates.Location = new System.Drawing.Point(19, 114);
            this.checkBoxUseAllBetweenDates.Name = "checkBoxUseAllBetweenDates";
            this.checkBoxUseAllBetweenDates.Size = new System.Drawing.Size(76, 17);
            this.checkBoxUseAllBetweenDates.TabIndex = 9;
            this.checkBoxUseAllBetweenDates.Text = "gebruik tot";
            this.checkBoxUseAllBetweenDates.UseVisualStyleBackColor = true;
            this.checkBoxUseAllBetweenDates.CheckedChanged += new System.EventHandler(this.checkBoxUseAllBetweenDates_CheckedChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(19, 137);
            this.dateTimePicker2.MaxDate = new System.DateTime(4200, 4, 20, 0, 0, 0, 0);
            this.dateTimePicker2.MinDate = new System.DateTime(2016, 3, 19, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(201, 20);
            this.dateTimePicker2.TabIndex = 10;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewUsers);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panelafwezigControlls);
            this.panel1.Controls.Add(this.panelaanwezigcontorls);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(615, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 807);
            this.panel1.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Info;
            this.panel4.Controls.Add(this.listBox1);
            this.panel4.Controls.Add(this.dateTimePicker1);
            this.panel4.Controls.Add(this.checkBoxUseAllBetweenDates);
            this.panel4.Controls.Add(this.dateTimePicker2);
            this.panel4.Location = new System.Drawing.Point(10, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(247, 174);
            this.panel4.TabIndex = 11;
            // 
            // MangeAanEnAfWezighijdTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 807);
            this.Controls.Add(this.dataGridViewEr);
            this.Controls.Add(this.panel1);
            this.Name = "MangeAanEnAfWezighijdTable";
            this.Text = "MangeAanEnAfWezighijdTable";
            this.Load += new System.EventHandler(this.MangeAanEnAfWezighijdTable_Load);
            this.Resize += new System.EventHandler(this.MangeAanEnAfWezighijdTable_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.panelaanwezigcontorls.ResumeLayout(false);
            this.panelaanwezigcontorls.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelafwezigControlls.ResumeLayout(false);
            this.panelafwezigControlls.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridViewEr;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Panel panelaanwezigcontorls;
        private System.Windows.Forms.Panel panelafwezigControlls;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxUseAllBetweenDates;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAANUpdateUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAANNewSave;
        private System.Windows.Forms.DateTimePicker dateTimePickerAANUpdateTimeIn;
        private System.Windows.Forms.TextBox textBoxAANUpdateUserID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAANNewUserID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerAANUpdateTimeUit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxAANUpdateIsAanwezig;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePickerAANUpdateDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerAANNewDate;
        private System.Windows.Forms.CheckBox checkBoxAANNewIsAanwezig;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePickerAANNewTimeUit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePickerAANNewTimeIn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxAANUpdateID;
        private System.Windows.Forms.CheckBox checkBoxAANUpdateZetNietsOpUIteken;
        private System.Windows.Forms.CheckBox checkBoxAANNewZetNietsOpUitekene;
        private System.Windows.Forms.Button buttonAANUpdateDelete;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dateTimePickerAfNewDate;
        private System.Windows.Forms.TextBox textBoxAFNewUserID;
        private System.Windows.Forms.ComboBox comboBoxAfNewRedenAfwezighijd;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxAfNewOmschrijvingafwezighijs;
        private System.Windows.Forms.Label labelAfNewRedenAfwezig;
        private System.Windows.Forms.DateTimePicker dateTimePickerAFUpdateDate;
        private System.Windows.Forms.TextBox textBoxAfUpdateUserID;
        private System.Windows.Forms.TextBox textBoxAFUpdateID;
        private System.Windows.Forms.ComboBox comboBoxAFUpdateRedenAfdwezighijd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxAFUpdateOmschrijving;
        private System.Windows.Forms.Label labelAFUpdateOmschijvinf;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button buttonAfNewSave;
        private System.Windows.Forms.Button buttonAfUpdateDelete;
        private System.Windows.Forms.Button buttonAfUpdateUpdate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label22;
    }
}