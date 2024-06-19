using ContactManager.Service.Configuration;
using ContactManager.Service.Context;
using ContactManager.Service.Extensions;
using ContactManager.Service.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOptions();
builder.Services.Configure<ContactManagerConfiguration>(builder.Configuration.GetSection("ContactManagerConfiguration"));
var options = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<ContactManagerConfiguration>>();

builder.Services.AddDbContext<IContactManagerContext, ContactManagerContext>(o =>
{
    o.UseSqlServer(options.Value.Database.ToConnectionString());
});

builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddControllers();
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

using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<ContactManagerContext>();
await dbContext.Database.MigrateAsync();


app.Run();
