namespace POCConvertToXML
{
    public class Produto : BaseSerializavel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
