using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return Ok(await _context.Customers.ToListAsync()); //returning status code 200 - good request
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if(customer == null)
            {
                return BadRequest("Customer with Id = " + id + " not found.");
            }
            return Ok(customer); //returning status code 200 - good request
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer) //dont need to use [FromBody] before Customer, because im using complex parameter (Customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();  //wait for the db change save
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer request)
        {
            var customer = await _context.Customers.FindAsync(request.Id);
            if (customer == null)
            {
                return BadRequest("Customer with Id = " + request.Id + " not found.");
            }
            //other options to overwrite: AutoMapper, here manual overwrtie
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.vat_Id = request.vat_Id;
            customer.CreationDate = request.CreationDate;
            customer.AddressCity = request.AddressCity;
            customer.AddressStreet = request.AddressStreet;
            customer.AddressPostalCode = request.AddressPostalCode;

            await _context.SaveChangesAsync();

            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return BadRequest("Customer with Id = " + id + " not found.");
            }
            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();
            return Ok(await _context.Customers.ToListAsync());
        }
    }
}
