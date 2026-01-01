using System.Threading.Tasks;
using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly DataContext _dataContext;
        public CustomerService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Customer>> AddCustomerAsync(Customer customer)
        {
            await _dataContext.Customers.AddAsync(customer);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Customers.ToListAsync();
        }

        public async Task<List<Customer>?> DeleteCustomerAsync(int id)
        {
            Customer? customer = await _dataContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return null;
            }

            _dataContext.Customers.Remove(customer);  
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {

            Customer? customer =await _dataContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return null;
            }
            return customer;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _dataContext.Customers.ToListAsync();
        }

        public async Task<List<Customer>?> UpdateCustomerAsync(int id, Customer request)
        {
            Customer? customer = await _dataContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return null;
            }

            customer.Name = request.Name;
            customer.Email = request.Email;
            customer.Address = request.Address;

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Customers.ToListAsync();
        }
    }
}
