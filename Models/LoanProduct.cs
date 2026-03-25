using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LorasApp.Models
{
	public enum LoanType { 
		HOME_LOAN,
		CAR_LOAN,
		PERSONAL_LOAN,
		GOLD_LOAN
	}

	public class LoanProduct
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductId { get; set; }
		[Required, MaxLength(100)]
		public string ProductName { get; set; }
		[Required]
		public LoanType LoanType { get; set; }
		[Required]
		public decimal InterestRate { get; set; }
		[Required]
		public decimal MinAmount { get; set; }
		[Required]
		public decimal MaxAmount { get; set; }
		[Required]
		public int MinTenure { get; set; }
		[Required]
		public int MaxTenure { get; set; }
		public decimal ProcessingFee { get; set; }
		[ValidateNever]
		public ICollection<LoanApplication> LoanApplications { get; set; } 

	}
}
