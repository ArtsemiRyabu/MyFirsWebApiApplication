using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Application.Interfaces;

namespace WebAPI1.Application.ComputerOrders.DeleteComputerOrder
{
    public class DeleteComputerOrderCommandHandler : IRequestHandler<DeleteComputerOrderCommand>
    {
        private readonly IContext _context;
        public DeleteComputerOrderCommandHandler(IContext _context)
        {
            this._context = _context;
        }
        public async Task<Unit> Handle(DeleteComputerOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ComputerOrders.FirstOrDefaultAsync(c => c.ComputerOrderId == request.ComputerOrderId);
            _context.ComputerOrders.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
