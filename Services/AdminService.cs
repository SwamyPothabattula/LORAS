using LorasApp.Data;
using LorasApp.Models;

namespace LorasApp.Services
{
	public class AdminService : IAdminService
	{
		private readonly LoanDbContext _context;
		public AdminService(LoanDbContext context)
		{
			_context = context;
		}

		public void Add(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();	
		}

		public List<User> GetUsers(Role role)
		{
			return _context.Users.Where(x=>x.Role==role).ToList();
		}
	}
}
