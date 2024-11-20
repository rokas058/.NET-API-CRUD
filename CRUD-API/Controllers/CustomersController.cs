using AutoMapper;
using CRUD_API.Data;
using CRUD_API.Models.Dto;
using CRUD_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(CustomerService customerService) : ControllerBase
    {
        
        private readonly CustomerService _customerService = customerService;

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id) 
        { 
            var customer = await _customerService.GetCustomerById(id);

            if (customer is null)
            {
                return NotFound(new { Message = $"Customer with ID {id} not found." });
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerFormDto customerDto)
        {
            var customer = await _customerService.AddCustomer(customerDto);
            return Ok(customer);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCustomer(CustomerFormDto customerDto, int id)
        {
            var customer = await _customerService.UpdateCustomer(customerDto, id);

            if (customer is null)
            {
                return NotFound(new { Message = $"Customer with ID {id} not found." });
            }

            return Ok(customer);

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.DeleteCustomer(id);

            if (customer is null)
            {
                return NotFound(new { Message = $"Customer with ID {id} not found." });
            }

            return NoContent();
        }

    }
}
