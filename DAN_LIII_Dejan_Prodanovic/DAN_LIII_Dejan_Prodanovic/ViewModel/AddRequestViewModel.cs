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
    class AddRequestViewModel:ViewModelBase
    {
        AddRequest view;
        IHotelService service;
        IEmployeeService employeeService;
        
        public AddRequestViewModel(AddRequest addRequestView,tblEmployee employeeLogedIn)
        {
            view = addRequestView;
            service = new HotelService();
            employeeService = new EmployeeService();

            
            Employee = employeeLogedIn;

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

        private DateTime startDate;
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                OnPropertyChanged("EndDate");
            }
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

                int result = DateTime.Compare(StartDate, EndDate);
                
                if (result >= 0)
                {
                    MessageBox.Show("End date must be after start date");
                    return;
                }
                DateTime today = DateTime.Now;
                DateTime minStartDate = today.AddDays(20);

                result = DateTime.Compare(StartDate, minStartDate);
                if (result<0)
                {
                    MessageBox.Show("Start date must be at least 20 days from today");
                    return;
                }

                tblVacationRequest newRequest = new tblVacationRequest();
                newRequest.RequestState = "waiting for approval";
                newRequest.FirstDayDate = StartDate;
                newRequest.LastDayDate = EndDate;
                newRequest.EmployeeID = Employee.EmployeeID;

                employeeService.CreateRequest(newRequest);

                MessageBox.Show("You crated vacation request");
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

    }
}
