using ControleEntrevistas.Core.Entidade;

namespace ControleEntrevistas.Core.Application.DTOs
{
    public class CandidaturaResponse : Candidatura
    {
        public CandidaturaResponse(Candidatura candidatura, int page, int pageSize, int totalPages)
        {
            Id = candidatura.Id;
            Vaga = candidatura.Vaga;
            LocalInscricao = candidatura.LocalInscricao;
            Descricao = candidatura.Descricao;
            Etapa = candidatura.Etapa;
            Inscricao = candidatura.Inscricao;
            Conclusao = candidatura.Conclusao;
            Passo = candidatura.Passo;
            Page = page;
            PageSize = pageSize;
            TotalPages = totalPages;
        }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }
    }
}
