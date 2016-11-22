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
            this.textBoxAdress = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTestWpAndAddres = new System.Windows.Forms.Button();
            this.panelSerial = new System.Windows.Forms.Panel();
            this.buttonTestSerial = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonRefreshSerial = new System.Windows.Forms.Button();
            this.checkBoxUserSerialPort = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.Location = new System.Drawing.Point(113, 26);
            this.textBoxAdress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(217, 22);
            this.textBoxAdress.TabIndex = 0;
            this.textBoxAdress.Text = "http://localhost/api/main";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(113, 58);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(217, 22);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.Text = "testwachtwoord";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "ApiAdress";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.buttonTestWpAndAddres);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxAdress);
            this.panel1.Controls.Add(this.textBoxPassword);
            this.panel1.Location = new System.Drawing.Point(33, 239);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 108);
            this.panel1.TabIndex = 4;
            // 
            // buttonTestWpAndAddres
            // 
            this.buttonTestWpAndAddres.Enabled = false;
            this.buttonTestWpAndAddres.Location = new System.Drawing.Point(340, 26);
            this.buttonTestWpAndAddres.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonTestWpAndAddres.Name = "buttonTestWpAndAddres";
            this.buttonTestWpAndAddres.Size = new System.Drawing.Size(100, 57);
            this.buttonTestWpAndAddres.TabIndex = 4;
            this.buttonTestWpAndAddres.Text = "Test";
            this.buttonTestWpAndAddres.UseVisualStyleBackColor = true;
            this.buttonTestWpAndAddres.Click += new System.EventHandler(this.testServerConnection);
            // 
            // panelSerial
            // 
            this.panelSerial.BackColor = System.Drawing.SystemColors.Info;
            this.panelSerial.Controls.Add(this.buttonTestSerial);
            this.panelSerial.Controls.Add(this.listBox1);
            this.panelSerial.Controls.Add(this.buttonRefreshSerial);
            this.panelSerial.Enabled = false;
            this.panelSerial.Location = new System.Drawing.Point(33, 38);
            this.panelSerial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelSerial.Name = "panelSerial";
            this.panelSerial.Size = new System.Drawing.Size(235, 169);
            this.panelSerial.TabIndex = 5;
            // 
            // buttonTestSerial
            // 
            this.buttonTestSerial.Location = new System.Drawing.Point(119, 17);
            this.buttonTestSerial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonTestSerial.Name = "buttonTestSerial";
            this.buttonTestSerial.Size = new System.Drawing.Size(100, 28);
            this.buttonTestSerial.TabIndex = 3;
            this.buttonTestSerial.Text = "Test";
            this.buttonTestSerial.UseVisualStyleBackColor = true;
            this.buttonTestSerial.Click += new System.EventHandler(this.testSerialPort);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(12, 53);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(205, 79);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonRefreshSerial
            // 
            this.buttonRefreshSerial.Location = new System.Drawing.Point(12, 17);
            this.buttonRefreshSerial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRefreshSerial.Name = "buttonRefreshSerial";
            this.buttonRefreshSerial.Size = new System.Drawing.Size(100, 28);
            this.buttonRefreshSerial.TabIndex = 0;
            this.buttonRefreshSerial.Text = "Refresh";
            this.buttonRefreshSerial.UseVisualStyleBackColor = true;
            this.buttonRefreshSerial.Click += new System.EventHandler(this.refreshSerialportsList);
            // 
            // checkBoxUserSerialPort
            // 
            this.checkBoxUserSerialPort.AutoSize = true;
            this.checkBoxUserSerialPort.Location = new System.Drawing.Point(33, 27);
            this.checkBoxUserSerialPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxUserSerialPort.Name = "checkBoxUserSerialPort";
            this.checkBoxUserSerialPort.Size = new System.Drawing.Size(95, 21);
            this.checkBoxUserSerialPort.TabIndex = 6;
            this.checkBoxUserSerialPort.Text = "Use Serial";
            this.checkBoxUserSerialPort.UseVisualStyleBackColor = true;
            this.checkBoxUserSerialPort.CheckedChanged += new System.EventHandler(this.checkBoxUserSerialPort_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(336, 91);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 86);
            this.button3.TabIndex = 7;
            this.button3.Text = "Continue";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 396);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBoxUserSerialPort);
            this.Controls.Add(this.panelSerial);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSerial.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAdress;
        private System.Windows.Forms.TextBox textBoxPassword;
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

