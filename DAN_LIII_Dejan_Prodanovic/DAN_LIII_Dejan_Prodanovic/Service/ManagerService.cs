using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAN_LIII_Dejan_Prodanovic.Model;

namespace DAN_LIII_Dejan_Prodanovic.Service
{
    class ManagerService : IManagerService
    {
        public List<tblVacationRequest> GetAllRequests()
        {
            try
            {
                using (MyHotelDbEntities context = new MyHotelDbEntities())
                {
                    List<tblVacationRequest> list = new List<tblVacationRequest>();
                    list = (from x in context.tblVacationRequests select x).ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwEmployee> GetEmployeesOfManager(string managerFloor)
        {
            try
            {
                using (MyHotelDbEntities context = new MyHotelDbEntities())
                {
                    List<vwEmployee> list = new List<vwEmployee>();
                    list = (from x in context.vwEmployees
                            where x.HotelFloor.Equals(managerFloor)
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

        public tblManager GetManagerByFloor(string floor)
        {
            try
            {
                using (MyHotelDbEntities context = new MyHotelDbEntities())
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

        public tblManager GetManagerByUserId(int managerId)
        {
            try
            {
                using (MyHotelDbEntities context = new MyHotelDbEntities())
                {


                    tblManager user = (from x in context.tblManagers
                                        where x.UserId == managerId
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

        public List<vwManager> GetManagers()
        {
            try
            {
                using (MyHotelDbEntities context = new MyHotelDbEntities())
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
