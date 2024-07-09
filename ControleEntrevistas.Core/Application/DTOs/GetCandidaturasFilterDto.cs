using ControleEntrevistas.Core.Enums;

namespace ControleEntrevistas.Core.Application.DTOs
{
    public record GetCandidaturasFilterDto
    (
        IEnumerable<string>? Ids,
        IEnumerable<EnumLocalCadastro>? LocaisInscricao,
        IEnumerable<EnumEtapa>? Etapas,
        DateTime? Inscricao,
        DateTime? Conclusao,
        IEnumerable<EnumPasso>? Passos,
        int Page = 1,
        int PageSize = 10
    );
}
