using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class Project : Form
    {
        enum Clearence
        {
            None,
            Some,
            All
        }

        struct ProjectData
        {
            string name;
            string description;
            DateTime start;
            DateTime end;
            DateTime expectedEnd;
            int id;

            Dictionary<string, Clearence> people;
        }

        ProjectData data = new ProjectData();

        bool isCreatingNewProject;


        public Project()
        {
            InitializeComponent();
            isCreatingNewProject = true;
        }

        public Project(int projectId)
        {
            InitializeComponent();
            isCreatingNewProject = false;

            // Fetch data from db
        }

        private void Project_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
