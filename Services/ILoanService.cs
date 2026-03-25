using LorasApp.Models;

namespace LorasApp.Services
{
	public interface ILoanService
	{
		List<LoanProduct> GetAllProducts();
		void  AddLoanProduct(LoanProduct product);
		LoanProduct GetLoanProduct(int id);
		void UpdateLoanProduct(LoanProduct dbproduct,LoanProduct model);
		void DeleteLoanProduct(LoanProduct product);
	}
}
