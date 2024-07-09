using System.Linq.Expressions;
using System.Xml;
using ControleEntrevistas.Core.Application.DTOs;
using ControleEntrevistas.Core.Entidade;
using ControleEntrevistas.Core.Entidade.Repository.Interface;
using MongoDB.Driver;

namespace ControleEntrevistas.Core.Application.Services
{
    public class CandidaturaService : ICandidaturaService
    {
        private readonly ICandidaturaRepository _repository;

        public CandidaturaService(ICandidaturaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Candidatura> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<CandidaturaResponse>> GetByFiltersAsync(
            GetCandidaturasFilterDto dtoFilter
        )
        {
            var builder = Builders<Candidatura>.Filter;
            var filters = new List<FilterDefinition<Candidatura>>();

            BuildFilter(dtoFilter, builder, filters);

            var filterDefBuilder = new FilterDefinitionBuilder<Candidatura>().And(filters);

            return await GetByFilterAsync(filterDefBuilder, dtoFilter.Page, dtoFilter.PageSize);
        }

        public async Task<IReadOnlyList<CandidaturaResponse>> GetByFilterAsync(
            Expression<Func<Candidatura, bool>> filter,
            int page,
            int pageSize
        )
        {
            var candidaturas = await _repository.GetByFilterAsync(filter, page, pageSize);

            var count = await _repository.CountByFilterAsync(filter);

            return candidaturas
                .Select(c => new CandidaturaResponse(c, page, pageSize, (int)count))
                .ToList();
        }

        public async Task<IReadOnlyList<CandidaturaResponse>> GetByFilterAsync(
            FilterDefinition<Candidatura> filter,
            int page,
            int pageSize
        )
        {
            var candidaturas = await _repository.GetByFilterAsync(filter, page, pageSize);

            var count = await _repository.CountByFilterAsync(filter);

            return candidaturas
                .Select(c => new CandidaturaResponse(c, page, pageSize, (int)count))
                .ToList();
        }

        public async Task CreateAsync(Candidatura entity)
        {
            await _repository.CreateAsync(entity);
        }

        public async Task UpdateAsync(string id, Candidatura entity)
        {
            await _repository.UpdateAsync(id, entity);
        }

        private static void BuildFilter(
            GetCandidaturasFilterDto dtoFilter,
            FilterDefinitionBuilder<Candidatura> builder,
            List<FilterDefinition<Candidatura>> filters
        )
        {
            BuildIdsFilter(dtoFilter, builder, filters);

            BuildLocaisInscricaoFilter(dtoFilter, builder, filters);

            BuildEtapaFilter(dtoFilter, builder, filters);

            BuildInscricaoFilter(dtoFilter, builder, filters);

            BuildConclusaoFilter(dtoFilter, builder, filters);

            BuildPassosFilter(dtoFilter, builder, filters);
        }

        private static void BuildIdsFilter(
            GetCandidaturasFilterDto dtoFilter,
            FilterDefinitionBuilder<Candidatura> builder,
            List<FilterDefinition<Candidatura>> filters
        )
        {
            if (dtoFilter.Ids?.Any() == true)
            {
                filters.Add(builder.In(c => c.Id, dtoFilter.Ids));
            }
        }

        private static void BuildLocaisInscricaoFilter(
            GetCandidaturasFilterDto dtoFilter,
            FilterDefinitionBuilder<Candidatura> builder,
            List<FilterDefinition<Candidatura>> filters
        )
        {
            if (dtoFilter.LocaisInscricao?.Any() == true)
            {
                filters.Add(builder.In(c => c.LocalInscricao, dtoFilter.LocaisInscricao));
            }
        }

        private static void BuildEtapaFilter(
            GetCandidaturasFilterDto dtoFilter,
            FilterDefinitionBuilder<Candidatura> builder,
            List<FilterDefinition<Candidatura>> filters
        )
        {
            if (dtoFilter.Etapas?.Any() == true)
            {
                filters.Add(builder.In(c => c.Etapa, dtoFilter.Etapas));
            }
        }

        private static void BuildInscricaoFilter(
            GetCandidaturasFilterDto dtoFilter,
            FilterDefinitionBuilder<Candidatura> builder,
            List<FilterDefinition<Candidatura>> filters
        )
        {
            if (dtoFilter.Inscricao.HasValue)
            {
                filters.Add(builder.Eq(c => c.Inscricao, dtoFilter.Inscricao.Value));
            }
        }

        private static void BuildConclusaoFilter(
            GetCandidaturasFilterDto dtoFilter,
            FilterDefinitionBuilder<Candidatura> builder,
            List<FilterDefinition<Candidatura>> filters
        )
        {
            if (dtoFilter.Conclusao.HasValue)
            {
                filters.Add(builder.Eq(c => c.Conclusao, dtoFilter.Conclusao.Value));
            }
        }

        private static void BuildPassosFilter(
            GetCandidaturasFilterDto dtoFilter,
            FilterDefinitionBuilder<Candidatura> builder,
            List<FilterDefinition<Candidatura>> filters
        )
        {
            if (dtoFilter.Passos?.Any() == true)
            {
                filters.Add(builder.In(c => c.Passo, dtoFilter.Passos));
            }
        }
    }
}
