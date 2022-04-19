using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Krzysztof", LastName = "Buczek", VAT_Id = "43242342", CreationDate = "19.04.2022", Address = "Kraków, ul. Aaabbbb 1"}
            };

            return Ok(customers); //returning status code 200 - good request
        }
    }
}
