using CRUD_API.Models.Entities;

namespace CRUD_API.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer? GetCustomerById(int id); 
        Customer AddCustomer(Customer customer); 
        Customer UpdateCustomer(Customer customer); 
        void DeleteCustomer(Customer customer); 
    }
}
