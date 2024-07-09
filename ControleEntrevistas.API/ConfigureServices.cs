using ControleEntrevistas.Core.Entidade.Repository;
using ControleEntrevistas.Core.Entidade.Repository.Interface;
using ControleEntrevistas.Core.Infra.Mongo.Interface;
using ControleEntrevistas.Core.Infra.Mongo.Settings;

namespace ControleEntrevistas.API
{
    public static class ConfigureServices
    {
        public const string CORS_POLICY = "AllowAll";

        public static void Mongo(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSettings>(configuration.GetSection("Mongo"));

            services.AddSingleton<IMongoConnections, MongoConnections>();
            services.AddSingleton<IMongoContext, MongoContext>();

            ConfigureMongoRepositories(services);
        }

        public static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CORS_POLICY,
                    builder =>
                    {
                        builder.WithOrigins("*")
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
        }

        private static void ConfigureMongoRepositories(IServiceCollection services)
        {
            services.AddScoped<ICandidaturaRepository, CandidaturaRepository>();
        }
    }
}
