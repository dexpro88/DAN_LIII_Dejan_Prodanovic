using DAN_LIII_Dejan_Prodanovic.Command;
using DAN_LIII_Dejan_Prodanovic.Model;
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
    class SalaryDetailsViewModel:ViewModelBase
    {
        SalaryDetails view;


        public SalaryDetailsViewModel(SalaryDetails salaryDetailsViewOpen)
        {
            view = salaryDetailsViewOpen;

        }

        public SalaryDetailsViewModel(SalaryDetails salaryDetailsViewOpen, 
            tblManager managerLogedIn,tblEmployee employeeLogedIn)
        {
            view = salaryDetailsViewOpen;
            Employee = employeeLogedIn;
            Manager = managerLogedIn;
            Experience = (decimal)Manager.Experience * 0.75M;
            int managerLevel = CountManagerLevel(Manager);

            Qualification = 0.15M * (decimal)managerLevel;
            if (Employee.Gender.Equals("m"))
            {
                P = 1.12M;
            }
            else
            {
                P = 1.15M;
            }
        }

        private tblEmployee employee;
        public tblEmployee Employee
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

        private tblManager manager;
        public tblManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private decimal experience;
        public decimal Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
                OnPropertyChanged("Experience");
            }
        }

        private decimal qualification;
        public decimal Qualification
        {
            get
            {
                return qualification;
            }
            set
            {
                qualification = value;
                OnPropertyChanged("Qualification");
            }
        }
        private decimal p;
        public decimal P
        {
            get
            {
                return p;
            }
            set
            {
                p = value;
                OnPropertyChanged("P");
            }
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

        private int CountManagerLevel(tblManager manager)
        {
            int level = 1;
            switch (manager.QualificationsLevel)
            {
                case "I":
                    level = 1;
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
