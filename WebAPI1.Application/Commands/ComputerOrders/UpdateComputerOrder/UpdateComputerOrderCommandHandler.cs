using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Application.Interfaces;

namespace WebAPI1.Application.ComputerOrders.UpdateComputerOrder
{
    public class UpdateComputerOrderCommandHandler : IRequestHandler<UpdateComputerOrderCommand>
    {
        private readonly IContext _context;

        public UpdateComputerOrderCommandHandler(IContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateComputerOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ComputerOrders.FirstOrDefaultAsync(c => c.ComputerOrderId == request.ComputerOrderId, cancellationToken);

            entity.OrderDate = request.OrderDate;
            entity.Prepayment = request.Prepayment;
            entity.Workmark = request.WorkMark;
            entity.AllCost = request.AllCost;
            entity.CustomerId = request.CustomerId;
            entity.EmployeeId = request.EmployeeId;
            entity.ExecutionDate = request.ExecutionDate;
            entity.GuaranteePeriod = request.GuaranteePeriod;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
