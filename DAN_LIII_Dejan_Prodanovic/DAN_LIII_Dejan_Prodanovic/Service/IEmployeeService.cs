using DAN_LIII_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LIII_Dejan_Prodanovic.Service
{
    interface IEmployeeService
    {
        List<vwEmployee> GetEmployees();
        void SetSalary(vwEmployee employee, decimal salary);
        void CreateRequest(tblVacationRequest request);
        List<tblVacationRequest> GetVacationsByEmployeeId(int employeeId);
        tblEmployee GetEmloyeByEmployeeId(int employeeId);
        void RefuseRequest(tblVacationRequest request);
        void ApproveRequest(tblVacationRequest request);
    }
}
