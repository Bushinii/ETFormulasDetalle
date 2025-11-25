using Core.Interfaces;
using Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            // Repositorio Genérico
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Repositorios Específicos 
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IFormulaRepository, FormulaRepository>();
            services.AddScoped<IFormulaDetalleRepository, FormulaDetalleRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }
    }
}
