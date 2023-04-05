using HomeWork.Models;
using HomeWork.Service;
using HomeWork.Service.Abstract;
using HomeWork.Validation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PhoneContext>(options => options.UseSqlite(connection));
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<CreatePhoneValidator>();
builder.Services.AddScoped<CreatePhone>();
builder.Services.AddScoped<IDownloadFileService, DownloadFileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Phone}/{action=Index}/{id?}");

app.Run();