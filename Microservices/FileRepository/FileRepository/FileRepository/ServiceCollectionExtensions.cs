using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FileRepository
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFileRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IFileRepository, FileRepository>();
            return serviceCollection;
        }
    }
}
