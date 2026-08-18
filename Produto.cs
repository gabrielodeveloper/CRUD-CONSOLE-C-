namespace PrimeiroProjeto;
public class Produto
{
    public int Codigo { get; set; }
    public string? Descricao { get; set; }
    public int Estoque { get; set; }

    public Decimal Preco { get; set; }

    public bool Ativo { get; set; }
}