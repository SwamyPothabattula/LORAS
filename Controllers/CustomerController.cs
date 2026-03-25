using LorasApp.Models;
using LorasApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LorasApp.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ICustomerService _customeService;
		public CustomerController(ICustomerService customerService){
			_customeService = customerService;
		}
		public IActionResult Index()
		{
			var email = HttpContext.Session.GetString("UserEmail");
			var role = HttpContext.Session.GetString("UserRole");
			if(email == null && role!="CUSTOMER"){
				return RedirectToAction("Login","Login");
			}
			int? sessionUserId = HttpContext.Session.GetInt32("UserId");
			HttpContext.Session.SetInt32("CustomerId", _customeService.GetCustomerId(sessionUserId.Value).CustomerId);
			return View();
		}
		public IActionResult Register(){
			return View();
		}
		[HttpPost]
		public IActionResult Register(Customer customer){
			ModelState.Remove("LoanApplications");
			ModelState.Remove("KycRecord");
			ModelState.Remove("CreditScore");
			ModelState.Remove("UserId");
			int? sessionUserId = HttpContext.Session.GetInt32("UserId");
			customer.UserId = sessionUserId.Value;
			if (ModelState.IsValid){
				_customeService.AddCustomer(customer);
			}
			return View(customer);
		}
		public IActionResult Profile(){
			int? sessionUserId = HttpContext.Session.GetInt32("UserId");
			var customer = _customeService.GetCustomer(sessionUserId.Value);
           return View(customer);
		}

		[HttpGet]
		public IActionResult Update(int id, string field)
		{
			// Important: Get the customer to show their current data in the input box
			var customer = _customeService.GetCustomer(id);
			if (customer == null) return NotFound();

			ViewBag.FieldToEdit = field;
			return View(customer);
		}
		[HttpPost]
		public IActionResult Update(Customer model, string fieldName)
		{
			// 1. Get the actual customer from the database using the ID from the hidden input
			var dbCustomer = _customeService.GetCustomer(model.CustomerId);
			if (dbCustomer == null) return NotFound();
			// 2. The Model Binder has already put the input value into 'model.FirstName' or 'model.LastName'
			switch (fieldName)
			{
				case "FirstName":
					dbCustomer.FirstName = model.FirstName;
					break;
				case "LastName":
					dbCustomer.LastName = model.LastName;
					break;
				case "DateOfBirth":
					dbCustomer.DateOfBirth = model.DateOfBirth;
					break;
				case "AadharNumber":
					if (string.IsNullOrEmpty(model.AadharNumber) || !System.Text.RegularExpressions.Regex.IsMatch(model.AadharNumber, @"^\d{12}$"))
					{
						ModelState.AddModelError("AadharNumber", "Aadhar must be exactly 12 digits.");
						//model.FirstName = dbCustomer.FirstName;
						//model.LastName = dbCustomer.LastName;
						//model.Email = dbCustomer.Email;
						// CRITICAL: Re-set this so the View knows which row to show the input for
						ViewBag.FieldToEdit = fieldName;

						// Return the 'model' from the parameters, NOT the 'dbCustomer'
						return View(model);
					}
					dbCustomer.AadharNumber = model.AadharNumber;
					break;
				case "PanNumber":
					dbCustomer.PanNumber = model.PanNumber;
					break;
				case "PhoneNumber":
					dbCustomer.PhoneNumber=model.PhoneNumber;
					break;
				case "GenderType":
					dbCustomer.GenderType=model.GenderType;
					break;
				case "MaritalStatus":
					dbCustomer.MaritalStatus=model.MaritalStatus;
					break;
				case "EmployementType":
					dbCustomer.EmployementType=model.EmployementType;
					break;
				case "Address":
					dbCustomer.Address=model.Address;
					break;
				case "AnnualIncome":
					dbCustomer.AnnualIncome = model.AnnualIncome;
					break;
			}

				_customeService.Update(dbCustomer);
				return RedirectToAction("Profile");
		}
	}
}
