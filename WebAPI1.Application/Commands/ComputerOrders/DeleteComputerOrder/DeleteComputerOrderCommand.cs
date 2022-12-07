using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI1.Application.ComputerOrders.DeleteComputerOrder
{
    public class DeleteComputerOrderCommand : IRequest
    {
        public int ComputerOrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
    }
}
