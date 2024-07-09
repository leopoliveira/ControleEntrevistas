using ControleEntrevistas.Core.Application.Exceptions;
using ControleEntrevistas.Core.Entidade;
using ControleEntrevistas.Core.Entidade.Repository.Interface;
using ControleEntrevistas.Core.Infra.Mongo.Collections;
using ControleEntrevistas.Core.Infra.Mongo.Interface;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace ControleEntrevistas.Core.Entidade.Repository
{
    public class CandidaturaRepository : ICandidaturaRepository
    {
        private readonly IMongoCollection<Candidatura> _collection;

        public CandidaturaRepository(IMongoContext context)
        {
            _collection = context.GetCollection<Candidatura>(CollectionsName.CANDIDATURA);
        }

        public async Task<Candidatura> GetByIdAsync(string id) =>
            await _collection
            .Find(p => p.Id == id)
            .FirstOrDefaultAsync();

        public async Task<IReadOnlyList<Candidatura>> GetByFilterAsync(Expression<Func<Candidatura, bool>> filter, int page, int pageSize) =>
            await _collection
            .Find(filter)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        public async Task<IReadOnlyList<Candidatura>> GetByFilterAsync(FilterDefinition<Candidatura> filter, int page, int pageSize) =>
            await _collection
            .Find(filter)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        public async Task<long> CountByFilterAsync(FilterDefinition<Candidatura> filter)
        {
            return await _collection
            .CountDocumentsAsync(filter);
        }

        public async Task CreateAsync(Candidatura entity) =>
            await _collection
            .InsertOneAsync(entity);

        public async Task UpdateAsync(string id, Candidatura entity)
        {
            await _collection
                .ReplaceOneAsync(p => p.Id == id, entity);
        }
    }
}
