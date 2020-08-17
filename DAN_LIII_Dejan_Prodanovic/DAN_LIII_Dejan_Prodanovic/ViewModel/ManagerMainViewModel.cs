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
    class ManagerMainViewModel:ViewModelBase
    {
        ManagerView view;

        IHotelService hotelService;
        IManagerService managerService;

        public ManagerMainViewModel(ManagerView managerView)
        {
            view = managerView;


            hotelService = new HotelService();
            managerService = new ManagerService();

            Manager = new tblManager();
            
        }
        public ManagerMainViewModel(ManagerView managerView,tblManager managerLogedIn)
        {
            view = managerView;


            hotelService = new HotelService();
            managerService = new ManagerService();

            Manager =  managerLogedIn;
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

        private ICommand showEmployees;
        public ICommand ShowEmployees
        {
            get
            {
                if (showEmployees == null)
                {
                    showEmployees = new RelayCommand(param => ShowEmployeesExecute(),
                        param => CanShowEmployeesExecute());
                }
                return showEmployees;
            }
        }

        private void ShowEmployeesExecute()
        {
            try
            {
                EmployeesOfManager employees = new EmployeesOfManager(Manager);
                employees.Show();
                view.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanShowEmployeesExecute()
        {

            return true;
        }
    }
}
