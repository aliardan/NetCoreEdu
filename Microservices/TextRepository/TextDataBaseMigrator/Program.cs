using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TextRepository;

namespace TextDataBaseMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

            var textDataBaseOptions = config.GetSection("TextDataBaseOptions").Get<TextDataBaseOptions>();

            TextDataBaseContext textDataBaseContext = new TextDataBaseContext(Options.Create(textDataBaseOptions));
            textDataBaseContext.Database.Migrate();
        }
    }
}
