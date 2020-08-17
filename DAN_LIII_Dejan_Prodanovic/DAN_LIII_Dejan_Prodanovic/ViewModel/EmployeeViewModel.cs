using DAN_LIII_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LIII_Dejan_Prodanovic.ViewModel
{
    class EmployeeViewModel:ViewModelBase
    {
        EmployeeView view;




        public EmployeeViewModel(EmployeeView employeeViewOpen)
        {
            view = employeeViewOpen;

        }
    }
}
