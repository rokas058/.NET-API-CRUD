using CRUD_API.Data;
using CRUD_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Repositories
{
    public class CustomerRepository(AplicationDBContext dbContext) : ICustomerRepository
    {
        private readonly AplicationDBContext _dBContext = dbContext;

        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _dBContext.Customers.AddAsync(customer);
            await _dBContext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _dBContext.Customers.Remove(customer);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _dBContext.Customers.ToListAsync(); 
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _dBContext.Customers.FindAsync(id);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            //_dBContext.Customers.Update(customer);
            _dBContext.Customers.Attach(customer);
            _dBContext.Entry(customer).State = EntityState.Modified;
            await _dBContext.SaveChangesAsync();
            return customer;
        }
    }
}
