using LorasApp.Models;

namespace LorasApp.Services
{
	public interface ILoginService
	{
		void RegisterCustomer(User user);
		User Login(string email, string password,Role role);

	}
}
