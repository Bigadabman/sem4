using Microsoft.Extensions.FileProviders;

namespace ASPA002_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            
           
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear(); // удаляем имена файлов по умолчанию
            options.DefaultFileNames.Add("Neumann.html"); // добавляем новое имя файла
            app.UseDefaultFiles(options); // установка параметров;
            app.UseStaticFiles();
            app.UseStaticFiles("/static");

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Picture")),
                RequestPath = "/images"
            });

            //app.Map("/", () => Results.Redirect("/static/Neumann.html"));
            app.MapGet("/hw", () => "Hello World!");

            app.Run();
        }
    }
}
