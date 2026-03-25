using LorasApp.Models;
using LorasApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace LorasApp.Controllers
{
	public class LoginController : Controller
	{
		private readonly ILoginService _loginService;
		public LoginController(ILoginService loginService)
		{
			_loginService = loginService;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Login(string email, string password, Role role)
		{
			var user = _loginService.Login(email, password, role);
			
			if (user != null)
			{
				HttpContext.Session.SetInt32("UserId", user.Id);
				HttpContext.Session.SetString("UserEmail",user.Email);
				HttpContext.Session.SetString("UserRole", role.ToString());
				switch (user.Role)
				{
					case Role.CUSTOMER:
						return RedirectToAction("Index", "Customer");
					case Role.ADMIN:
						return RedirectToAction("Index", "Admin");
					case Role.LOAN_OFFICER:
						return RedirectToAction("Index", "Loan");
					}
			}

			ViewBag.Error = "Invalid login credentials";
			return View();
		}
		[HttpGet]
		public IActionResult Register() {
			return View();
		}
		[HttpPost]
		public IActionResult Register(Register model){
			if(ModelState.IsValid){
				User user = new User()
				{
					Email = model.Email,
					Password = model.Password,
					Role = Role.CUSTOMER
				};
				_loginService.RegisterCustomer(user);
				return RedirectToAction("Login");
			}
			return View(model);
		}
		[HttpGet]
		public IActionResult Logout(){
			HttpContext.Session.Clear();
			return RedirectToAction("Login", "Login");
		}
	}
}
