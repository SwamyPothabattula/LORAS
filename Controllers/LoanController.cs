using LorasApp.Models;
using LorasApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LorasApp.Controllers
{
	public class LoanController : Controller
	{
		private readonly ILoanService _loanService;
		public LoanController(ILoanService loanService){
			_loanService = loanService;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Products(){
			var products = _loanService.GetAllProducts();
			return View(products);
		}
		public IActionResult AddProduct(){
			return View();
		}
		[HttpPost]
		public IActionResult AddProduct(LoanProduct product)
		{
			if(ModelState.IsValid){
				_loanService.AddLoanProduct(product);
				return RedirectToAction("Products");
			}
			return View(product);
		}
		public IActionResult EditProduct(int id)
		{
			var product = _loanService.GetLoanProduct(id);
			return View(product);
		}
		[HttpPost]
		public IActionResult EditProduct(LoanProduct model)
		{
			var dbproduct=_loanService.GetLoanProduct(model.ProductId);
			if(dbproduct!=null){
				_loanService.UpdateLoanProduct(dbproduct, model);
				return RedirectToAction("Products");
			}
			return View(model);
		}
		[HttpPost]
		public IActionResult DeleteProduct(int id){
			var product= _loanService.GetLoanProduct(id);
			if(product==null){
				return NotFound();
			}
			
             _loanService.DeleteLoanProduct(product);
			
			return View("Products");
		}
	}
}
