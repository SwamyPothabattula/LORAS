using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorasApp.Models
{
	public class ApprovalLog
	{
		[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ApprovalId {  get; set; }
		[ForeignKey("LoanApplication")]
		public int ApplicationId { get; set; }
		[Column(TypeName = "VARCHAR(50)")]
		public string ApprovalStatus {  get; set; }
		[Column(TypeName = "VARCHAR(255)")]
		public string Remarks {  get; set; }
		public LoanApplication LoanApplication { get; set; }
	}
}
