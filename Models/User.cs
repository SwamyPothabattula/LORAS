using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorasApp.Models
{
	public enum Role{
		CUSTOMER,
		LOAN_OFFICER,
		CREDIT_ANALYST,
		UNDERWRITTER,
		ADMIN
	}
	public class User
	{
		[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$")]
		public string Email{ get; set; }
		public string Password { get; set; }
		[Required]
		public Role Role{  get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;

	}
}
