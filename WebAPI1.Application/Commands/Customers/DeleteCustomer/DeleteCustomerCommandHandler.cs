using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Application.Interfaces;

namespace WebAPI1.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IContext _context;
        public DeleteCustomerCommandHandler(IContext context)
        {
            _context = context; 
        }
        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entitiy = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId.Equals(request.CustomerId), cancellationToken);
            _context.Customers.Remove(entitiy);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
