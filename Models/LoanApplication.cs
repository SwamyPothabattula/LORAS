using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorasApp.Models
{
	public enum ApplicationStatus
	{ 
		NEW,
		UNDER_REVIEW,
		APPROVED,
		REJECTED
	}

	public class LoanApplication
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ApplicationId { get; set; }
		[ForeignKey("Customer")]
		public int CustomerId { get; set; }
		[ForeignKey("LoanProduct")]
		public int ProductId { get; set; }
		[Column(TypeName = "DECIMAL(15, 2)")]
		public decimal RequestedAmount { get; set; }
		public int Tenure { get; set; }

		public ApplicationStatus ApplicationStatus { get; set; }
		public Customer Customer { get; set; }
		public LoanProduct Product { get; set; }
		public ICollection<Document> Documents { get; set; } //One application can have multiple documents
	}
}
