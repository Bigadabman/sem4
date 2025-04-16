using Microsoft.AspNetCore.HttpLogging;
namespace ASPA001
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); //������� webApplicationBulder (������� builder)

            builder.Services.AddHttpLogging(// ����� � ������
                                                logging =>
                                                {
                                                    logging.LoggingFields = HttpLoggingFields.RequestMethod | //request �����
                                                 HttpLoggingFields.RequestPath | // request uri
                                                 HttpLoggingFields.ResponseStatusCode | // response status
                                                 HttpLoggingFields.ResponseBody; // response ����
                                                }
                                            );

            builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);  // ������ ���������

            var app = builder.Build(); // ������� ��������� webApplication


            app.UseHttpLogging();  // middleware: ����� � ������


            app.MapGet("/", () => "��� ������ ASPA"); // ������� �������� �����
            

            app.Run(); // ��������� web-����������
        }
    }
}
