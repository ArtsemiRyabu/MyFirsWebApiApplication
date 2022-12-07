using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Application.Interfaces;
using WebAPI1.Domain.Models;

namespace WebAPI1.Application.ComputerOrders.CreateComputerOrder
{
    public class CreateComputerOrderCommandHandler : IRequestHandler<CreateComputerOrderCommand>
    {
        private readonly IContext _context;
        public CreateComputerOrderCommandHandler(IContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateComputerOrderCommand request, CancellationToken cancellationToken)
        {
            var computerOrder = new ComputerOrder
            {
                CustomerId = request.CustomerId,
                EmployeeId = request.EmployeeId,
                OrderDate = request.OrderDate,
                ExecutionDate = request.ExecutionDate,
                AllCost = request.AllCost,
                GuaranteePeriod = request.GuaranteePeriod,
                Prepayment = request.Prepayment,
                Workmark = request.Workmark,
            };
            await _context.ComputerOrders.AddAsync(computerOrder);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
