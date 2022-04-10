
namespace Organizer
{
    partial class Dashboard
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lbProjects = new System.Windows.Forms.ListBox();
            this.btnNewProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblTitle.Location = new System.Drawing.Point(235, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(419, 71);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbProjects
            // 
            this.lbProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbProjects.FormattingEnabled = true;
            this.lbProjects.ItemHeight = 20;
            this.lbProjects.Location = new System.Drawing.Point(138, 158);
            this.lbProjects.Name = "lbProjects";
            this.lbProjects.Size = new System.Drawing.Size(693, 284);
            this.lbProjects.TabIndex = 1;
            this.lbProjects.DoubleClick += new System.EventHandler(this.lbProjects_DoubleClick);
            // 
            // btnNewProject
            // 
            this.btnNewProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNewProject.Location = new System.Drawing.Point(138, 496);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(157, 38);
            this.btnNewProject.TabIndex = 2;
            this.btnNewProject.Text = "Novi Projekat";
            this.btnNewProject.UseVisualStyleBackColor = true;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 606);
            this.Controls.Add(this.btnNewProject);
            this.Controls.Add(this.lbProjects);
            this.Controls.Add(this.lblTitle);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.Enter += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lbProjects;
        private System.Windows.Forms.Button btnNewProject;
    }
}