
using AutoMapper;
using CRUD_API.Models.Dto;
using CRUD_API.Models.Entities;
using CRUD_API.Repositories;

namespace CRUD_API.Services
{
    public class CustomerService(IMapper mapper, CustomerRepository customerRepository)
    {
        private readonly IMapper _mapper = mapper;
        private readonly CustomerRepository _customerRepository = customerRepository;

        public async Task<List<CustomerReturnDto>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomers();
            return _mapper.Map<List<CustomerReturnDto>>(customers);
        }

        public async Task<CustomerReturnDto?> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            return _mapper.Map<CustomerReturnDto>(customer);
        }

        public async Task<CustomerReturnDto> AddCustomer(CustomerFormDto customerDto)
        { 
            var customers = _mapper.Map<Customer>(customerDto);

            var addedCustomer = await _customerRepository.AddCustomer(customers);

            return _mapper.Map<CustomerReturnDto>(addedCustomer);
        }

        public async Task<CustomerReturnDto?> UpdateCustomer(CustomerFormDto customerDto, int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);

            if (customer == null)
            {
                return null;
            }

            _mapper.Map(customerDto, customer);

            var updatedCustomer = await _customerRepository.UpdateCustomer(customer);

            return _mapper.Map<CustomerReturnDto>(updatedCustomer);
        }

        public async Task<CustomerReturnDto?> DeleteCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);

            if (customer is null)
            {
                return null;
            }

            await _customerRepository.DeleteCustomer(customer);

            return _mapper.Map<CustomerReturnDto>(customer);
        }
    }
}
