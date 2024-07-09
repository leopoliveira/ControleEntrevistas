using System.Linq.Expressions;

using ControleEntrevistas.Core.Application.DTOs;
using ControleEntrevistas.Core.Entidade;

using MongoDB.Driver;

namespace ControleEntrevistas.Core.Application.Services
{
    public interface ICandidaturaService
    {
        Task<Candidatura> GetByIdAsync(string id);

        Task<IReadOnlyList<CandidaturaResponse>> GetByFiltersAsync(GetCandidaturasFilterDto dtoFilter);

        Task<IReadOnlyList<CandidaturaResponse>> GetByFilterAsync(Expression<Func<Candidatura, bool>> filter, int page, int pageSize);

        Task<IReadOnlyList<CandidaturaResponse>> GetByFilterAsync(FilterDefinition<Candidatura> filter, int page, int pageSize);

        Task CreateAsync(Candidatura entity);

        Task UpdateAsync(string id, Candidatura entity);
    }
}
