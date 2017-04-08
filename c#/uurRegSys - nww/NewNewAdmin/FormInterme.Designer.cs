namespace NewNewAdmin {
    partial class FormInterme {
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
            this.Acounts = new System.Windows.Forms.Button();
            this.Users = new System.Windows.Forms.Button();
            this.uitzon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Acounts
            // 
            this.Acounts.Location = new System.Drawing.Point(12, 12);
            this.Acounts.Name = "Acounts";
            this.Acounts.Size = new System.Drawing.Size(172, 82);
            this.Acounts.TabIndex = 0;
            this.Acounts.Text = "Acounts";
            this.Acounts.UseVisualStyleBackColor = true;
            this.Acounts.Click += new System.EventHandler(this.Acounts_Click);
            // 
            // Users
            // 
            this.Users.Location = new System.Drawing.Point(190, 12);
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(172, 82);
            this.Users.TabIndex = 1;
            this.Users.Text = "Users";
            this.Users.UseVisualStyleBackColor = true;
            this.Users.Click += new System.EventHandler(this.Users_Click);
            // 
            // uitzon
            // 
            this.uitzon.Location = new System.Drawing.Point(368, 12);
            this.uitzon.Name = "uitzon";
            this.uitzon.Size = new System.Drawing.Size(172, 82);
            this.uitzon.TabIndex = 2;
            this.uitzon.Text = "uitzondering";
            this.uitzon.UseVisualStyleBackColor = true;
            this.uitzon.Click += new System.EventHandler(this.uitzon_Click);
            // 
            // FormInterme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 276);
            this.Controls.Add(this.uitzon);
            this.Controls.Add(this.Users);
            this.Controls.Add(this.Acounts);
            this.Name = "FormInterme";
            this.Text = "FormInterme";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Acounts;
        private System.Windows.Forms.Button Users;
        private System.Windows.Forms.Button uitzon;
    }
}