using PersAccounting.Forms.ModelManage.ControllerForms;
using PersAccounting.Forms.ModelManage.DepartmentHeadForms;
using PersAccounting.Forms.ModelManage.DirectorForms;
using PersAccounting.Forms.ModelManage.WorkerForms;
using PersAccounting.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersAccounting.Forms
{
    public partial class EmployeeCard : UserControl
    {
        private Person person;
        private Dictionary<Type, int> typeDictionary = EmployeeManager.TypeToIntDictionary;

        public EmployeeCard(Person person)
        {
            InitializeComponent();
            this.person = person;
            DisplayPerson();
        }

        public override void Refresh()
        {
            using (DataBase db = new DataBase())
            {
                person = db.Employees.Find(person.Id);
                DisplayPerson();
            }
        }

        private void DisplayPerson()
        {
            lSurname.Text = person.Surname;
            lBirthDate.Text = person.BirthDate.ToString("yyyy-MM-dd");
            lGender.Text = person.Gender;
            int typeNumber = EmployeeManager.TypeToIntDictionary[person.GetType()];
            lPost.Text = EmployeeManager.Posts[typeNumber];
        }

        private void bChange_Click(object sender, EventArgs e)
        {
            switch (typeDictionary[person.GetType()])
            {
                case 0:
                    {
                        ManageWorkerForm form = new ManageWorkerForm(person as Worker);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            Refresh();
                        }
                        break;
                    }
                case 1:
                    {
                        ManageControllerForm form = new ManageControllerForm(person as Controller);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            Refresh();
                        }
                        break;
                    }
                case 2:
                    {
                        ManageDepHeadForm form = new ManageDepHeadForm(person as DepartmentHead);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            Refresh();
                        }
                        break;
                    }
                case 3:
                    {
                        ManageDirectorForm form = new ManageDirectorForm(person as Director);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            Refresh();
                        }
                        break;
                    }
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            switch (typeDictionary[person.GetType()])
            {
                case 0:
                    {
                        Worker worker = person as Worker;
                        ConfirmWorkerForm form = new ConfirmWorkerForm(worker, ConfirmFormMode.Delete);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            using (DataBase db = new DataBase())
                            {
                                db.DeleteModel<Worker>(worker);
                            }
                        }

                        Parent.Parent.Refresh();
                        break;
                    }
                case 1:
                    {
                        Controller controller = person as Controller;
                        ConfirmControllerForm form = new ConfirmControllerForm(controller, ConfirmFormMode.Delete);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            using (DataBase db = new DataBase())
                            {
                                db.DeleteModel<Controller>(controller);
                            }
                        }
                        Parent.Parent.Refresh();
                        break;
                    }
                case 2:
                    {
                        DepartmentHead departmentHead = person as DepartmentHead;
                        ConfirmDepHeadForm form = new ConfirmDepHeadForm(departmentHead, ConfirmFormMode.Delete);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            using (DataBase db = new DataBase())
                            {
                                db.DeleteModel<DepartmentHead>(departmentHead);
                            }
                        }

                        Parent.Parent.Refresh();
                        break;
                    }
                case 3:
                    {
                        Director director = person as Director;
                        ConfirmDirectorForm form = new ConfirmDirectorForm(director, ConfirmFormMode.Delete);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            using (DataBase db = new DataBase())
                            {
                                db.DeleteModel<Director>(director);
                            }
                        }

                        Parent.Parent.Refresh();
                        break;
                    }
            }
        }

        private void bRaise_Click(object sender, EventArgs e)
        {
            switch (typeDictionary[person.GetType()])
            {
                case 0:
                    {
                        Worker worker = person as Worker;
                        ConfirmWorkerForm form = new ConfirmWorkerForm(worker, ConfirmFormMode.Raise);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            new EmployeeManager().Raise(person);
                            Parent.Parent.Refresh();
                        }

                        break;
                    }
                case 1:
                    {
                        Controller controller = person as Controller;
                        ConfirmControllerForm form = new ConfirmControllerForm(controller, ConfirmFormMode.Raise);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            new EmployeeManager().Raise(person);
                            Parent.Parent.Refresh();
                        }

                        break;
                    }
                case 2:
                    {
                        DepartmentHead departmentHead = person as DepartmentHead;
                        ConfirmDepHeadForm form = new ConfirmDepHeadForm(departmentHead, ConfirmFormMode.Raise);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            new EmployeeManager().Raise(person);
                            Parent.Parent.Refresh();
                        }

                        break;
                    }
                case 3:
                    {
                        MessageBox.Show("Директора нельзя повысить");
                        break;
                    }
            }
        }
    }
}
