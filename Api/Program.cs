using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services);

builder.Services.AddControllers();

builder.Services.AddDbContext<DBContext>(options =>
{
   // options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), 
    b => b.MigrationsAssembly("Api"));
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IProductService, ProductService>();
    services.AddTransient<IBuyService, BuyService>();
   // services.AddHttpClient<IUsersService, UsersService>();
}
