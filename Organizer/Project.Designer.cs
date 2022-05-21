
namespace Organizer
{
    partial class Project
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbProjName = new System.Windows.Forms.TextBox();
            this.tbProjDesc = new System.Windows.Forms.TextBox();
            this.btnCreateProject = new System.Windows.Forms.Button();
            this.btnChangeProject = new System.Windows.Forms.Button();
            this.clbPeople = new System.Windows.Forms.CheckedListBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpExpectedEnd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // tbProjName
            // 
            this.tbProjName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbProjName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbProjName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.tbProjName.Location = new System.Drawing.Point(105, 33);
            this.tbProjName.Name = "tbProjName";
            this.tbProjName.Size = new System.Drawing.Size(203, 28);
            this.tbProjName.TabIndex = 0;
            // 
            // tbProjDesc
            // 
            this.tbProjDesc.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbProjDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbProjDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tbProjDesc.Location = new System.Drawing.Point(41, 86);
            this.tbProjDesc.Name = "tbProjDesc";
            this.tbProjDesc.Size = new System.Drawing.Size(332, 22);
            this.tbProjDesc.TabIndex = 1;
            // 
            // btnCreateProject
            // 
            this.btnCreateProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCreateProject.Location = new System.Drawing.Point(234, 516);
            this.btnCreateProject.Name = "btnCreateProject";
            this.btnCreateProject.Size = new System.Drawing.Size(139, 39);
            this.btnCreateProject.TabIndex = 3;
            this.btnCreateProject.Text = "Kreiraj projekat";
            this.btnCreateProject.UseVisualStyleBackColor = true;
            this.btnCreateProject.Click += new System.EventHandler(this.btnCreateProject_Click);
            // 
            // btnChangeProject
            // 
            this.btnChangeProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnChangeProject.Location = new System.Drawing.Point(41, 516);
            this.btnChangeProject.Name = "btnChangeProject";
            this.btnChangeProject.Size = new System.Drawing.Size(139, 39);
            this.btnChangeProject.TabIndex = 4;
            this.btnChangeProject.Text = "Izmeni projekat";
            this.btnChangeProject.UseVisualStyleBackColor = true;
            this.btnChangeProject.Click += new System.EventHandler(this.btnChangeProject_Click);
            // 
            // clbPeople
            // 
            this.clbPeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.clbPeople.FormattingEnabled = true;
            this.clbPeople.Location = new System.Drawing.Point(41, 284);
            this.clbPeople.Name = "clbPeople";
            this.clbPeople.Size = new System.Drawing.Size(332, 184);
            this.clbPeople.TabIndex = 5;
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(41, 137);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(332, 26);
            this.dtpStart.TabIndex = 6;
            // 
            // dtpExpectedEnd
            // 
            this.dtpExpectedEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpExpectedEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpectedEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpectedEnd.Location = new System.Drawing.Point(41, 205);
            this.dtpExpectedEnd.Name = "dtpExpectedEnd";
            this.dtpExpectedEnd.Size = new System.Drawing.Size(332, 26);
            this.dtpExpectedEnd.TabIndex = 7;
            // 
            // Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 608);
            this.Controls.Add(this.dtpExpectedEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.clbPeople);
            this.Controls.Add(this.btnChangeProject);
            this.Controls.Add(this.btnCreateProject);
            this.Controls.Add(this.tbProjDesc);
            this.Controls.Add(this.tbProjName);
            this.Name = "Project";
            this.Text = "Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Project_FormClosing);
            this.Load += new System.EventHandler(this.Project_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbProjName;
        private System.Windows.Forms.TextBox tbProjDesc;
        private System.Windows.Forms.Button btnCreateProject;
        private System.Windows.Forms.Button btnChangeProject;
        private System.Windows.Forms.CheckedListBox clbPeople;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpExpectedEnd;
    }
}