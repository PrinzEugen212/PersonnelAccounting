using PersAccounting.Enums;
using PersAccounting.Models;
using System;
using System.Collections.Generic;

namespace PersAccounting
{
    public class EmployeeManager
    {
        public static readonly List<string> Genders = new List<string>() { "Мужской", "Женский" };

        public static readonly List<string> Posts = new List<string>() { "Рабочий", "Контролер", "Руководитель отделения", "Директор" };

        public static readonly Dictionary<string, EmployeePost> EmployeesPostNameToEnumDictionary = new Dictionary<string, EmployeePost>()
        {
            { Posts[0], EmployeePost.Worker },
            { Posts[1], EmployeePost.Controller },
            { Posts[2], EmployeePost.DepartmentHead },
            { Posts[3], EmployeePost.Director }
        };

        public static readonly Dictionary<Type, int> TypeToIntDictionary = new Dictionary<Type, int>()
        {
            { typeof(Worker), 0 },
            { typeof(Controller), 1 },
            { typeof(DepartmentHead), 2 },
            { typeof(Director), 3 }
        };

        public void Raise(Person person)
        {
            switch (TypeToIntDictionary[person.GetType()])
            {
                case 0:
                    {
                        RaiseWorker(person);
                        break;
                    }
                case 1:
                    {
                        RaiseController(person);
                        break;
                    }
                case 2:
                    {
                        RaiseDepartmentHead(person);
                        break;
                    }
                case 3:
                default:
                    {
                        break;
                    }
            }
        }

        private void RaiseWorker(Person worker)
        {
            Controller controller = new Controller()
            {
                Name = worker.Name,
                Surname = worker.Surname,
                Patronymic = worker.Patronymic,
                BirthDate = worker.BirthDate,
                Gender = worker.Gender
            };

            using (DataBase db = new DataBase())
            {
                db.DeleteModel(worker);
                db.AddModel(controller);
            }
        }

        private void RaiseController(Person controller)
        {
            DepartmentHead departmentHead = new DepartmentHead()
            {
                Name = controller.Name,
                Surname = controller.Surname,
                Patronymic = controller.Patronymic,
                BirthDate = controller.BirthDate,
                Gender = controller.Gender
            };

            using (DataBase db = new DataBase())
            {
                db.DeleteModel(controller);
                db.AddModel(departmentHead);
            }
        }

        private void RaiseDepartmentHead(Person departmentHead)
        {
            Director director = new Director()
            {
                Name = departmentHead.Name,
                Surname = departmentHead.Surname,
                Patronymic = departmentHead.Patronymic,
                BirthDate = departmentHead.BirthDate,
                Gender = departmentHead.Gender
            };

            using (DataBase db = new DataBase())
            {
                db.DeleteModel(departmentHead);
                db.AddModel(director);
            }
        }
    }
}
