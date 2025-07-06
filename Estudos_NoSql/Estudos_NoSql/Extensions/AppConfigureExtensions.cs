using Estudos_NoSql.Infrastructure;

namespace Estudos_NoSql.Extensions
{
    public static class AppConfigureExtensions
    {
        public static void Configure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                //if(db.Database.IsRelational())
                // db.Database.Migrate();
            }
        }
    }
}
