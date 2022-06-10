using PersAccounting.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersAccounting.Forms.ModelManage.DepartmentHeadForms
{
    public partial class ManageDepHeadForm : Form
    {
        private ManageFormMode formMode;
        private DepartmentHead departmentHead;
        private List<string> genders = EmployeeManager.Genders;
        private AddForm parent;

        public ManageDepHeadForm(AddForm parent) : this(ManageFormMode.Add)
        {
            this.parent = parent;
        }

        public ManageDepHeadForm(DepartmentHead departmentHead) : this(ManageFormMode.Edit)
        {
            this.departmentHead = departmentHead;
            DisplayController();
        }

        private ManageDepHeadForm(ManageFormMode formMode)
        {
            InitializeComponent();
            this.formMode = formMode;
            cmbGender.Items.AddRange(genders.ToArray());
        }

        private void DisplayController()
        {
            tbName.Text = departmentHead.Name;
            tbSurname.Text = departmentHead.Surname;
            tbPatronymic.Text = departmentHead.Patronymic;
            dtpBirthDate.Value = departmentHead.BirthDate;
            cmbGender.SelectedItem = departmentHead.Gender;
            tbDepartment.Text = departmentHead.Department;
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            if (formMode == ManageFormMode.Add)
            {
                using (DataBase db = new DataBase())
                {
                    DepartmentHead departmentHead = new DepartmentHead()
                    {
                        Name = tbName.Text,
                        Surname = tbSurname.Text,
                        Patronymic = tbPatronymic.Text,
                        BirthDate = dtpBirthDate.Value,
                        Gender = cmbGender.SelectedItem.ToString(),
                        Department = tbDepartment.Text
                    };

                    db.AddModel<DepartmentHead>(departmentHead);
                }

                parent.RefreshOwner();
                parent.Close();
            }
            else
            {
                using (DataBase db = new DataBase())
                {
                    departmentHead.Name = tbName.Text;
                    departmentHead.Surname = tbSurname.Text;
                    departmentHead.Patronymic = tbPatronymic.Text;
                    departmentHead.BirthDate = dtpBirthDate.Value;
                    departmentHead.Gender = cmbGender.SelectedItem.ToString();
                    departmentHead.Department = tbDepartment.Text;
                    db.EditModel<DepartmentHead>(departmentHead);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
