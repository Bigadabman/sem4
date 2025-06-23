using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace LibraryApp
{
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();

            services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(config.GetConnectionString("LibraryDb")));

            
            ServiceProvider = services.BuildServiceProvider();
            base.OnStartup(e);
        }
    }
}