using PersAccounting.Enums;
using PersAccounting.Models;
using PersAccounting.Models.Employees;
using System;
using System.Windows.Forms;

namespace PersAccounting.Forms.ModelManage.DepartmentHeadForms
{
    public partial class ConfirmDepHeadForm : Form
    {
        private ConfirmFormMode formMode;
        private DepartmentHead departmentHead;
        private const string confirmDeleteText = "Вы уверены что хотите удалить данного руководителя отделения?";
        private const string confirmRaiseText = "Вы уверены что хотите повысить данного руководителя отделения?";

        public ConfirmDepHeadForm(DepartmentHead departmentHead, ConfirmFormMode formMode)
        {
            InitializeComponent();
            this.formMode = formMode;
            this.departmentHead = departmentHead;
            DisplayController();
        }


        private void DisplayController()
        {
            lName.Text = departmentHead.Name;
            lSurname.Text = departmentHead.Surname;
            lPatronymic.Text = departmentHead.Patronymic;
            lBirthDate.Text = departmentHead.BirthDate.ToString("yyyy-MM-dd");
            lGender.Text = departmentHead.Gender;
            lDepartment.Text = departmentHead.Department;

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
