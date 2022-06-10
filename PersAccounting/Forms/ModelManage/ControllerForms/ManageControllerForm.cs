using PersAccounting.DB;
using PersAccounting.Enums;
using PersAccounting.Models;
using PersAccounting.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PersAccounting.Forms.ModelManage.ControllerForms
{
    public partial class ManageControllerForm : Form
    {
        private ManageFormMode formMode;
        private Controller controller;
        private List<string> genders = EmployeeManager.Genders;
        private List<DepartmentHead> heads;
        private AddForm parent;

        public ManageControllerForm(AddForm parent) : this(ManageFormMode.Add)
        {
            this.parent = parent;
        }

        public ManageControllerForm(Controller controller) : this(ManageFormMode.Edit)
        {
            this.controller = controller;
            using (DataBase db = new DataBase())
            {
                this.controller.Head = db.DepartmentHeads.Where(h => h.Id == controller.HeadId).FirstOrDefault();
            }

            DisplayController();
        }
        private ManageControllerForm(ManageFormMode formMode)
        {
            InitializeComponent();
            this.formMode = formMode;
            cmbGender.Items.AddRange(genders.ToArray());
            using (DataBase db = new DataBase())
            {
                heads = db.DepartmentHeads.ToList();
            }

            cmbHead.Items.AddRange(heads.Select(h => $"{h.Surname} {h.Name} {h.Patronymic}").ToArray());
        }

        private void DisplayController()
        {
            tbName.Text = controller.Name;
            tbSurname.Text = controller.Surname;
            tbPatronymic.Text = controller.Patronymic;
            dtpBirthDate.Value = controller.BirthDate;
            cmbGender.SelectedItem = controller.Gender;
            if (controller.Head is not null)
            {
                cmbHead.SelectedItem = $"{controller.Head.Surname} {controller.Head.Name} {controller.Head.Patronymic}";
            }
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            if (formMode == ManageFormMode.Add)
            {
                using (DataBase db = new DataBase())
                {
                    Controller controller = new Controller()
                    {
                        Name = tbName.Text,
                        Surname = tbSurname.Text,
                        Patronymic = tbPatronymic.Text,
                        BirthDate = dtpBirthDate.Value,
                        Gender = cmbGender.SelectedItem.ToString()
                    };

                    if (cmbHead.SelectedIndex >= 0)
                    {
                        controller.Head = heads[cmbHead.SelectedIndex];
                    }

                    db.AddModel<Controller>(controller);
                }

                parent.RefreshOwner();
                parent.Close();
            }
            else
            {
                using (DataBase db = new DataBase())
                {
                    controller.Name = tbName.Text;
                    controller.Surname = tbSurname.Text;
                    controller.Patronymic = tbPatronymic.Text;
                    controller.BirthDate = dtpBirthDate.Value;
                    controller.Gender = cmbGender.SelectedItem.ToString();
                    if (cmbHead.SelectedIndex >= 0)
                    {
                        controller.HeadId = heads[cmbHead.SelectedIndex].Id;
                    }
                    db.EditModel<Controller>(controller);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
