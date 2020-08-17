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
    class EmployeesOfManagerViewModel:ViewModelBase
    {
        EmployeesOfManager view;

        IHotelService hotelService;
        IManagerService managerService;
        IEmployeeService employeeService;

        public EmployeesOfManagerViewModel(EmployeesOfManager employeesView,
            tblManager managerLogedIn)
        {
            view = employeesView;


            hotelService = new HotelService();
            managerService = new ManagerService();
            employeeService = new EmployeeService();

            Employee = new vwEmployee();
            Manager = managerLogedIn;
            EmployeeList = managerService.GetEmployeesOfManager(Manager.HotelFloor);
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

        private List<vwEmployee> employeeList;
        public List<vwEmployee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }


        private ICommand deletManager;
        public ICommand DeletManager
        {
            get
            {
                if (deletManager == null)
                {
                    deletManager = new RelayCommand(param => DeletManagerExecute(),
                        param => CanDeletManagerExecute());
                }
                return deletManager;
            }
        }

        private void DeletManagerExecute()
        {
            try
            {
                if (Employee != null)
                {

                    MessageBoxResult result = MessageBox.Show("Are you sure that you want to " +
                        "delete this Employee?" +
                        "", "My App",
                        MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    int maintenaceId = Employee.EmployeeID;


                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            //maintenaceService.DeleteMaintenace(maintenaceId);
                            EmployeeList = employeeService.GetEmployees();

                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanDeletManagerExecute()
        {
            if (Employee == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand setSalary;
        public ICommand SetSalary
        {
            get
            {
                if (setSalary == null)
                {
                    setSalary = new RelayCommand(param => SetSalaryExecute(),
                        param => CanSetSalaryExecute());
                }
                return setSalary;
            }
        }

        private void SetSalaryExecute()
        {
            try
            {
                SetSalary setSalary = new SetSalary(Employee,Manager);
                setSalary.ShowDialog();

                EmployeeList = managerService.GetEmployeesOfManager(Manager.HotelFloor);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSetSalaryExecute()
        {

            return true;
        }

        private ICommand setAllSalaries;
        public ICommand SetAllSalaries
        {
            get
            {
                if (setAllSalaries == null)
                {
                    setAllSalaries = new RelayCommand(param => SetAllSalariesExecute(),
                        param => CanSetAllSalariesExecute());
                }
                return setAllSalaries;
            }
        }

        private void SetAllSalariesExecute()
        {
            try
            {
                SetAllSalaries setSalary = new SetAllSalaries(Manager,EmployeeList);
                setSalary.ShowDialog();

                EmployeeList = managerService.GetEmployeesOfManager(Manager.HotelFloor);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSetAllSalariesExecute()
        {

            return true;
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

        private ICommand back;
        public ICommand Back
        {
            get
            {
                if (back == null)
                {
                    back = new RelayCommand(param => BackExecute(), param => CanBackExecute());
                }
                return back;
            }
        }

        private void BackExecute()
        {
            try
            {
                ManagerView ownerView =
                    new ManagerView(Manager);
                ownerView.Show();
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanBackExecute()
        {
            return true;
        }
    }
}
