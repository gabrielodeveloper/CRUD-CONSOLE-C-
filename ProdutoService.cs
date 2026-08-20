namespace PrimeiroProjeto;

public class ProdutoService
{

    private ProdutoColecao produtos;
    private Validacao validacao;

    public ProdutoService(ProdutoColecao produtos, Validacao validacao)
    {
        this.produtos = produtos;
        this.validacao = validacao;
    }

    public void ConsultarProduto()
    {
        Console.WriteLine("\n\n===== PRODUTOS CADASTRADOS =====");

      
        produtos.ForEach(produto =>
        {
            Console.WriteLine($"Código: {produto.Codigo}");
            Console.WriteLine($"Descrição: {produto.Descricao}");
            Console.WriteLine($"Preço: {produto.Preco}");
            Console.WriteLine($"Estoque: {produto.Estoque}");
            Console.WriteLine($"Ativo: {produto.Ativo}");
        });
    }
    public void ConsultarProdutoPorCodigo()
    {
        while (true)
        {
            Console.Write("\nDigite o código do produto desejado: ");

            string? codigoDigitado = Console.ReadLine();

            if (!int.TryParse(codigoDigitado, out int codigo))
            {
                Console.WriteLine("O código digitado é inválido!");
                return;
            }

            Produto? produto = produtos.Find(prod => prod.Codigo == codigo);

            if (produto != null)
            {
                Console.WriteLine($"Código: {produto.Codigo}");
                Console.WriteLine($"Descrição: {produto.Descricao}");
                Console.WriteLine($"Preço: {produto.Preco}");
                Console.WriteLine($"Estoque: {produto.Estoque}");
                Console.WriteLine($"Ativo: {produto.Ativo}");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.\n");
            }
            break;
        }
    }
    public void AlterarProduto()
    {
        while (true)
        {
            Console.Write("\nDigite o código do produto desejado: ");

            string? codigoDigitado = Console.ReadLine();

            if (!int.TryParse(codigoDigitado, out int codigo))
            {
                Console.WriteLine("O código digitado é inválido!");
                return;
            }

            Produto? produto = produtos.Find(prod => prod.Codigo == codigo);

            if (produto != null)
            {
                produto.Descricao = validacao.ObterDescricaoValida();
                produto.Preco = validacao.ObterPrecoValido();
                produto.Estoque = validacao.ObterEstoqueValido();
                produto.Ativo = validacao.ObterAtivoValido();

                Console.WriteLine($"Código: {produto.Codigo}");
                Console.WriteLine($"Descrição: {produto.Descricao}");
                Console.WriteLine($"Preço: {produto.Preco}");
                Console.WriteLine($"Estoque: {produto.Estoque}");
                Console.WriteLine($"Ativo: {produto.Ativo}");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.\n");
            }
            break;
        }
    }
    public void CadastrarProduto()
    {
        Produto produto = new Produto();

        Console.WriteLine("=== Cadastro de Produto ===");

        produto.Codigo = validacao.ObterCodigoValido();
        produto.Descricao = validacao.ObterDescricaoValida();
        produto.Preco = validacao.ObterPrecoValido();
        produto.Estoque = validacao.ObterEstoqueValido();
        produto.Ativo = validacao.ObterAtivoValido();
        produtos.Add(produto);
    }

    public void ExcluirProduto()
    {
        Console.Write("\nDigite o código do produto que deseja excluir: ");

        string? codigoDigitado = Console.ReadLine();

        if (!int.TryParse(codigoDigitado, out int codigo))
        {
            Console.WriteLine("O código digitado é inválido!");
            return;
        }

        Produto? produto = produtos.Find(prod => prod.Codigo == codigo);

        Console.Write("\nVocê realmente deseja excluir este produto? ex:[S/N] ");
        string? opcao = Console.ReadLine();

        if (produto != null)
        {
            if (opcao != null && opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                produtos.Remove(produto);
                Console.WriteLine("Produto excluído com sucesso!");
            }
            else if (opcao != null && opcao.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            else
            {
                Console.WriteLine("A opção digitada é inválido!");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado.\n");
        }
    }
}