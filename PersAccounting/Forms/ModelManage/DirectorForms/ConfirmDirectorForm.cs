using PersAccounting.Enums;
using PersAccounting.Models;
using PersAccounting.Models.Employees;
using System;
using System.Windows.Forms;

namespace PersAccounting.Forms.ModelManage.DirectorForms
{
    public partial class ConfirmDirectorForm : Form
    {
        private ConfirmFormMode formMode;
        private Director departmentHead;
        private const string confirmDeleteText = "Вы уверены что хотите удалить данного директора?";
        private const string confirmRaiseText = "Вы уверены что хотите повысить данного директора?";

        public ConfirmDirectorForm(Director departmentHead, ConfirmFormMode formMode)
        {
            InitializeComponent();
            this.formMode = formMode;
            this.departmentHead = departmentHead;
            DisplayDirector();
        }

        private void DisplayDirector()
        {
            lName.Text = departmentHead.Name;
            lSurname.Text = departmentHead.Surname;
            lPatronymic.Text = departmentHead.Patronymic;
            lBirthDate.Text = departmentHead.BirthDate.ToString("yyyy-MM-dd");
            lGender.Text = departmentHead.Gender;
            lPost.Text = departmentHead.Post;

            switch (formMode)
            {
                case ConfirmFormMode.Delete: lText.Text = confirmDeleteText; return;
                case ConfirmFormMode.Raise: lText.Text = confirmRaiseText; return;
            }
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
