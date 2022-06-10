using PersAccounting.Forms;
using System;
using System.Windows.Forms;

namespace PersAccounting
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            EmployeesListForm form = new EmployeesListForm();
            DisplayForm(form);

        }


        public override void Refresh()
        {
            EmployeesListForm form = new EmployeesListForm();
            DisplayForm(form);
        }

        private void DisplayForm(Form form)
        {
            pMain.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Parent = this;
            pMain.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Owner = this;
            addForm.ShowDialog();
        }
    }
}
