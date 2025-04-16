using Microsoft.AspNetCore.HttpLogging;
namespace ASPA001
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); //создаем webApplicationBulder (паттерн builder)

            builder.Services.AddHttpLogging(// вывод в журнал
                                                logging =>
                                                {
                                                    logging.LoggingFields = HttpLoggingFields.RequestMethod | //request метод
                                                 HttpLoggingFields.RequestPath | // request uri
                                                 HttpLoggingFields.ResponseStatusCode | // response status
                                                 HttpLoggingFields.ResponseBody; // response тело
                                                }
                                            );

            builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);  // фильтр сообщений

            var app = builder.Build(); // создаем экземпляр webApplication


            app.UseHttpLogging();  // middleware: вывод в журнал


            app.MapGet("/", () => "Мое первое ASPA"); // создаем конечную точку
            

            app.Run(); // запускаем web-приложение
        }
    }
}
