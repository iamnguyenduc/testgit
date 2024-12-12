using Microsoft.EntityFrameworkCore;
using MyRazorProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Thêm DbContext vào DI container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình các dịch vụ khác
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
