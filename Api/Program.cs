using System.Reflection;
using DAL;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.EmployeeService;
using Services.OfficeService;
using Services.ResponseService;

TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
														options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeBll, EmployeeBll>();
builder.Services.AddScoped<IResponseService, ResponseService>();
builder.Services.AddScoped<IOfficeBll, OfficeBll>();
builder.Services.AddScoped<IOfficeService, OfficeService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	// Retrieve project name dynamically look in properties of project and the xml documentation path
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xPath   = Path.Combine(AppContext.BaseDirectory, xmlFile);
	c.IncludeXmlComments(xPath, true);
	
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();

	// Enable Swagger in development mode
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Norlys test project");
		c.RoutePrefix = string.Empty;
	});
}
else
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
					   name : "default",
					   pattern : "{controller=Home}/{action=Index}/{id?}");

app.Run();