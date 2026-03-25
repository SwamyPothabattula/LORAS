using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorasApp.Models
{
	public enum ValidationStatus
	{
		PENDING,
		VALIDATED,
		REJECTED
	}
	public class Document
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DocumentId {  get; set; }
		[ForeignKey("LoanApplication")]
		public int ApplicationId { get; set; }
		[Column(TypeName = "VARCHAR(100)")]
		public string DocumentName {  get; set; }
		[Column(TypeName = "VARCHAR(255)")]
		public string FilePath {  get; set; }
		public ValidationStatus ValidationStatus {  get; set; }
		public LoanApplication LoanApplication { get; set; }
	}
}
