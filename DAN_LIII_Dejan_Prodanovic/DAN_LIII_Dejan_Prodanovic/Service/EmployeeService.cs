using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAN_LIII_Dejan_Prodanovic.Model;

namespace DAN_LIII_Dejan_Prodanovic.Service
{
    class EmployeeService : IEmployeeService
    {
        public void ApproveRequest(tblVacationRequest request)
        {
            try
            {
                using (MyHotelDbEntities context = new MyHotelDbEntities())
                {

                   
                    tblVacationRequest requestInDb = (from x in context.tblVacationRequests
                                                      where x.ID == request.ID
                                                      select x).First();

                     

                    requestInDb.RequestState = "Approved";
                   

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());

            }
        }

        public void CreateRequest(tblVacationRequest request)
        {
            try
            {
                using (MyHotelDbEntities context = new MyHotelDbEntities())
                {

                    tblVacationRequest newRequest = new tblVacationRequest();
                    newRequest.FirstDayDate = request.FirstDayDate;
                    newRequest.LastDayDate = request.LastDayDate;
                    newRequest.RequestState = request.RequestState;
                    newRequest.ReasonOfRefuse = request.ReasonOfRefuse;
                    newRequest.ReasonOfDelete = request.ReasonOfDelete;
                    newRequest.EmployeeID = request.EmployeeID;


                    context.tblVacationRequests.Add(newRequest);
                    context.SaveChanges();
                    

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                
            }
        }

        public tblEmployee GetEmloyeByEmployeeId(int employeeId)
        {
            try
            {
                using (MyHotelDbEntities context = new MyHotelDbEntities())
                {


                    tblEmployee user = (from x in context.tblEmployees
                                        where x.EmployeeID == employeeId
                                        select x).First();

                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwEmployee> GetEmployees()
        {
            try
            {
                using (MyHotelDbEntities context = new MyHotelDbEntities())
                {
                    List<vwEmployee> list = new List<vwEmployee>();
                    list = (from x in context.vwEmployees select x).ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblVacationRequest> GetVacationsByEmployeeId(int employeeId)
        {
            try
            {
                using (MyHotelDbEntities context = new MyHotelDbEntities())
                {
                    List<tblVacationRequest> list = new List<tblVacationRequest>();
                    list = (from x in context.tblVacationRequests
                            where x.EmployeeID == employeeId
                            select x).ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public void RefuseRequest(tblVacationRequest request)
        {
            try
            {
                using (MyHotelDbEntities context = new MyHotelDbEntities())
                {

                    //MessageBox.Show("1");
                    tblVacationRequest requestInDb = (from x in context.tblVacationRequests
                                        where x.ID == request.ID
                                               select x).First();

                    //MessageBox.Show("2");

                    requestInDb.RequestState = "Refused";
                    requestInDb.ReasonOfRefuse = request.ReasonOfRefuse;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                 
            }
        }

        public void SetSalary(vwEmployee employee, decimal salary)
        {
            try
            {
                using (MyHotelDbEntities context = new MyHotelDbEntities())
                {

                    
                    tblEmployee employeeInDb = (from x in context.tblEmployees
                                       where x.EmployeeID == employee.EmployeeID
                                       select x).First();

                   

                    employeeInDb.Salary = salary;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                
            }
        }
    }
}
