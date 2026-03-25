using LorasApp.Data;
using LorasApp.Models;

namespace LorasApp.Services
{
	public class CustomerService:ICustomerService
	{
		private readonly LoanDbContext _context;
		public CustomerService(LoanDbContext context){
			_context = context;
		}
		public void AddCustomer(Customer customer){
			_context.Customers.Add(customer);	
			_context.SaveChanges();
		}

		public Customer GetCustomer(int customerId)
		{
			return _context.Customers.FirstOrDefault(x => x.CustomerId == customerId);
		}

		public Customer GetCustomerId(int userId)
		{
			return _context.Customers.FirstOrDefault(x => x.UserId == userId);
		}

		public void Update(Customer customer){
			_context.SaveChanges();
		}
	}
}
