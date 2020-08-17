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
