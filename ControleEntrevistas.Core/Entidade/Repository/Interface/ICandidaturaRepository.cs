using ControleEntrevistas.Core.Entidade;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace ControleEntrevistas.Core.Entidade.Repository.Interface
{
    public interface ICandidaturaRepository
    {
        Task<Candidatura> GetByIdAsync(string id);

        Task<IReadOnlyList<Candidatura>> GetByFilterAsync(Expression<Func<Candidatura, bool>> filter, int page, int pageSize);

        Task<IReadOnlyList<Candidatura>> GetByFilterAsync(FilterDefinition<Candidatura> filter, int page, int pageSize);

        Task<long> CountByFilterAsync(FilterDefinition<Candidatura> filter);

        Task CreateAsync(Candidatura entity);

        Task UpdateAsync(string id, Candidatura entity);
    }
}
