using CustomerApi.Models;
using CustomerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            var customers = await _customerService.GetCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound("Customer Not Found For This Id");
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
        {
            var customers = await _customerService.AddCustomerAsync(customer);  
            return Ok(customers);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(int id, Customer request)
        {
            var customers = await _customerService.UpdateCustomerAsync(id, request);

            if (customers == null)
            {
                return NotFound("Customer Not Found For This Id");
            }

            return Ok(customers);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var customers = await _customerService.DeleteCustomerAsync(id);
            if (customers == null)
            {
                return NotFound("Customer Not Found For This Id");
            }
            return Ok(customers);
        }
    }
}//chnages
