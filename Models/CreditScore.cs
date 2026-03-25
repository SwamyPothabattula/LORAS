using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LorasApp.Models
{

	public enum RiskLevel
	{
		LOW,
		MEDIUM, 
		HIGH
	}
	public class CreditScore
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ScoreId { get; set; }
		[ForeignKey("Customer")]
		public int CustomerId { get; set; }
		public int ScoreValue { get; set; }
		public RiskLevel RiskLevel { get; set; }
		public Customer Customer { get; set; } //one score refers to one customer

	}
}
