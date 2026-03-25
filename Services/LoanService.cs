using LorasApp.Data;
using LorasApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LorasApp.Services
{
	public class LoanService : ILoanService
	{
		private readonly LoanDbContext _context;	
		public LoanService(LoanDbContext context)
		{
			_context = context;
		}

		public void AddLoanProduct(LoanProduct product)
		{
			_context.LoanProducts.Add(product);
			_context.SaveChanges();
		}

		public void DeleteLoanProduct(LoanProduct product)
		{
			_context.LoanProducts.Remove(product);
			_context.SaveChanges();
		}

		public List<LoanProduct> GetAllProducts()
		{
			return _context.LoanProducts.ToList();
		}

		public LoanProduct GetLoanProduct(int id)
		{
			return _context.LoanProducts.Find(id);
		}

		public void UpdateLoanProduct(LoanProduct dbproduct, LoanProduct model)
		{
			dbproduct.ProductName = model.ProductName;
			dbproduct.LoanType = model.LoanType;
			dbproduct.MinAmount = model.MinAmount;
			dbproduct.MaxAmount = model.MaxAmount;
			dbproduct.MinTenure = model.MinTenure;
			dbproduct.MaxTenure = model.MaxTenure;
			dbproduct.ProcessingFee = model.ProcessingFee;
			_context.SaveChanges();
		}
	}
}
