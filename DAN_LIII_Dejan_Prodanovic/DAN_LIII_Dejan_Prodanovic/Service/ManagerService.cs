using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAN_LIII_Dejan_Prodanovic.Model;

namespace DAN_LIII_Dejan_Prodanovic.Service
{
    class ManagerService : IManagerService
    {
        public tblManager GetManagerByFloor(string floor)
        {
            try
            {
                using (HotelDbEntities context = new HotelDbEntities())
                {


                    tblManager manager = (from x in context.tblManagers
                                    where x.HotelFloor.Equals(floor)
                                    select x).First();

                    return manager;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwManager> GetManagers()
        {
            try
            {
                using (HotelDbEntities context = new HotelDbEntities())
                {
                    List<vwManager> list = new List<vwManager>();
                    list = (from x in context.vwManagers select x).ToList();

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
