using CustomerApi.Models;

namespace CustomerApi.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomersAsync();

        Task<Customer?> GetCustomerByIdAsync(int id);

        Task<List<Customer>> AddCustomerAsync(Customer customer);

        Task<List<Customer>?> UpdateCustomerAsync(int id, Customer request);

        Task<List<Customer>?> DeleteCustomerAsync(int id);

    }
}