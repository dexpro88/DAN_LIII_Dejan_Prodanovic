using DAN_LIII_Dejan_Prodanovic.Command;
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
    class OwnerViewModel:ViewModelBase
    {
        OwnerView view;
        IHotelService hotelService;


        public OwnerViewModel(OwnerView ownerViewOpen)
        {
            view = ownerViewOpen;
            hotelService = new HotelService();

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



        private ICommand addEmployee;
        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null)
                {
                    addEmployee = new RelayCommand(param => AddEmployeeExecute(),
                        param => CanAddEmployeeExecute());
                }
                return addEmployee;
            }
        }

        private void AddEmployeeExecute()
        {
            try
            {
                AddEmployee addEmployee = new AddEmployee();
                addEmployee.ShowDialog();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddEmployeeExecute()
        {

            return true;
        }

        private ICommand showManagers;
        public ICommand ShowManagers
        {
            get
            {
                if (showManagers == null)
                {
                    showManagers = new RelayCommand(param => ShowManagersExecute(),
                        param => CanShowManagersExecute());
                }
                return showManagers;
            }
        }

        private void ShowManagersExecute()
        {
            try
            {
                Managers managers = new Managers();
                managers.Show();
                view.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanShowManagersExecute()
        {

            return true;
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
                Employees employees = new Employees();
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
