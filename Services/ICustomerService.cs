using LorasApp.Models;

namespace LorasApp.Services
{
	public interface ICustomerService
	{
		void AddCustomer(Customer customer);
		Customer GetCustomer(int customerId);
		Customer GetCustomerId(int userId);
		void Update(Customer customer);
	}
}
