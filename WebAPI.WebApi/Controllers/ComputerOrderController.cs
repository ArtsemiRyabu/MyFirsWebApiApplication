using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using WebAPI1.Application.ComputerOrders.CreateComputerOrder;
using WebAPI1.Application.ComputerOrders.DeleteComputerOrder;
using WebAPI1.Application.ComputerOrders.UpdateComputerOrder;
using WebAPI1.Application.Interfaces;
using WebAPI1.Application.Queries.GetAll.ComuterOrders;
using WebAPI1.Domain.Models;

namespace WebAPI.WebApi.Controllers
{
    [Route("api/{controller}")]
    public class ComputerOrderController : BaseController
    {
        private IContext _context { get; set; }

        public ComputerOrderController(IContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Produces("application/json")]
        
        public async Task<ActionResult<ComputerOrderVm>> Index()
        {
            var query = new GetComputerOrdersQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateComputerOrderCommand vm)
        {
            await Mediator.Send(vm);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateComputerOrderCommand vm)
        {
            await Mediator.Send(vm);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteComputerOrderCommand
            {
                ComputerOrderId = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("customers")]
        [Produces("application/json")]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        // GET api/values
        [HttpGet("employees")]
        [Produces("application/json")]
        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ComputerOrder computerOrder = _context.ComputerOrders.FirstOrDefault(x => x.ComputerOrderId == id);
            return new ObjectResult(computerOrder);
        }

    }
}
