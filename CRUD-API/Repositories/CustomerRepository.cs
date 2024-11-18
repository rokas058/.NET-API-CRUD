using CRUD_API.Data;
using CRUD_API.Models.Entities;

namespace CRUD_API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AplicationDBContext _dBContext;

        public CustomerRepository(AplicationDBContext dbContext)
        {
            _dBContext = dbContext;
        }

        public Customer AddCustomer(Customer customer)
        {
            _dBContext.Customers.Add(customer);
            _dBContext.SaveChanges();
            return customer;
        }

        public void DeleteCustomer(Customer customer)
        {
            _dBContext.Customers.Remove(customer);
            _dBContext.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            return _dBContext.Customers.ToList();
        }

        public Customer? GetCustomerById(int id)
        {
            return _dBContext.Customers.Find(id);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _dBContext.Update(customer);
            _dBContext.SaveChanges();
            return customer;
        }
    }
}
