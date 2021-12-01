using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JECognizantProject.ConfigReader
{
    public class jsonReader
    {
        private static IConfigurationRoot? config { get; set; }

        private static IConfigurationRoot getConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json");
            var config = builder.Build();
            return config;
        }

        public static string getAutoUrl() =>
            new string(getConfig().GetSection("url:autoPracticeUrl").Value);

        public static TimeSpan getTimeOut() =>
             TimeSpan.Parse(getConfig().GetSection("time:timeOut").Value);
    }
}
