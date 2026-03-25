using LorasApp.Models;

namespace LorasApp.Services
{
	public interface IAdminService
	{
		List<User> GetUsers(Role role);
		void Add(User user);
	}
}
