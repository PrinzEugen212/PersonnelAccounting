using PersAccounting.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PersAccounting.Forms.ModelManage.ControllerForms
{
    public partial class ConfirmControllerForm : Form
    {
        private ConfirmFormMode formMode;
        private Controller controller;
        private const string confirmDeleteText = "Вы уверены что хотите удалить данного контролера?";
        private const string confirmRaiseText = "Вы уверены что хотите повысить данного контролера?";

        public ConfirmControllerForm(Controller controller, ConfirmFormMode formMode)
        {
            InitializeComponent();
            this.formMode = formMode;
            this.controller = controller;
            using (DataBase db = new DataBase())
            {
                this.controller.Head = db.DepartmentHeads.Where(h => h.Id == controller.HeadId).FirstOrDefault();
            }

            DisplayController();
        }

        private void DisplayController()
        {
            lName.Text = controller.Name;
            lSurname.Text = controller.Surname;
            lPatronymic.Text = controller.Patronymic;
            lBirthDate.Text = controller.BirthDate.ToString();
            lGender.Text = controller.Gender;
            if (controller.Head is not null)
            {
                lHead.Text = $"{controller.Head.Surname} {controller.Head.Name} {controller.Head.Patronymic}";
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
