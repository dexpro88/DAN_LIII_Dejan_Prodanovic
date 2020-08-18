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
    class RequestsOfEmployeeViewModel:ViewModelBase
    {
        RequestsOfEmployee view;

        IHotelService hotelService;
        IManagerService managerService;
        IEmployeeService employeeService;

        public RequestsOfEmployeeViewModel(RequestsOfEmployee requestsOfEmployeeView,
            tblEmployee employeeLogedIn)
        {
            view = requestsOfEmployeeView;


            hotelService = new HotelService();
            managerService = new ManagerService();
            employeeService = new EmployeeService();

            Employee = employeeLogedIn;
            RequestList = employeeService.GetVacationsByEmployeeId(Employee.EmployeeID);
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

        private List<tblVacationRequest> requestList;
        public List<tblVacationRequest> RequestList
        {
            get
            {
                return requestList;
            }
            set
            {
                requestList = value;
                OnPropertyChanged("RequestList");
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
    }
}
