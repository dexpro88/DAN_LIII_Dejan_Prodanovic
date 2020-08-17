using DAN_LIII_Dejan_Prodanovic.Command;
using DAN_LIII_Dejan_Prodanovic.Model;
using DAN_LIII_Dejan_Prodanovic.Service;
using DAN_LIII_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_LIII_Dejan_Prodanovic.ViewModel
{
    class SetAllSalariesViewModel:ViewModelBase
    {
        SetAllSalaries view;
        IEmployeeService service;
        private int currentProgress;
        private BackgroundWorker worker = new BackgroundWorker();
        Random rnd = new Random();

        bool disableButton = false;

        public SetAllSalariesViewModel(SetAllSalaries employeeOpen,
            tblManager managerLogedIn,List<vwEmployee>employees)
        {
            view = employeeOpen;
            service = new EmployeeService();

          
            Manager = managerLogedIn;
            EmployeeList = employees;

            worker.DoWork += DoWork;
            worker.ProgressChanged += ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted += RunWorkerCompleted;
            CurrentProgress = 0;
          
            //PrintExecute();  trebaposle
            
        }


        tblManager Manager;
        List<vwEmployee> EmployeeList;


        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged("Number");
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

                if (Number <= 1 || Number > 1000)
                {
                    MessageBox.Show("You can enter number from 2 to 999");
                    return;
                }


                PrintExecute();
                //decimal salary = CountSalary(Number);

                //service.SetSalary(Employee, salary);
                //service.AddEmployee(Employee);

                disableButton = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object param)
        {

            if (disableButton)
            {
                return false;
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

        private decimal CountSalary(int num,vwEmployee Employee)
        {
            decimal salary;
            int level = CountManagerLevel(Manager);
            decimal p;
            if (Employee.Gender.Equals("m"))
            {
                p = 1.12M;
            }
            else
            {
                p = 1.15M;
            }
            double randomDouble = rnd.NextDouble();
            if (randomDouble < 0.5)
            {
                randomDouble += 0.4;
            }
            salary = (decimal)randomDouble* 1000M * (0.75M * (int)Manager.Experience) * 0.15M * level * p +
                (decimal)num;
            salary = decimal.Round(salary,2);
            return salary;
        }

        private int CountManagerLevel(tblManager manager)
        {
            int level = 1;
            switch (manager.QualificationsLevel)
            {
                case "I":
                    level = 1;
                    break;
                case "II":
                    level = 2;
                    break;
                case "III":
                    level = 3;
                    break;
                case "IV":
                    level = 4;
                    break;
                case "V":
                    level = 5;
                    break;
                case "VI":
                    level = 6;
                    break;
                case "VII":
                    level = 7;
                    break;
                default:
                    level = 1;
                    break;
            }
            return level;
        }

        private string percentage;
        public string Percentage
        {
            get
            {
                return percentage;
            }
            set
            {
                percentage = value;
                OnPropertyChanged("Percentage");
            }
        }

        /// <summary>
        /// current progress of writing to files
        /// </summary>
        public int CurrentProgress
        {
            get { return currentProgress; }
            private set
            {
                if (currentProgress != value)
                {
                    currentProgress = value;
                    OnPropertyChanged("CurrentProgress");
                }
            }
        }

        

 

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CurrentProgress = e.ProgressPercentage;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            int counter = 0;
            foreach (var empl in EmployeeList)
            {
                 
                decimal salary = CountSalary(Number, empl);
                 
                service.SetSalary(empl, salary);
                Thread.Sleep(1000);
                counter++;
                double postot = ((double)counter / EmployeeList.Count) * 100;
                if (postot>=100)
                {
                    CurrentProgress = 100;
                }
                else
                {
                    CurrentProgress = (int)postot;
                }
             
                worker.ReportProgress(CurrentProgress);
                Percentage = ((int)postot).ToString() + "%";
                
            }
            //CurrentProgress = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    CurrentProgress += 10;
            //    worker.ReportProgress(CurrentProgress);
            //    Percentage = ((int)CurrentProgress).ToString() + "%";
            //    Thread.Sleep(1000);
            //}



        }

        
        static void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            { }
            else if (e.Error != null)
            {
                Console.WriteLine("Printer exception " + e.Error.ToString());
            }

            else
            {
            }
          

        }


        private void PrintExecute()
        {
            try
            {






                 

                DoStuff();
               


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        
        private ICommand stopPrinting;
        public ICommand StopPrinting
        {
            get
            {
                if (stopPrinting == null)
                {
                    stopPrinting = new RelayCommand(param => StopPrintingExecute(), param => CanStopPrintingxecute());
                }
                return stopPrinting;
            }
        }

        private void StopPrintingExecute()
        {
            try
            {

                if (worker.IsBusy) worker.CancelAsync();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanStopPrintingxecute()
        {


            if (!worker.IsBusy)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void DoStuff()
        {


            worker.RunWorkerAsync();

        }

    }
}
