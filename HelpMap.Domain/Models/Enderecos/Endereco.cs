
using NetTopologySuite.Geometries;

namespace HelpMap.Domain.Models.Grupos
{
    public class Endereco : Entity
    {
        public Endereco() { }

        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public string PontoReferencia { get; set; }
        public Point Localizacao { get; set; }
    }
}
