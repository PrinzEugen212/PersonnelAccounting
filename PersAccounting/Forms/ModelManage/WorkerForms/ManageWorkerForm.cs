using PersAccounting.DB;
using PersAccounting.Enums;
using PersAccounting.Models;
using PersAccounting.Models.Employees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PersAccounting.Forms.ModelManage.WorkerForms
{
    public partial class ManageWorkerForm : Form
    {
        private ManageFormMode formMode;
        private Worker worker;
        private List<string> genders = EmployeeManager.Genders;
        private List<DepartmentHead> heads;
        private AddForm parent;

        public ManageWorkerForm(AddForm parent) : this(ManageFormMode.Add)
        {
            this.parent = parent;
        }

        public ManageWorkerForm(Worker worker) : this(ManageFormMode.Edit)
        {
            this.worker = worker;
            using (DataBase db = new DataBase())
            {
                this.worker.Head = db.DepartmentHeads.Where(h => h.Id == worker.HeadId).FirstOrDefault();
            }

            DisplayWorker();
        }

        private ManageWorkerForm(ManageFormMode formMode)
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

        private void DisplayWorker()
        {
            tbName.Text = worker.Name;
            tbSurname.Text = worker.Surname;
            tbPatronymic.Text = worker.Patronymic;
            dtpBirthDate.Value = worker.BirthDate;
            cmbGender.SelectedItem = worker.Gender;
            if (worker.Head is not null)
            {
                cmbHead.SelectedItem = $"{worker.Head.Surname} {worker.Head.Name} {worker.Head.Patronymic}";
            }
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (formMode == ManageFormMode.Add)
                {
                    Worker worker = new Worker()
                    {
                        Name = tbName.Text,
                        Surname = tbSurname.Text,
                        Patronymic = tbPatronymic.Text,
                        BirthDate = dtpBirthDate.Value,
                        Gender = cmbGender.SelectedItem.ToString()
                    };

                    if (cmbHead.SelectedIndex >= 0)
                    {
                        worker.HeadId = heads[cmbHead.SelectedIndex].Id;
                    }

                    using (DataBase db = new DataBase())
                    {
                        db.AddModel(worker);
                    }

                    parent.RefreshOwner();
                    parent.Close();
                }
                else
                {
                    using (DataBase db = new DataBase())
                    {
                        worker.Name = tbName.Text;
                        worker.Surname = tbSurname.Text;
                        worker.Patronymic = tbPatronymic.Text;
                        worker.BirthDate = dtpBirthDate.Value;
                        worker.Gender = cmbGender.SelectedItem.ToString();
                        if (cmbHead.SelectedIndex >= 0)
                        {
                            worker.Head = heads[cmbHead.SelectedIndex];
                        }

                        db.EditModel<Worker>(worker);
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка. Попробуйте заполнить все поля формы");
            }
        }
    }
}
