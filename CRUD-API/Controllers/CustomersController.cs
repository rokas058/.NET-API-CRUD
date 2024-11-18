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
    public class CustomersController : ControllerBase
    {
        
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(_customerService.GetAllCustomers());
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCustomerById(int id) 
        { 
            var customer = _customerService.GetCustomerById(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerFormDto customerDto)
        {
            var customer = _customerService.AddCustomer(customerDto);
            return Ok(customer);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCustomer(CustomerFormDto customerDto, int id)
        {
            var customer = _customerService.UpdateCustomer(customerDto, id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.DeleteCustomer(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
