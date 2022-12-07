using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Application.Interfaces;
using WebAPI1.Domain.Models;

namespace WebAPI1.Application.Queries.GetAll.ComuterOrders
{
    public class GetComputerOrdersQueryHandler : IRequestHandler<GetComputerOrdersQuery, IEnumerable<ComputerOrderVm>>
    {
        private readonly IContext _context;

        public GetComputerOrdersQueryHandler(IContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ComputerOrderVm>> Handle(GetComputerOrdersQuery request, CancellationToken cancellationToken)
        {
            var computerOrders = GetComputerOrderVm(await _context.ComputerOrders.ToListAsync());
            return computerOrders;
        }

        public IEnumerable<ComputerOrderVm> GetComputerOrderVm(IEnumerable<ComputerOrder> computerOrders)
        {
            IEnumerable<ComputerOrderVm> computerOrdersVm = from c in computerOrders
                                                            join cust in _context.Customers
                                                            on c.CustomerId equals cust.CustomerId
                                                            join emp in _context.Employees
                                                            on c.EmployeeId equals emp.EmployeeId
                                                            select new ComputerOrderVm
                                                            {
                                                                ComputerOrderId = c.ComputerOrderId,
                                                                OrderDate = c.OrderDate,
                                                                ExecutionDate = c.ExecutionDate,
                                                                CustomerName = cust.Name,
                                                                Prepayment = c.Prepayment,
                                                                Workmark = c.Workmark,
                                                                AllCost = c.AllCost,
                                                                GuaranteePeriod = c.GuaranteePeriod,
                                                                EmployeeName = emp.Name
                                                            };
            return computerOrdersVm;
        }
    }
}
