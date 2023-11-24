using Board.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Board
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    //services.AddHostedService<Worker>();
                    ConfigureServices(services);

                })
                .Build();

            host.Run();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            string connectionString =
                         $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=MONGOPDB))); User Id = system; Password = Oracle123;";


            services.AddDbContext<DatabaseConext>(dbContextOptions => dbContextOptions
                                                                        .UseOracle(connectionString).EnableSensitiveDataLogging());

            //services.AddSingleton<IBoardRepository>(new BoardRepository(connectionString));
            Console.WriteLine("Services configured successfully.");

        }
    }
}