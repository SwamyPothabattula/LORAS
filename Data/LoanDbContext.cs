using LorasApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LorasApp.Data
{
	public class LoanDbContext:DbContext
	{
		public LoanDbContext(DbContextOptions<LoanDbContext> options):base(options)	 { }

		public DbSet<User> Users{  get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<LoanProduct> LoanProducts { get; set; }
		public DbSet<LoanApplication> LoanApplications { get; set; }
		public DbSet<KycRecord> KycRecords { get; set; }
		public DbSet<CreditScore> CreditScores { get; set; }
		public DbSet<Document> Documents { get; set; }
		public DbSet<ApprovalLog> ApprovalLogs { get; set; }

	}
}
