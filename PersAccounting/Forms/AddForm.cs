using PersAccounting.Enums;
using PersAccounting.Forms.ModelManage.ControllerForms;
using PersAccounting.Forms.ModelManage.DepartmentHeadForms;
using PersAccounting.Forms.ModelManage.DirectorForms;
using PersAccounting.Forms.ModelManage.WorkerForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersAccounting.Forms
{
    public partial class AddForm : Form
    {
        private List<string> posts = EmployeeManager.Posts;

        public AddForm()
        {
            InitializeComponent();
            cmbType.Items.AddRange(posts.ToArray());
            cmbType.SelectedIndex = 0;
        }

        public void RefreshOwner()
        {
            Owner.Refresh();
        }

        private void DisplayForm(Form form)
        {
            pPanel.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            pPanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeePost post = EmployeeManager.EmployeesPostNameToEnumDictionary[cmbType.SelectedItem.ToString()];
            switch (post)
            {
                case EmployeePost.Worker: DisplayForm(new ManageWorkerForm(this)); break;
                case EmployeePost.Controller: DisplayForm(new ManageControllerForm(this)); break;
                case EmployeePost.DepartmentHead: DisplayForm(new ManageDepHeadForm(this)); break;
                case EmployeePost.Director: DisplayForm(new ManageDirectorForm(this)); break;
            }
        }
    }
}
