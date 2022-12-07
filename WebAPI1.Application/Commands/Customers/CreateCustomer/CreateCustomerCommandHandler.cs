using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebAPI1.Application.Customers.CreateCustomer;
using WebAPI1.Application.Interfaces;
using WebAPI1.Domain.Models;

namespace WebAPI1.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler
        :IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IContext _context;
        public CreateCustomerCommandHandler(IContext context)
        {
            this._context = context;
        }

        public async Task<int> Handle(CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                CustomerId = request.CustomerId,
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone,
                Sale = request.Sale,
            };

            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return customer.CustomerId;
        }
    }
}
