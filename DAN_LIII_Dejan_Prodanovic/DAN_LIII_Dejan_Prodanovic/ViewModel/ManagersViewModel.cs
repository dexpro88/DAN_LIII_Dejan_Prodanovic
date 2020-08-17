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
    class ManagersViewModel:ViewModelBase
    {
        Managers view;

        IHotelService hotelService;
        IManagerService managerService;

        public ManagersViewModel(Managers managersView)
        {
            view = managersView;


            hotelService = new HotelService();
            managerService = new ManagerService();

            Manager = new vwManager();
            ManagerList = managerService.GetManagers();
        }
       

        private vwManager manager;
        public vwManager Manager
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

        private List<vwManager> managerList;
        public List<vwManager> ManagerList
        {
            get
            {
                return managerList;
            }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
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
                if (Manager != null)
                {

                    MessageBoxResult result = MessageBox.Show("Are you sure that you want to " +
                        "delete this Manager?" +
                        "", "My App",
                        MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    int maintenaceId = Manager.ID;


                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            //maintenaceService.DeleteMaintenace(maintenaceId);
                            ManagerList = managerService.GetManagers();

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
            if (Manager == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand addManager;
        public ICommand AddManager
        {
            get
            {
                if (addManager == null)
                {
                    addManager = new RelayCommand(param => AddManagerExecute(),
                        param => CanAddManagerExecute());
                }
                return addManager;
            }
        }

        private void AddManagerExecute()
        {
            try
            {
                AddManager addManager = new AddManager();
                addManager.ShowDialog();

                ManagerList = managerService.GetManagers();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddManagerExecute()
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
                OwnerView ownerView =
                    new OwnerView();
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
