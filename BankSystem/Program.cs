using Bank.Application.Interfaces;
using Bank.Application.Mapping;
using Bank.Application.Services;
using Bank.Domain.Interface.IRepositories;
using Bank.Infrastructure.Data;
using Bank.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));


// Add services to the container.

builder.Services.AddControllers();
// Register application services and repositories
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// DbContext registration (uses in-memory for example; replace with real connection)
builder.Services.AddDbContext<BankDbContext>(opt => opt.UseInMemoryDatabase("BankDb"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Global exception handler - maps service exceptions to proper HTTP responses and logs errors
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var feature = context.Features.Get<IExceptionHandlerFeature>();
        var ex = feature?.Error;

        // Resolve services from request to log and check environment
        var logger = context.RequestServices.GetService<ILogger<Program>>();
        var env = context.RequestServices.GetService<Microsoft.AspNetCore.Hosting.IWebHostEnvironment>();

        // Log the exception (if logger available)
        if (ex != null)
        {
            if (logger != null)
                logger.LogError(ex, "Unhandled exception while processing request");
        }

        context.Response.ContentType = "application/json";

        if (ex is ArgumentException)
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        else if (ex is InvalidOperationException)
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        else
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        // Build a detailed response in Development, minimal in Production
        var response = new Dictionary<string, object?>
        {
            ["error"] = ex?.Message ?? "An unexpected error occurred.",
            ["type"] = ex?.GetType().Name
        };

        if (env?.IsDevelopment() == true && ex != null)
        {
            response["detail"] = ex.StackTrace;
        }

        await context.Response.WriteAsJsonAsync(response);
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
