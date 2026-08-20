namespace PrimeiroProjeto;

public class Validacao
{

    private ProdutoColecao produtos;

    public Validacao(ProdutoColecao produtos)
    {
        this.produtos = produtos;
    }
    public int ObterCodigo()
    {
        while (true)
        {
            Console.Write("Código: ");
            string? codigoValido = Console.ReadLine();
            if (!int.TryParse(codigoValido, out int codigo))
            {
                Console.WriteLine("O código digitado é inválido!");
                continue;
            }
            if (codigo < 0)
            {
                Console.WriteLine("O código informado é inválido");
                continue;
            }

            return codigo;
        }
    }

    public string ObterDescricaoValida()
    {
        while (true)
        {
            Console.Write("Descrição: ");
            string? descricao = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(descricao))
            {
                Console.WriteLine("A descrição não pode ser vazia!");
                continue;
            }
            return descricao;
        }
    }

    public decimal ObterPrecoValido()
    {
        while (true)
        {
            Console.Write("Preço: ");
            string? PrecoDigitado = Console.ReadLine();

            if (!decimal.TryParse(PrecoDigitado, out decimal preco))
            {
                Console.WriteLine("O valor informado é inválido!");
                continue;
            }

            if (preco < 0)
            {
                Console.WriteLine("O preço informado não pode ser negativo!");
                continue;
            }

            return preco;
        }
    }

    public int ObterEstoqueValido()
    {
        while (true)
        {
            Console.Write("Estoque: ");
            string? unidadeEstoque = Console.ReadLine();
            if (!int.TryParse(unidadeEstoque, out int estoque))
            {
                Console.WriteLine("O valor informado é inválido!");
                continue;
            }

            if (estoque < 0)
            {
                Console.WriteLine("A quantidade de estoque informada não pode ser negativa!");
                continue;
            }

            return estoque;
        }
    }

    public bool ObterAtivoValido()
    {
        while (true)
        {
            Console.Write("Ativo (true/false): ");
            string? situacao = Console.ReadLine();
            if (!bool.TryParse(situacao, out bool ativo))
            {
                Console.WriteLine("O valor informado é inválido!");
                continue;
            }
            return ativo;
        }
    }


}