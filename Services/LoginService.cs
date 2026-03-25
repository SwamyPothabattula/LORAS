using System.Reflection.Metadata.Ecma335;
using LorasApp.Data;
using LorasApp.Models;

namespace LorasApp.Services
{
	public class LoginService : ILoginService
	{
		private readonly LoanDbContext _context;
		public LoginService(LoanDbContext context){
			_context = context;	
		}

		public User Login(string email, string password,Role role)
		{
			var user = _context.Users.FirstOrDefault(u=>u.Email==email && u.Password==password && u.Role==role);
			return user;
		}

		public void RegisterCustomer(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
		}
	}
}
