using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI1.Application.Queries.GetAll.ComuterOrders
{
    public class ComputerOrderVm
    {
        public int ComputerOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string CustomerName { get; set; }
        public double Prepayment { get; set; }
        public string Workmark { get; set; }
        public double AllCost { get; set; }
        public string GuaranteePeriod { get; set; }
        public string EmployeeName { get; set; }
    }
}
