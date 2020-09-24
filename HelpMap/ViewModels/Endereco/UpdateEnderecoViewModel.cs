using NetTopologySuite.Geometries;

namespace HelpMap.ViewModels.Endereco
{
    public class UpdateEnderecoViewModel
    {
        public int Id { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public string PontoReferencia { get; set; }
        public Point Localizacao { get; set; }
        public double Latidude { get; set; }
        public double Longitude { get; set; }
    }
}
