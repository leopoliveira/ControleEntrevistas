using ControleEntrevistas.Core.Enums;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ControleEntrevistas.Core.Entidade
{
    public class Candidatura
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Vaga { get; set; } = null!;

        public EnumLocalCadastro LocalInscricao { get; set; }

        public string? Descricao { get; set; }

        public EnumEtapa Etapa { get; set; }

        public DateTime Inscricao { get; set; }

        public DateTime Conclusao { get; set; }

        public EnumPasso Passo { get; set; }
    }
}
