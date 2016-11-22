namespace Admin {
    partial class SelectionForm {
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
            this.buttonZetDagenDatErSchoolIs = new System.Windows.Forms.Button();
            this.buttonViewLogs = new System.Windows.Forms.Button();
            this.buttonManageStudents = new System.Windows.Forms.Button();
            this.buttonManageAfEnAanWezighijd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonZetDagenDatErSchoolIs
            // 
            this.buttonZetDagenDatErSchoolIs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonZetDagenDatErSchoolIs.Location = new System.Drawing.Point(308, 42);
            this.buttonZetDagenDatErSchoolIs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonZetDagenDatErSchoolIs.Name = "buttonZetDagenDatErSchoolIs";
            this.buttonZetDagenDatErSchoolIs.Size = new System.Drawing.Size(199, 112);
            this.buttonZetDagenDatErSchoolIs.TabIndex = 4;
            this.buttonZetDagenDatErSchoolIs.Text = "ZET DAGEN DAT ER SCHOOL IS";
            this.buttonZetDagenDatErSchoolIs.UseVisualStyleBackColor = true;
            // 
            // buttonViewLogs
            // 
            this.buttonViewLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewLogs.Location = new System.Drawing.Point(308, 213);
            this.buttonViewLogs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonViewLogs.Name = "buttonViewLogs";
            this.buttonViewLogs.Size = new System.Drawing.Size(199, 112);
            this.buttonViewLogs.TabIndex = 6;
            this.buttonViewLogs.Text = "Inspect Logs";
            this.buttonViewLogs.UseVisualStyleBackColor = true;
            // 
            // buttonManageStudents
            // 
            this.buttonManageStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageStudents.Location = new System.Drawing.Point(43, 42);
            this.buttonManageStudents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonManageStudents.Name = "buttonManageStudents";
            this.buttonManageStudents.Size = new System.Drawing.Size(199, 112);
            this.buttonManageStudents.TabIndex = 5;
            this.buttonManageStudents.Text = "MANAGE STUDENT TABLE";
            this.buttonManageStudents.UseVisualStyleBackColor = true;
            this.buttonManageStudents.Click += new System.EventHandler(this.buttonManageStudents_Click);
            // 
            // buttonManageAfEnAanWezighijd
            // 
            this.buttonManageAfEnAanWezighijd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageAfEnAanWezighijd.Location = new System.Drawing.Point(43, 213);
            this.buttonManageAfEnAanWezighijd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonManageAfEnAanWezighijd.Name = "buttonManageAfEnAanWezighijd";
            this.buttonManageAfEnAanWezighijd.Size = new System.Drawing.Size(199, 112);
            this.buttonManageAfEnAanWezighijd.TabIndex = 7;
            this.buttonManageAfEnAanWezighijd.Text = "MANAGE AAN/AF WEZIGHIJD TABLE";
            this.buttonManageAfEnAanWezighijd.UseVisualStyleBackColor = true;
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 388);
            this.Controls.Add(this.buttonZetDagenDatErSchoolIs);
            this.Controls.Add(this.buttonViewLogs);
            this.Controls.Add(this.buttonManageStudents);
            this.Controls.Add(this.buttonManageAfEnAanWezighijd);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SelectionForm";
            this.Text = "SelectionForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonZetDagenDatErSchoolIs;
        private System.Windows.Forms.Button buttonViewLogs;
        private System.Windows.Forms.Button buttonManageStudents;
        private System.Windows.Forms.Button buttonManageAfEnAanWezighijd;
    }
}