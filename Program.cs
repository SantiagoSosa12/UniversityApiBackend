// Usign para anadir dependencias
using Microsoft.EntityFrameworkCore;
using UniversityApiBackEnd.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using UniversityApiBackEnd.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Usign para anadir dependencias
builder.Services.AddDbContext<UniversityBDContext>(options =>
// Usign para anadir dependencias
options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityDBContext") ?? throw new InvalidOperationException("Connection string 'UniversityDBContext' not found.")));


// Conectar con la BD
const string CONNECTIONNAME = "UniversityBD";
var conectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// Anadir contexto a Builder
builder.Services.AddDbContext<UniversityBDContext>(options => options.UseSqlServer(conectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

//Se agrega Swager
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
