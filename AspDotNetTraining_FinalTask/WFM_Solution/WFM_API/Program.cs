using Microsoft.EntityFrameworkCore;
using WFM_API.Wfm_Core;
using WFM_API.Wfm_Core.Abstraction;
using WFM_API.Wfm_Data;
using WFM_API.Wfm_Service;
using WFM_API.Wfm_Service.Helpers;

var builder = WebApplication.CreateBuilder(args);
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EmployeeDataContext>(options =>
           options.UseSqlServer("data source=ISTLP100\\KRISHNATRIPATHI;Integrated security=true;Database=WFM_Database;Trusted_Connection=True"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeService, EmployeeServices>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISoftLockService, SoftLockService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

app.Run();
