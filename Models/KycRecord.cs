using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LorasApp.Models
{
	public enum VerificationStatus
	{
		PENDING,
		VERIFIED,
		REJECTED
	}
	public class KycRecord
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int KycId { get; set; }
		[ForeignKey("Customer")]
		public int CustomerId { get; set; }
		[Required, Column(TypeName = "VARCHAR(50)")]
		public string DocumentType { get; set; }
		[Required, Column(TypeName = "VARCHAR(100)")]
		public string DocumentNumber { get; set; }
		public VerificationStatus VerificationStatus { get; set; }
		public Customer Customer { get; set; } //Only record refer to one Customer
	}
}
