using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Application.Interfaces;

namespace WebAPI1.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IContext _context;
        public UpdateCustomerCommandHandler(IContext context)
        {
            this._context = context;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entitiy = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId.Equals(request.CustomerId), cancellationToken);

            entitiy.Name = request.Name;
            entitiy.Address = request.Address;
            entitiy.Phone = request.Phone;
            entitiy.Sale = request.Sale;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
