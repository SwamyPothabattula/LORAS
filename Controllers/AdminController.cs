using LorasApp.Models;
using LorasApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LorasApp.Controllers
{
	public class AdminController : Controller
	{
		private readonly IAdminService _adminService;
		public AdminController(IAdminService adminService){
			_adminService = adminService;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult AddLoanOfficer(){
            return View();
		}
		[HttpPost]
		public IActionResult AddLoanOfficer(string email,string password){

			User user = new User()
			{
				Email = email,
				Password = password,
				Role = Role.LOAN_OFFICER
			};
			_adminService.Add(user);
			return RedirectToAction("LoanOfficers");
		}
		public IActionResult AddCreditAnalyst()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddCreditAnalyst(string email, string password)
		{

			User user = new User()
			{
				Email = email,
				Password = password,
				Role = Role.CREDIT_ANALYST
			};
			_adminService.Add(user);
			return View("CreditAnalysts");
		}
		public IActionResult AddUnderWritter()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddUnderWritter(string email, string password)
		{

			User user = new User()
			{
				Email = email,
				Password = password,
				Role = Role.UNDERWRITTER
			};
			_adminService.Add(user);
			return View("Underwriters");
		}

		public IActionResult Users(){
			var users=_adminService.GetUsers(Role.CUSTOMER);
			return View(users);
		}
		public IActionResult LoanOfficers(){
			var users = _adminService.GetUsers(Role.LOAN_OFFICER);
			return View(users);
		}
		public IActionResult CreditAnalysts(){
			var users = _adminService.GetUsers(Role.CREDIT_ANALYST);
			return View(users);
		}
		public IActionResult Underwriters(){
			var users = _adminService.GetUsers(Role.UNDERWRITTER);
			return View(users);
		}
	}
}
