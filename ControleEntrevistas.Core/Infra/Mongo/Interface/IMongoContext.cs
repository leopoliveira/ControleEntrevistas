using MongoDB.Driver;

namespace ControleEntrevistas.Core.Infra.Mongo.Interface
{
    public interface IMongoContext
    {
        IMongoDatabase GetDatabase();

        IMongoCollection<T> GetCollection<T>(string? name = null);
    }
}
