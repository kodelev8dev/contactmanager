using ContactManager.Service.Configuration;

namespace ContactManager.Service.Extensions;

//this extension allows the database connections string to make dynamic also in database migrations
public static class DatabaseExtentions
{
    public static string ToConnectionString(this Database database) =>
         $"Server={database.Server},{database.Port};Database={database.Name};User Id={database.User};Password={database.Password};Trusted_connection=true;TrustServerCertificate=true";
}
