namespace Admin {
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSerial = new System.Windows.Forms.Panel();
            this.checkBoxUserSerialPort = new System.Windows.Forms.CheckBox();
            this.buttonRefreshSerial = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonTestSerial = new System.Windows.Forms.Button();
            this.buttonTestWpAndAddres = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "http://192.168.0.10/api/main";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(85, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(164, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "testwachtwoord";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ApiAdress";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.buttonTestWpAndAddres);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Location = new System.Drawing.Point(25, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 88);
            this.panel1.TabIndex = 4;
            // 
            // panelSerial
            // 
            this.panelSerial.BackColor = System.Drawing.SystemColors.Info;
            this.panelSerial.Controls.Add(this.buttonTestSerial);
            this.panelSerial.Controls.Add(this.listBox1);
            this.panelSerial.Controls.Add(this.buttonRefreshSerial);
            this.panelSerial.Enabled = false;
            this.panelSerial.Location = new System.Drawing.Point(25, 31);
            this.panelSerial.Name = "panelSerial";
            this.panelSerial.Size = new System.Drawing.Size(176, 137);
            this.panelSerial.TabIndex = 5;
            // 
            // checkBoxUserSerialPort
            // 
            this.checkBoxUserSerialPort.AutoSize = true;
            this.checkBoxUserSerialPort.Location = new System.Drawing.Point(25, 22);
            this.checkBoxUserSerialPort.Name = "checkBoxUserSerialPort";
            this.checkBoxUserSerialPort.Size = new System.Drawing.Size(74, 17);
            this.checkBoxUserSerialPort.TabIndex = 6;
            this.checkBoxUserSerialPort.Text = "Use Serial";
            this.checkBoxUserSerialPort.UseVisualStyleBackColor = true;
            this.checkBoxUserSerialPort.CheckedChanged += new System.EventHandler(this.checkBoxUserSerialPort_CheckedChanged);
            // 
            // buttonRefreshSerial
            // 
            this.buttonRefreshSerial.Location = new System.Drawing.Point(9, 14);
            this.buttonRefreshSerial.Name = "buttonRefreshSerial";
            this.buttonRefreshSerial.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshSerial.TabIndex = 0;
            this.buttonRefreshSerial.Text = "Refresh";
            this.buttonRefreshSerial.UseVisualStyleBackColor = true;
            this.buttonRefreshSerial.Click += new System.EventHandler(this.refreshSerialportsList);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(9, 43);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(155, 84);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonTestSerial
            // 
            this.buttonTestSerial.Location = new System.Drawing.Point(89, 14);
            this.buttonTestSerial.Name = "buttonTestSerial";
            this.buttonTestSerial.Size = new System.Drawing.Size(75, 23);
            this.buttonTestSerial.TabIndex = 3;
            this.buttonTestSerial.Text = "Test";
            this.buttonTestSerial.UseVisualStyleBackColor = true;
            this.buttonTestSerial.Click += new System.EventHandler(this.testSerialPort);
            // 
            // buttonTestWpAndAddres
            // 
            this.buttonTestWpAndAddres.Location = new System.Drawing.Point(255, 21);
            this.buttonTestWpAndAddres.Name = "buttonTestWpAndAddres";
            this.buttonTestWpAndAddres.Size = new System.Drawing.Size(75, 46);
            this.buttonTestWpAndAddres.TabIndex = 4;
            this.buttonTestWpAndAddres.Text = "Test";
            this.buttonTestWpAndAddres.UseVisualStyleBackColor = true;
            this.buttonTestWpAndAddres.Click += new System.EventHandler(this.testServerConnection);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(267, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 70);
            this.button3.TabIndex = 7;
            this.button3.Text = "Continue";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 322);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBoxUserSerialPort);
            this.Controls.Add(this.panelSerial);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSerial.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelSerial;
        private System.Windows.Forms.Button buttonRefreshSerial;
        private System.Windows.Forms.CheckBox checkBoxUserSerialPort;
        private System.Windows.Forms.Button buttonTestSerial;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonTestWpAndAddres;
        private System.Windows.Forms.Button button3;
    }
}

