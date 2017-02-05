namespace MakeChangesToDB {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.textBox_ServerAddress = new System.Windows.Forms.TextBox();
            this.label_ServerAddress = new System.Windows.Forms.Label();
            this.Button_Refresh = new System.Windows.Forms.Button();
            this.panel_Refresh = new System.Windows.Forms.Panel();
            this.panel_ListView = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel_ListView_Search = new System.Windows.Forms.Panel();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.label_Search = new System.Windows.Forms.Label();
            this.button_DeleteEntry = new System.Windows.Forms.Button();
            this.panel_EntryInfo = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button_SetNewProfileImage = new System.Windows.Forms.Button();
            this.button_SaveChanges = new System.Windows.Forms.Button();
            this.button_CancelChanges = new System.Windows.Forms.Button();
            this.textBox_Achternaam = new System.Windows.Forms.TextBox();
            this.textBox_Voornaam = new System.Windows.Forms.TextBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label_achternaam = new System.Windows.Forms.Label();
            this.label_Voornaam = new System.Windows.Forms.Label();
            this.label_ID = new System.Windows.Forms.Label();
            this.label_ProfileImage = new System.Windows.Forms.Label();
            this.pictureBox_ProfileImage = new System.Windows.Forms.PictureBox();
            this.panel_Tools = new System.Windows.Forms.Panel();
            this.button_EditEntry = new System.Windows.Forms.Button();
            this.button_NewEntry = new System.Windows.Forms.Button();
            this.panel_Refresh.SuspendLayout();
            this.panel_ListView.SuspendLayout();
            this.panel_ListView_Search.SuspendLayout();
            this.panel_EntryInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProfileImage)).BeginInit();
            this.panel_Tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_ServerAddress
            // 
            this.textBox_ServerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ServerAddress.Location = new System.Drawing.Point(106, 5);
            this.textBox_ServerAddress.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ServerAddress.Name = "textBox_ServerAddress";
            this.textBox_ServerAddress.Size = new System.Drawing.Size(154, 23);
            this.textBox_ServerAddress.TabIndex = 3;
            // 
            // label_ServerAddress
            // 
            this.label_ServerAddress.AutoSize = true;
            this.label_ServerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ServerAddress.Location = new System.Drawing.Point(6, 6);
            this.label_ServerAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ServerAddress.Name = "label_ServerAddress";
            this.label_ServerAddress.Size = new System.Drawing.Size(97, 17);
            this.label_ServerAddress.TabIndex = 4;
            this.label_ServerAddress.Text = "Server adress";
            // 
            // Button_Refresh
            // 
            this.Button_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Refresh.Location = new System.Drawing.Point(261, 3);
            this.Button_Refresh.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Refresh.Name = "Button_Refresh";
            this.Button_Refresh.Size = new System.Drawing.Size(72, 26);
            this.Button_Refresh.TabIndex = 5;
            this.Button_Refresh.Text = "Refresh";
            this.Button_Refresh.UseVisualStyleBackColor = true;
            this.Button_Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // panel_Refresh
            // 
            this.panel_Refresh.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_Refresh.Controls.Add(this.label_ServerAddress);
            this.panel_Refresh.Controls.Add(this.textBox_ServerAddress);
            this.panel_Refresh.Controls.Add(this.Button_Refresh);
            this.panel_Refresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Refresh.Location = new System.Drawing.Point(0, 458);
            this.panel_Refresh.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Refresh.Name = "panel_Refresh";
            this.panel_Refresh.Size = new System.Drawing.Size(726, 33);
            this.panel_Refresh.TabIndex = 7;
            // 
            // panel_ListView
            // 
            this.panel_ListView.Controls.Add(this.listBox1);
            this.panel_ListView.Controls.Add(this.panel_ListView_Search);
            this.panel_ListView.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_ListView.Location = new System.Drawing.Point(0, 0);
            this.panel_ListView.Margin = new System.Windows.Forms.Padding(2);
            this.panel_ListView.Name = "panel_ListView";
            this.panel_ListView.Size = new System.Drawing.Size(252, 458);
            this.panel_ListView.TabIndex = 8;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "1 Jelmer Andere de la porte",
            "2 iemand1 achternaam",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60"});
            this.listBox1.Location = new System.Drawing.Point(0, 32);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(252, 426);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.SelcetedInadexChange);
            // 
            // panel_ListView_Search
            // 
            this.panel_ListView_Search.Controls.Add(this.textBox_Search);
            this.panel_ListView_Search.Controls.Add(this.label_Search);
            this.panel_ListView_Search.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ListView_Search.Location = new System.Drawing.Point(0, 0);
            this.panel_ListView_Search.Margin = new System.Windows.Forms.Padding(2);
            this.panel_ListView_Search.Name = "panel_ListView_Search";
            this.panel_ListView_Search.Size = new System.Drawing.Size(252, 32);
            this.panel_ListView_Search.TabIndex = 11;
            // 
            // textBox_Search
            // 
            this.textBox_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Search.Location = new System.Drawing.Point(62, 5);
            this.textBox_Search.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(132, 23);
            this.textBox_Search.TabIndex = 4;
            // 
            // label_Search
            // 
            this.label_Search.AutoSize = true;
            this.label_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Search.Location = new System.Drawing.Point(6, 6);
            this.label_Search.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Search.Name = "label_Search";
            this.label_Search.Size = new System.Drawing.Size(51, 17);
            this.label_Search.TabIndex = 0;
            this.label_Search.Text = "search";
            // 
            // button_DeleteEntry
            // 
            this.button_DeleteEntry.Enabled = false;
            this.button_DeleteEntry.Location = new System.Drawing.Point(12, 161);
            this.button_DeleteEntry.Margin = new System.Windows.Forms.Padding(2);
            this.button_DeleteEntry.Name = "button_DeleteEntry";
            this.button_DeleteEntry.Size = new System.Drawing.Size(96, 53);
            this.button_DeleteEntry.TabIndex = 10;
            this.button_DeleteEntry.Text = "DeleteEntry";
            this.button_DeleteEntry.UseVisualStyleBackColor = true;
            this.button_DeleteEntry.Click += new System.EventHandler(this.button_DeleteEntry_Click);
            // 
            // panel_EntryInfo
            // 
            this.panel_EntryInfo.Controls.Add(this.button1);
            this.panel_EntryInfo.Controls.Add(this.button_SetNewProfileImage);
            this.panel_EntryInfo.Controls.Add(this.button_SaveChanges);
            this.panel_EntryInfo.Controls.Add(this.button_CancelChanges);
            this.panel_EntryInfo.Controls.Add(this.textBox_Achternaam);
            this.panel_EntryInfo.Controls.Add(this.textBox_Voornaam);
            this.panel_EntryInfo.Controls.Add(this.textBox_ID);
            this.panel_EntryInfo.Controls.Add(this.label_achternaam);
            this.panel_EntryInfo.Controls.Add(this.label_Voornaam);
            this.panel_EntryInfo.Controls.Add(this.label_ID);
            this.panel_EntryInfo.Controls.Add(this.label_ProfileImage);
            this.panel_EntryInfo.Controls.Add(this.pictureBox_ProfileImage);
            this.panel_EntryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_EntryInfo.Location = new System.Drawing.Point(252, 0);
            this.panel_EntryInfo.Margin = new System.Windows.Forms.Padding(2);
            this.panel_EntryInfo.Name = "panel_EntryInfo";
            this.panel_EntryInfo.Size = new System.Drawing.Size(356, 458);
            this.panel_EntryInfo.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(292, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 218);
            this.button1.TabIndex = 15;
            this.button1.Text = "SaveImage";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button_SetNewProfileImage
            // 
            this.button_SetNewProfileImage.Enabled = false;
            this.button_SetNewProfileImage.Location = new System.Drawing.Point(14, 335);
            this.button_SetNewProfileImage.Margin = new System.Windows.Forms.Padding(2);
            this.button_SetNewProfileImage.Name = "button_SetNewProfileImage";
            this.button_SetNewProfileImage.Size = new System.Drawing.Size(132, 41);
            this.button_SetNewProfileImage.TabIndex = 14;
            this.button_SetNewProfileImage.Text = "SetNewProfileImage";
            this.button_SetNewProfileImage.UseVisualStyleBackColor = true;
            this.button_SetNewProfileImage.Click += new System.EventHandler(this.button_SetNewProfileImage_Click);
            // 
            // button_SaveChanges
            // 
            this.button_SaveChanges.Enabled = false;
            this.button_SaveChanges.Location = new System.Drawing.Point(150, 399);
            this.button_SaveChanges.Margin = new System.Windows.Forms.Padding(2);
            this.button_SaveChanges.Name = "button_SaveChanges";
            this.button_SaveChanges.Size = new System.Drawing.Size(96, 41);
            this.button_SaveChanges.TabIndex = 13;
            this.button_SaveChanges.Text = "Save";
            this.button_SaveChanges.UseVisualStyleBackColor = true;
            this.button_SaveChanges.Click += new System.EventHandler(this.button_SaveChanges_Click);
            // 
            // button_CancelChanges
            // 
            this.button_CancelChanges.Enabled = false;
            this.button_CancelChanges.Location = new System.Drawing.Point(14, 399);
            this.button_CancelChanges.Margin = new System.Windows.Forms.Padding(2);
            this.button_CancelChanges.Name = "button_CancelChanges";
            this.button_CancelChanges.Size = new System.Drawing.Size(96, 41);
            this.button_CancelChanges.TabIndex = 12;
            this.button_CancelChanges.Text = "Cancel";
            this.button_CancelChanges.UseVisualStyleBackColor = true;
            this.button_CancelChanges.Click += new System.EventHandler(this.button_CancelChanges_Click);
            // 
            // textBox_Achternaam
            // 
            this.textBox_Achternaam.Enabled = false;
            this.textBox_Achternaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Achternaam.Location = new System.Drawing.Point(97, 300);
            this.textBox_Achternaam.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Achternaam.Name = "textBox_Achternaam";
            this.textBox_Achternaam.Size = new System.Drawing.Size(194, 23);
            this.textBox_Achternaam.TabIndex = 7;
            // 
            // textBox_Voornaam
            // 
            this.textBox_Voornaam.Enabled = false;
            this.textBox_Voornaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Voornaam.Location = new System.Drawing.Point(97, 274);
            this.textBox_Voornaam.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Voornaam.Name = "textBox_Voornaam";
            this.textBox_Voornaam.Size = new System.Drawing.Size(194, 23);
            this.textBox_Voornaam.TabIndex = 6;
            // 
            // textBox_ID
            // 
            this.textBox_ID.Enabled = false;
            this.textBox_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ID.Location = new System.Drawing.Point(97, 250);
            this.textBox_ID.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(194, 23);
            this.textBox_ID.TabIndex = 5;
            // 
            // label_achternaam
            // 
            this.label_achternaam.AutoSize = true;
            this.label_achternaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_achternaam.Location = new System.Drawing.Point(6, 302);
            this.label_achternaam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_achternaam.Name = "label_achternaam";
            this.label_achternaam.Size = new System.Drawing.Size(84, 17);
            this.label_achternaam.TabIndex = 4;
            this.label_achternaam.Text = "Achternaam";
            // 
            // label_Voornaam
            // 
            this.label_Voornaam.AutoSize = true;
            this.label_Voornaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Voornaam.Location = new System.Drawing.Point(6, 276);
            this.label_Voornaam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Voornaam.Name = "label_Voornaam";
            this.label_Voornaam.Size = new System.Drawing.Size(73, 17);
            this.label_Voornaam.TabIndex = 3;
            this.label_Voornaam.Text = "Voornaam";
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ID.Location = new System.Drawing.Point(6, 252);
            this.label_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(21, 17);
            this.label_ID.TabIndex = 2;
            this.label_ID.Text = "ID";
            // 
            // label_ProfileImage
            // 
            this.label_ProfileImage.AutoSize = true;
            this.label_ProfileImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProfileImage.Location = new System.Drawing.Point(6, 5);
            this.label_ProfileImage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ProfileImage.Name = "label_ProfileImage";
            this.label_ProfileImage.Size = new System.Drawing.Size(86, 17);
            this.label_ProfileImage.TabIndex = 1;
            this.label_ProfileImage.Text = "ProfileImage";
            // 
            // pictureBox_ProfileImage
            // 
            this.pictureBox_ProfileImage.Image = global::MakeChangesToDB.Properties.Resources.noimage;
            this.pictureBox_ProfileImage.Location = new System.Drawing.Point(9, 26);
            this.pictureBox_ProfileImage.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_ProfileImage.Name = "pictureBox_ProfileImage";
            this.pictureBox_ProfileImage.Size = new System.Drawing.Size(280, 218);
            this.pictureBox_ProfileImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ProfileImage.TabIndex = 0;
            this.pictureBox_ProfileImage.TabStop = false;
            // 
            // panel_Tools
            // 
            this.panel_Tools.Controls.Add(this.button_EditEntry);
            this.panel_Tools.Controls.Add(this.button_NewEntry);
            this.panel_Tools.Controls.Add(this.button_DeleteEntry);
            this.panel_Tools.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Tools.Location = new System.Drawing.Point(608, 0);
            this.panel_Tools.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Tools.Name = "panel_Tools";
            this.panel_Tools.Size = new System.Drawing.Size(118, 458);
            this.panel_Tools.TabIndex = 10;
            // 
            // button_EditEntry
            // 
            this.button_EditEntry.Enabled = false;
            this.button_EditEntry.Location = new System.Drawing.Point(12, 12);
            this.button_EditEntry.Margin = new System.Windows.Forms.Padding(2);
            this.button_EditEntry.Name = "button_EditEntry";
            this.button_EditEntry.Size = new System.Drawing.Size(96, 53);
            this.button_EditEntry.TabIndex = 12;
            this.button_EditEntry.Text = "EditEntry";
            this.button_EditEntry.UseVisualStyleBackColor = true;
            this.button_EditEntry.Click += new System.EventHandler(this.button_EditEntry_Click);
            // 
            // button_NewEntry
            // 
            this.button_NewEntry.Location = new System.Drawing.Point(12, 83);
            this.button_NewEntry.Margin = new System.Windows.Forms.Padding(2);
            this.button_NewEntry.Name = "button_NewEntry";
            this.button_NewEntry.Size = new System.Drawing.Size(96, 53);
            this.button_NewEntry.TabIndex = 11;
            this.button_NewEntry.Text = "NewEntry";
            this.button_NewEntry.UseVisualStyleBackColor = true;
            this.button_NewEntry.Click += new System.EventHandler(this.button_NewEntry_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 491);
            this.Controls.Add(this.panel_EntryInfo);
            this.Controls.Add(this.panel_Tools);
            this.Controls.Add(this.panel_ListView);
            this.Controls.Add(this.panel_Refresh);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_Refresh.ResumeLayout(false);
            this.panel_Refresh.PerformLayout();
            this.panel_ListView.ResumeLayout(false);
            this.panel_ListView_Search.ResumeLayout(false);
            this.panel_ListView_Search.PerformLayout();
            this.panel_EntryInfo.ResumeLayout(false);
            this.panel_EntryInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProfileImage)).EndInit();
            this.panel_Tools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_ServerAddress;
        private System.Windows.Forms.Label label_ServerAddress;
        private System.Windows.Forms.Button Button_Refresh;
        private System.Windows.Forms.Panel panel_Refresh;
        private System.Windows.Forms.Panel panel_ListView;
        private System.Windows.Forms.Panel panel_ListView_Search;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Label label_Search;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button_DeleteEntry;
        private System.Windows.Forms.Panel panel_EntryInfo;
        private System.Windows.Forms.Panel panel_Tools;
        private System.Windows.Forms.Button button_EditEntry;
        private System.Windows.Forms.Button button_NewEntry;
        private System.Windows.Forms.Label label_ProfileImage;
        private System.Windows.Forms.PictureBox pictureBox_ProfileImage;
        private System.Windows.Forms.TextBox textBox_Achternaam;
        private System.Windows.Forms.TextBox textBox_Voornaam;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label_achternaam;
        private System.Windows.Forms.Label label_Voornaam;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Button button_SaveChanges;
        private System.Windows.Forms.Button button_CancelChanges;
        private System.Windows.Forms.Button button_SetNewProfileImage;
        private System.Windows.Forms.Button button1;
    }
}

