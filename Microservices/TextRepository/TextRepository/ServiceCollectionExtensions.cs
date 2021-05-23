using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace TextRepository
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTextRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<TextDataBaseContext>(x => new TextDataBaseContext(x.GetService<IOptions<TextDataBaseOptions>>()));
            serviceCollection.AddTransient<ITextRepository, TextRepository>();
            return serviceCollection;
        }
    }
}
