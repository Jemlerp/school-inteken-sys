namespace toegangpunt {
    partial class FormStartup {
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
            this.listBox_comnport = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_apiAdress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Start = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_wachtwoord = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox_comnport
            // 
            this.listBox_comnport.FormattingEnabled = true;
            this.listBox_comnport.Location = new System.Drawing.Point(12, 23);
            this.listBox_comnport.Name = "listBox_comnport";
            this.listBox_comnport.Size = new System.Drawing.Size(167, 134);
            this.listBox_comnport.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comport";
            // 
            // textBox_apiAdress
            // 
            this.textBox_apiAdress.Location = new System.Drawing.Point(12, 206);
            this.textBox_apiAdress.Name = "textBox_apiAdress";
            this.textBox_apiAdress.Size = new System.Drawing.Size(183, 20);
            this.textBox_apiAdress.TabIndex = 2;
            this.textBox_apiAdress.Text = "http://localhost:58159/api/main";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "api";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.refreshListbox);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(215, 46);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(92, 58);
            this.button_Start.TabIndex = 5;
            this.button_Start.Text = "start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "wachtwoord";
            // 
            // textBox_wachtwoord
            // 
            this.textBox_wachtwoord.Location = new System.Drawing.Point(12, 246);
            this.textBox_wachtwoord.Name = "textBox_wachtwoord";
            this.textBox_wachtwoord.Size = new System.Drawing.Size(183, 20);
            this.textBox_wachtwoord.TabIndex = 6;
            this.textBox_wachtwoord.Text = "testwachtwoord";
            // 
            // FormStartup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 317);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_wachtwoord);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_apiAdress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_comnport);
            this.Name = "FormStartup";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormStartup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_comnport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_apiAdress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_wachtwoord;
    }
}

