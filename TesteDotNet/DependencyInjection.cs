using Microsoft.EntityFrameworkCore;
using TesteDotNet.Business.Services;
using TesteDotNet.Repository.Context;


namespace TesteDotNet
{
    public static class DependencyInjection // STASTIC QUANDO QUE REFERENCIAR ESSA CLASSE EM OUTRA CLASSE
    {
        public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder) //ConfigureDI CONFIGURAÇÃO DE DEPENDENCYINJECTION
        {
            builder.Services.AddDbContext<UsuarioContext>(options =>            //
                options.UseSqlServer(builder.Configuration.GetConnectionString("UsuarioConnectionString")));

            builder.Services.AddScoped<UsuarioService>(); // INJEÇÃO DE DEPENDENCIA

            return builder;
        }
    }
    
}
