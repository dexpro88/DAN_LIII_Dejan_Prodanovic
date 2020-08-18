using DAN_LIII_Dejan_Prodanovic.Command;
using DAN_LIII_Dejan_Prodanovic.Dialog;
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
    class RequestsForManagerViewModel:ViewModelBase
    {
        RequestsForManager view;

        IHotelService hotelService;
        IManagerService managerService;
        IEmployeeService employeeService;

        public RequestsForManagerViewModel(RequestsForManager requestsForManagerView,
            tblManager managerLogedIn)
        {
            view = requestsForManagerView;


            hotelService = new HotelService();
            managerService = new ManagerService();
            employeeService = new EmployeeService();

            Manager = managerLogedIn;
            allRequests = managerService.GetAllRequests();
            RequestList = GetRequestsForManager();
            Request = new tblVacationRequest();
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
        List<tblVacationRequest> allRequests;

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

        private tblVacationRequest request;
        public tblVacationRequest Request
        {
            get
            {
                return request;
            }
            set
            {
                request = value;
                OnPropertyChanged("Request");
            }
        }
        private ICommand refuse;
        public ICommand Refuse
        {
            get
            {
                if (refuse == null)
                {
                    refuse = new RelayCommand(param => RefuseExecute(),
                        param => CanRefuseExecute());
                }
                return refuse;
            }
        }

        private void RefuseExecute()
        {
            try
            {
                InputDialogSample inputDialog = new InputDialogSample("Please enter reason" +
                    " for refusing  this request:");
                if (inputDialog.ShowDialog() == true)
                {
                   string reason = inputDialog.Answer;
                    Request.ReasonOfRefuse = reason;
                    employeeService.RefuseRequest(Request);
                    allRequests = managerService.GetAllRequests();
                    RequestList = GetRequestsForManager();
                    return;
                }
                   
                //view.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanRefuseExecute()
        {
            if (Request!=null)
            {
                if (!string.IsNullOrEmpty(Request.RequestState))
                {
                    if (Request.RequestState.Equals("Refused") || (Request.RequestState.Equals("Approved")))
                    {
                        return false;
                    }

                }
            }
           
           
            return true;
        }

        private ICommand approve;
        public ICommand Approve
        {
            get
            {
                if (approve == null)
                {
                    approve = new RelayCommand(param => ApproveExecute(),
                        param => CanApproveExecute());
                }
                return approve;
            }
        }

        private void ApproveExecute()
        {
            try
            {
                               
                   
                    employeeService.ApproveRequest(Request);
                    allRequests = managerService.GetAllRequests();
                    RequestList = GetRequestsForManager();
                 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanApproveExecute()
        {
            if (Request != null)
            {
                if (!string.IsNullOrEmpty(Request.RequestState))
                {
                    if (Request.RequestState.Equals("Refused") || (Request.RequestState.Equals("Approved")))
                    {
                        return false;
                    }

                }
            }
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

        private List<tblVacationRequest> GetRequestsForManager()
        {
            List<tblVacationRequest> requestsOfManager = new List<tblVacationRequest>();
            foreach (var req in allRequests)
            {
                tblEmployee empl = employeeService.GetEmloyeByEmployeeId((int)req.EmployeeID);
                if (empl.HotelFloor.Equals(Manager.HotelFloor))
                {
                    requestsOfManager.Add(req);
                }
            }
            return requestsOfManager;
        }
    }
}
