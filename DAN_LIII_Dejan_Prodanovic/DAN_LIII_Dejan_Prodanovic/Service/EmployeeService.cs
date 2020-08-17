using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAN_LIII_Dejan_Prodanovic.Model;

namespace DAN_LIII_Dejan_Prodanovic.Service
{
    class EmployeeService : IEmployeeService
    {
        public List<vwEmployee> GetEmployees()
        {
            try
            {
                using (HotelDbEntities context = new HotelDbEntities())
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
    }
}
