using DAN_LIII_Dejan_Prodanovic.Command;
using DAN_LIII_Dejan_Prodanovic.Model;
using DAN_LIII_Dejan_Prodanovic.Service;
using DAN_LIII_Dejan_Prodanovic.Utility;
using DAN_LIII_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_LIII_Dejan_Prodanovic.ViewModel
{
    class AddEmployeeViewModel:ViewModelBase
    {
        AddEmployee view;
        IHotelService service;

        List<string> engagements = new List<string>() {"Cooking","Cleaning" ,"Monitoring",
        "Reporting"};
        List<string> floors = new List<string>() { "I", "II", "III", "IV", "V" };



        public AddEmployeeViewModel(AddEmployee employeeOpen)
        {
            view = employeeOpen;
            service = new HotelService();
            FloorsList = floors;
            EngagementList = engagements;
            User = new tblUser();
            Employee = new tblEmployee();

        }

        private tblUser user;
        public tblUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
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



        private string floor;
        public string Floor
        {
            get
            {
                return floor;
            }
            set
            {
                floor = value;
                OnPropertyChanged("Floor");
            }
        }
        private List<string> floorsList;
        public List<string> FloorsList
        {
            get
            {
                return floorsList;
            }
            set
            {
                floorsList = value;
                OnPropertyChanged("FloorsList");
            }
        }

        private string engagement;
        public string Engagement
        {
            get
            {
                return engagement;
            }
            set
            {
                engagement = value;
                OnPropertyChanged("Engagement");
            }
        }
        private List<string> engagementList;
        public List<string> EngagementList
        {
            get
            {
                return engagementList;
            }
            set
            {
                engagementList = value;
                OnPropertyChanged("EngagementList");
            }
        }

        private string gender = "male";
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
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

                var passwordBox = parameter as PasswordBox;
                var password = passwordBox.Password;

                string encryptedString = EncryptionHelper.Encrypt(password);

                User.Passwd = encryptedString;

                User = service.AddUser(User);

                Employee.HotelFloor = Floor;

                Employee.UserId = User.ID;


                if (Gender.Equals("male"))
                {
                    Employee.Gender = "m";
                }
                else
                {
                    Employee.Gender = "f";
                }
                service.AddEmployee(Employee);

                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object param)
        {

            if (String.IsNullOrEmpty(User.FullName) || String.IsNullOrEmpty(User.Username))
            {
                return false;
            }
            else
            {
                return true;
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


        private void ChooseGenderExecute(object parameter)
        {
            Gender = (string)parameter;
        }

        private bool CanChooseGenderExecute(object parameter)
        {
            if (parameter != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
