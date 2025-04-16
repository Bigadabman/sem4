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
            options.DefaultFileNames.Clear(); // ������� ����� ������ �� ���������
            options.DefaultFileNames.Add("Neumann.html"); // ��������� ����� ��� �����
            app.UseDefaultFiles(options); // ��������� ����������;
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
