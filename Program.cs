using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Build�G�غc���ε{����ҡF
            // Run�G�]�w���ε{�����D�n�B���޿�C�N���ε{���t�m�n��A�i�J�B�檬�A�A�}�l�B�z�ШD�C
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
