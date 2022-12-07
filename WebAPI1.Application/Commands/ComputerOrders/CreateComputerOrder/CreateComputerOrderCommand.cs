using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebAPI1.Domain.Models;

namespace WebAPI1.Application.ComputerOrders.CreateComputerOrder
{
    public class CreateComputerOrderCommand : IRequest
    {
        public int ComputerOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int CustomerId { get; set; }
        public double Prepayment { get; set; }
        public string Workmark { get; set; }
        public double AllCost { get; set; }
        public string GuaranteePeriod { get; set; }
        public int EmployeeId { get; set; }
    }
}
