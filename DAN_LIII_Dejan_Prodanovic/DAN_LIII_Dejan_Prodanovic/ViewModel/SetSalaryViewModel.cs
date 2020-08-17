using DAN_LIII_Dejan_Prodanovic.Command;
using DAN_LIII_Dejan_Prodanovic.Model;
using DAN_LIII_Dejan_Prodanovic.Service;
using DAN_LIII_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_LIII_Dejan_Prodanovic.ViewModel
{
    class SetSalaryViewModel:ViewModelBase
    {
        SetSalary view;
        IEmployeeService service;
        
        

        public SetSalaryViewModel(SetSalary employeeOpen, vwEmployee employeeLogedIn,
            tblManager managerLogedIn)
        {
            view = employeeOpen;
            service = new EmployeeService();
           
            Employee = employeeLogedIn;
            Manager = managerLogedIn;
        }


        tblManager Manager;
        private vwEmployee employee;
        public vwEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }


        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }


        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }

        private void LogoutExecute()
        {
            try
            {
                LoginView loginView = new LoginView();
                loginView.Show();
                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanLogoutExecute()
        {
            return true;
        }


        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(SaveExecute, CanSaveExecute);
                }
                return save;
            }
        }

        private void SaveExecute(object parameter)
        {
            try
            {





                if (Number<=1||Number>1000)
                {
                    MessageBox.Show("You can enter number from 2 to 999");
                    return;
                }



                decimal salary = CountSalary(Number);

                service.SetSalary(Employee,salary);
                //service.AddEmployee(Employee);

                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object param)
        {

            
                return true;
            
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }

        private decimal CountSalary(int num)
        {

            decimal salary;
            int level = CountManagerLevel(Manager);
            decimal p;
            if (Employee.Gender.Equals("m"))
            {
                p = 1.12M;
            }
            else
            {
                p = 1.15M;
            }

            salary = 1000M * (0.75M * (int)Manager.Experience) * 0.15M * level * p +
                (decimal)num;

            return salary;
        }

        private int CountManagerLevel(tblManager manager)
        {
            int level = 1;
            switch (manager.QualificationsLevel)
            {
                case "I":
                    level =1;
                    break;
                case "II":
                    level = 2;
                    break;
                case "III":
                    level = 3;
                    break;
                case "IV":
                    level = 4;
                    break;
                case "V":
                    level = 5;
                    break;
                case "VI":
                    level = 6;
                    break;
                case "VII":
                    level = 7;
                    break;
                default:
                    level = 1;
                    break;
            }
            return level;
        }
       
    }
}
