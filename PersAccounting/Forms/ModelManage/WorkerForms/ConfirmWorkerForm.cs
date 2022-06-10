using PersAccounting.DB;
using PersAccounting.Enums;
using PersAccounting.Models;
using PersAccounting.Models.Employees;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PersAccounting.Forms.ModelManage.WorkerForms
{
    public partial class ConfirmWorkerForm : Form
    {
        private ConfirmFormMode formMode;
        private Worker worker;
        private const string confirmDeleteText = "Вы уверены что хотите удалить данного рабочего?";
        private const string confirmRaiseText = "Вы уверены что хотите повысить данного рабочего?";

        public ConfirmWorkerForm(Worker worker, ConfirmFormMode formMode)
        {
            InitializeComponent();
            this.formMode = formMode;
            this.worker = worker;
            using (DataBase db = new DataBase())
            {
                this.worker.Head = db.DepartmentHeads.Where(h => h.Id == worker.HeadId).FirstOrDefault();
            }
            DisplayWorker();
        }

        private void DisplayWorker()
        {
            lName.Text = worker.Name;
            lSurname.Text = worker.Surname;
            lPatronymic.Text = worker.Patronymic;
            lBirthDate.Text = worker.BirthDate.ToString("yyyy-MM-dd");
            lGender.Text = worker.Gender;
            if (worker.Head is not null)
            {
                lHead.Text = $"{worker.Head.Surname} {worker.Head.Name} {worker.Head.Patronymic}";
            }
            else
            {
                lHead.Text = "Нет";
            }

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
