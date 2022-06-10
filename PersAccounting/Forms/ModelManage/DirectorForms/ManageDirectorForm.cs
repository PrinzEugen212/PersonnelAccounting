using PersAccounting.DB;
using PersAccounting.Enums;
using PersAccounting.Models;
using PersAccounting.Models.Employees;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersAccounting.Forms.ModelManage.DirectorForms
{
    public partial class ManageDirectorForm : Form
    {
        private ManageFormMode formMode;
        private Director director;
        private List<string> genders = EmployeeManager.Genders;
        private AddForm parent;

        public ManageDirectorForm(AddForm parent) : this(ManageFormMode.Add)
        {
            this.parent = parent;
        }

        public ManageDirectorForm(Director director) : this(ManageFormMode.Edit)
        {
            this.director = director;
            DisplayDirector();
        }

        private ManageDirectorForm(ManageFormMode formMode)
        {
            InitializeComponent();
            this.formMode = formMode;
            cmbGender.Items.AddRange(genders.ToArray());
        }

        private void DisplayDirector()
        {
            tbName.Text = director.Name;
            tbSurname.Text = director.Surname;
            tbPatronymic.Text = director.Patronymic;
            dtpBirthDate.Value = director.BirthDate;
            cmbGender.SelectedItem = director.Gender;
            tbPost.Text = director.Post;
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (formMode == ManageFormMode.Add)
                {
                    using (DataBase db = new DataBase())
                    {
                        Director director = new Director()
                        {
                            Name = tbName.Text,
                            Surname = tbSurname.Text,
                            Patronymic = tbPatronymic.Text,
                            BirthDate = dtpBirthDate.Value,
                            Gender = cmbGender.SelectedItem.ToString(),
                            Post = tbPost.Text
                        };

                        db.AddModel<Director>(director);
                    }

                    parent.RefreshOwner();
                    parent.Close();
                }
                else
                {
                    using (DataBase db = new DataBase())
                    {
                        director.Name = tbName.Text;
                        director.Surname = tbSurname.Text;
                        director.Patronymic = tbPatronymic.Text;
                        director.BirthDate = dtpBirthDate.Value;
                        director.Gender = cmbGender.SelectedItem.ToString();
                        director.Post = tbPost.Text;
                        db.EditModel<Director>(director);
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
