using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI1.Application.ComputerOrders.UpdateComputerOrder
{
    public class UpdateComputerOrderCommand : IRequest
    {
        public int ComputerOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int CustomerId { get; set; }
        public double Prepayment { get; set; }
        public string WorkMark { get; set; }
        public double AllCost { get; set; }
        public string GuaranteePeriod { get; set; }
        public int EmployeeId { get; set; }
    }
}
