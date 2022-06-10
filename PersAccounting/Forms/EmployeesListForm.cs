using Microsoft.EntityFrameworkCore;
using PersAccounting.DB;
using PersAccounting.Models;
using PersAccounting.Models.Employees;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PersAccounting.Forms
{
    public partial class EmployeesListForm : Form
    {
        private List<string> departments;

        public EmployeesListForm()
        {
            InitializeComponent();
            LoadDepartments();
            cmbEmployeePost.Items.AddRange(EmployeeManager.Posts.ToArray());
            SetDepartmentComboBoxItems();
            LoadAllEmployees();
        }

        public void LoadAllEmployees()
        {
            using (DataBase db = new DataBase())
            {
                List<Person> employees = db.Employees.ToList();
                AddCards(employees);
            }
        }

        public void LoadEmployeesByDepartment(string department)
        {
            List<DepartmentHead> departmentHeads = null;
            List<Worker> workers = null;
            List<Controller> controllers = null;
            using (DataBase db = new DataBase())
            {
                departmentHeads = db.DepartmentHeads.Where(d => d.Department == department).ToList();
                workers = db.Workers.Include(w => w.Head).Where(w => w.Head.Department == department).ToList();
                controllers = db.Controllers.Include(c => c.Head).Where(c => c.Head.Department == department).ToList();
            }

            ClearCards();
            AddCards(departmentHeads);
            AddCards(workers);
            AddCards(controllers);
        }

        public void LoadEmployeesByType<T>() where T : Person
        {
            ClearCards();
            using (DataBase db = new DataBase())
            {
                List<T> employees = db.Employees.OfType<T>().ToList();
                AddCards(employees);
            }
        }

        public override void Refresh()
        {
            UnselectComboBoxexItems();
            ClearCards();
            LoadAllEmployees();
            LoadDepartments();
            SetDepartmentComboBoxItems();
        }

        private void UnselectComboBoxexItems()
        {
            cmbEmployeeDepartment.SelectedItem = null;
            cmbEmployeePost.SelectedItem = null;
        }

        private void AddCards(IEnumerable<Person> employees)
        {
            if (employees is null || employees.Count() == 0)
            {
                return;
            }

            foreach (Person employee in employees)
            {
                EmployeeCard employeeCard = new EmployeeCard(employee);
                employeeCard.Parent = this;
                flpEmployeeList.Controls.Add(employeeCard);
            }
        }

        private void ClearCards()
        {
            flpEmployeeList.Controls.Clear();
        }

        private void SetDepartmentComboBoxItems()
        {
            cmbEmployeeDepartment.Items.Clear();
            cmbEmployeeDepartment.Items.AddRange(departments.ToArray());
        }

        private void LoadDepartments()
        {
            using (DataBase db = new DataBase())
            {
                departments = db.DepartmentHeads.Select(x => x.Department).Distinct().ToList();
                departments.RemoveAll(x => x is null);
            }
        }

        private void cmbEmployeePost_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbEmployeePost.SelectedItem is null)
            {
                return;
            }

            cmbEmployeeDepartment.SelectedItem = null;
            LoadBySelectedType();
        }

        private void LoadBySelectedType()
        {
            switch (EmployeeManager.EmployeesPostNameToEnumDictionary[cmbEmployeePost.SelectedItem?.ToString()])
            {
                case Enums.EmployeePost.Worker:
                    LoadEmployeesByType<Worker>();
                    break;
                case Enums.EmployeePost.Controller:
                    LoadEmployeesByType<Controller>();
                    break;
                case Enums.EmployeePost.DepartmentHead:
                    LoadEmployeesByType<DepartmentHead>();
                    break;
                case Enums.EmployeePost.Director:
                    LoadEmployeesByType<Director>();
                    break;
                default:
                    break;
            }
        }

        private void cmbEmployeeDepartment_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbEmployeeDepartment.SelectedItem is null)
            {
                return;
            }

            cmbEmployeePost.SelectedItem = null;
            LoadEmployeesByDepartment(cmbEmployeeDepartment.SelectedItem.ToString());
        }

        private void bCancel_Click(object sender, System.EventArgs e)
        {
            UnselectComboBoxexItems();
            ClearCards();
            LoadAllEmployees();
        }
    }
}
