
using AutoMapper;
using CRUD_API.Data;
using CRUD_API.Models.Dto;
using CRUD_API.Models.Entities;
using CRUD_API.Repositories;

namespace CRUD_API.Services
{
    public class CustomerService
    {
        private readonly IMapper _mapper;
        private readonly CustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, CustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public List<CustomerReturnDto> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            return _mapper.Map<List<CustomerReturnDto>>(customers);
        }

        public CustomerReturnDto? GetCustomerById(int id)
        {
            var customer =  _customerRepository.GetCustomerById(id);
            return _mapper.Map<CustomerReturnDto>(customer);
        }

        public CustomerReturnDto AddCustomer(CustomerFormDto customerDto)
        { 
            var customers = _mapper.Map<Customer>(customerDto);

            var addedCustomer = _customerRepository.AddCustomer(customers);

            return _mapper.Map<CustomerReturnDto>(addedCustomer);
        }

        public CustomerReturnDto? UpdateCustomer(CustomerFormDto customerDto, int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
            {
                return null;
            }

            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.Email = customerDto.Email;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.DateOfBirth = customerDto.DateOfBirth;
            customer.Address = customerDto.Address;

            //var changedCustomer = _mapper.Map<Customer>(customerDto);

            var updatedCustomer = _customerRepository.UpdateCustomer(customer);

            return _mapper.Map<CustomerReturnDto>(updatedCustomer);
        }

        public CustomerReturnDto? DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer is null)
            {
                return null;
            }

            _customerRepository.DeleteCustomer(customer);

            return _mapper.Map<CustomerReturnDto>(customer);
        }
    }
}
