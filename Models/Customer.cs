
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;



namespace LorasApp.Models
{
	public enum EmployementType
	{
		SALARIED,
		SELF_EMPLOYED,
		BUSINESS,
		STUDENT,
		UNEMPLOYED
	}
	public enum GenderType
	{
		MALE,
		FEMALE,
		OTHERS
	}
	public enum MaritalStatus {
		MARRIED,
		UNMARRIED
	}

	public class Customer
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CustomerId { get; set; }
		//[Required, MaxLength(50)]
		public string FirstName { get; set; }
		//[MaxLength(50)]
		public string LastName { get; set; }
		//[Required]
		public DateTime DateOfBirth { get; set; }
		//[RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$")]
		public string Email { get; set; }
		//[Required]
		public GenderType GenderType { get; set; }
		public MaritalStatus MaritalStatus { get; set; }
		//[Required, RegularExpression(@"^[6-9]{1}[0-9]{9}$")]
		public string PhoneNumber { get; set; }
		//[Required, RegularExpression(@"[A-Z]{5}[0-9]{4}[A-Z]{1}")]

		public string PanNumber { get; set; }
		//[Required]
		[RegularExpression(@"[0-9]{12}")]
		public string AadharNumber { get; set; }
		//[Required]
		public string Address { get; set; }
		//[Required]
		public decimal AnnualIncome { get; set; }
		//[Required]
		public EmployementType EmployementType { get; set; }
		[ForeignKey("User")]
		public int UserId{  get; set; }
		[ValidateNever]
		public ICollection<LoanApplication> LoanApplications { get; set; } //Can have multiple loan applications
		[ValidateNever]
		public KycRecord KycRecord { get; set; } //can have one Kyc Record
		[ValidateNever]
		public CreditScore CreditScore{  get; set; }
	}
}
