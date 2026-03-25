using LorasApp.Data;
using LorasApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connstring = builder.Configuration.GetConnectionString("sqlconn");
builder.Services.AddDbContextPool<LoanDbContext>(options => options.UseSqlServer(connstring));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<IAdminService,AdminService>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<ILoanService,LoanService>();
builder.Services.AddSession();

var app = builder.Build();
app.UseSession();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}")
	.WithStaticAssets();


app.Run();
