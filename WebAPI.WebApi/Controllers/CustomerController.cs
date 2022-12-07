using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.WebApi.Controllers;
using WebAPI1.Application.Customers.Commands.DeleteCustomer;
using WebAPI1.Application.Customers.Commands.UpdateCustomer;
using WebAPI1.Application.Customers.CreateCustomer;
using WebAPI1.Persistence.Data;

namespace WebAPI1.WebApi.Controllers
{
    [Route("api/{controller}")]
    public class CustomerController : BaseController
    {

        private readonly Context _context;
        public CustomerController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var customers = _context.Customers;
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCustomerCommand vm)
        {
            var id = await Mediator.Send(vm);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand vm)
        {
            await Mediator.Send(vm);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand
            {
                CustomerId = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
