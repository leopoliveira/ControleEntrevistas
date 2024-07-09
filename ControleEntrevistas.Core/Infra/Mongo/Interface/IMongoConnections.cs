using MongoDB.Driver;

namespace ControleEntrevistas.Core.Infra.Mongo.Interface
{
    public interface IMongoConnections
    {
        IMongoDatabase GetDatabase();
    }
}
