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
    class EmployeeViewModel:ViewModelBase
    {
        EmployeeView view;


        public EmployeeViewModel(EmployeeView employeeViewOpen)
        {
            view = employeeViewOpen;

        }

        public EmployeeViewModel(EmployeeView employeeViewOpen,tblEmployee employeeLogedIn )
        {
            view = employeeViewOpen;
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


        private ICommand addRequest;
        public ICommand AddRequest
        {
            get
            {
                if (addRequest == null)
                {
                    addRequest = new RelayCommand(param => AddRequestExecute(),
                        param => CanAddRequestExecute());
                }
                return addRequest;
            }
        }

        private void AddRequestExecute()
        {
            try
            {
                AddRequest addRequest = new AddRequest(Employee);
                addRequest.ShowDialog();
                //view.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddRequestExecute()
        {

            return true;
        }

        private ICommand showRequests;
        public ICommand ShowRequests
        {
            get
            {
                if (showRequests == null)
                {
                    showRequests = new RelayCommand(param => ShowRequestsExecute(),
                        param => CanShowRequestsExecute());
                }
                return showRequests;
            }
        }

        private void ShowRequestsExecute()
        {
            try
            {
                RequestsOfEmployee requests = new RequestsOfEmployee(Employee);
                requests.ShowDialog();
                //view.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanShowRequestsExecute()
        {

            return true;
        }

    }
}
