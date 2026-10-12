namespace PimTintas.API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string Cor { get; set; } = string.Empty;
        public string CorHex { get; set; } = string.Empty;      // NOVO: Ex: "#F8FAFC"
        public string TipoTinta { get; set; } = string.Empty;   // NOVO: Ex: "Acrílica", "Esmalte"
        public string Volume { get; set; } = string.Empty;      // Ex: "18L", "3.6L"
    }
}