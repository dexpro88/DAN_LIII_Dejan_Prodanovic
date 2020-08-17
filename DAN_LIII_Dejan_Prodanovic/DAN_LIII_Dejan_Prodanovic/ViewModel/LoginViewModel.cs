using DAN_LIII_Dejan_Prodanovic.Command;
using DAN_LIII_Dejan_Prodanovic.Model;
using DAN_LIII_Dejan_Prodanovic.Service;
using DAN_LIII_Dejan_Prodanovic.Utility;
using DAN_LIII_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_LIII_Dejan_Prodanovic.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        LoginView view;
        Dictionary<string, string> ownerData = new Dictionary<string, string>();
        //List<tblUser> users;
        IHotelService hotelService;
        IManagerService managerService;

        public LoginViewModel(LoginView loginView)
        {
            view = loginView;
            ReadOwnerUsernameAndPass();
            hotelService = new HotelService();
            managerService = new ManagerService();
            //users = hotelService.GetUsers();
        }

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string someProperty]
        {
            get
            {

                return string.Empty;
            }
        }



        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (submitCommand == null)
                {
                    submitCommand = new RelayCommand(Submit);
                    return submitCommand;
                }
                return submitCommand;
            }
        }

        void Submit(object obj)
        {

            string encryptedString = (obj as PasswordBox).Password;

            string password = EncryptionHelper.Encrypt(encryptedString);

            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Wrong user name or password");
                return;
            }
            if (UserName.Equals(ownerData["username"]) &&
                encryptedString.Equals(ownerData["password"]))
            {
                OwnerView ownerView = new OwnerView();
                view.Close();
                ownerView.Show();
                return;
            }

            tblUser user =  hotelService.GetGetUserByUserNameAndPass(UserName, password);

            if (user!=null)
            {
                tblEmployee employee = hotelService.GetEmloyeByUserId(user.ID);

                
                if (employee!=null)
                {
                    
                    EmployeeView employeeView = new EmployeeView();
                    employeeView.Show();
                    view.Close();
                    return;
                }

                tblManager manager = managerService.GetManagerByUserId(user.ID);

                if (manager!=null)
                {
                    ManagerView managerView = new ManagerView(manager);
                    managerView.Show();
                    view.Close();
                    return;
                }


            }
            //foreach (var user in users)
            //{
            //    if (user.Username.Equals(UserName) || user.Passwd.Equals(password))
            //    {

            //        tblEmployee employee = hotelService.GetEmloyeByUserId(user.ID);
            //        if (employee != null)
            //        {
            //            EmployeeView empView = new EmployeeView();
            //            empView.Show();
            //            view.Close();
            //        }
            //        else
            //        {
            //            ManagerView manView = new ManagerView();
            //            manView.Show();
            //            view.Close();
            //        }
            //        return;
            //    }
            //}
            MessageBox.Show("Wrong user name or password");


            //else if (UserName.Equals(UserConstants.STOREKEEPER_USER_NAME) &&
            //    password.Equals(UserConstants.STOREKEEPER_PASSWORD))
            //{
            //    StorekeeperMainView storekeeperView = new StorekeeperMainView();
            //    view.Close();
            //    storekeeperView.Show();

            //}



        }

        private void ReadOwnerUsernameAndPass()
        {
            try
            {

                using (StreamReader sr = new StreamReader(@"..\..\OwnerAccess.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fileData = line.Split(':');

                        ownerData.Add(fileData[0], fileData[1]);

                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }
    }
}
