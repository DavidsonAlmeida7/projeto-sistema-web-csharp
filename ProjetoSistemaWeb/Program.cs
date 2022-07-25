using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using ProjetoSistemaWeb.Data;
using ProjetoSistemaWeb.Services;
using System.Globalization;

namespace ProjetoSistemaWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ProjetoSistemaWebContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("ProjetoSistemaWebContext"), new MySqlServerVersion(new Version()), builder => builder.MigrationsAssembly("ProjetoSistemaWeb")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
    
            //Registra o servico de Seeding no sistema de injeção de dependência da aplicação
            //builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();
            builder.Services.AddScoped<SalesRecordService>();

            var app = builder.Build();

            //Adicionando locale padrão
            var enUS = new CultureInfo("en-US", false);
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUS),
                SupportedCultures = new List<CultureInfo> { enUS },
                SupportedUICultures = new List<CultureInfo> { enUS }
            };

            app.UseRequestLocalization(localizationOptions);

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}