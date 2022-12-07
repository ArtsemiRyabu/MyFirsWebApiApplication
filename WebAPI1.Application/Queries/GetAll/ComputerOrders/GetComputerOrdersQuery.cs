using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI1.Application.Queries.GetAll.ComuterOrders
{
    public record GetComputerOrdersQuery : IRequest<IEnumerable<ComputerOrderVm>>;
}
