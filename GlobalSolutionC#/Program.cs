using GlobalSolutionCS.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<SmartBinContext>(options =>
	options.UseOracle(builder.Configuration.GetConnectionString("OracleDbConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(
		builder =>
		{
			builder.AllowAnyOrigin()
				   .AllowAnyMethod()
				   .AllowAnyHeader();
		});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanWave API V1");
		c.RoutePrefix = string.Empty;
	});
}

app.UseHttpsRedirection();

// Use CORS middleware
app.UseCors();

app.UseAuthorization();

app.MapControllers();

// Ensure the database is created and apply any pending migrations
using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<SmartBinContext>();
	try
	{
		dbContext.Database.Migrate();
	}
	catch (OracleException ex)
	{
		if (ex.Number == 955) // ORA-00955: nome já está sendo usado por um objeto existente
		{
			Console.WriteLine("Table already exists, skipping migration.");
		}
		else
		{
			throw;
		}
	}
}

app.Run();
