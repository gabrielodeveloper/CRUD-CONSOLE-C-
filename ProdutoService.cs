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
    public List<Produto> ObterProduto(int? codigo = null)
    {
        if (codigo.HasValue)
        {
            return produtos
                .Where(produto => produto.Codigo == codigo.Value)
                .ToList();
        }

        return produtos.ToList();
    }

    public void ExibirProduto(Produto produto)
    {
        Console.WriteLine($"Código: {produto.Codigo}");
        Console.WriteLine($"Descrição: {produto.Descricao}");
        Console.WriteLine($"Preço: {produto.Preco}");
        Console.WriteLine($"Estoque: {produto.Estoque}");
        Console.WriteLine($"Ativo: {produto.Ativo}\n");
    }

    public void ConsultarProduto()
    {
        var produtosEncontrados = ObterProduto();
        Console.WriteLine("\n\n===== PRODUTOS CADASTRADOS =====");

        foreach (var produto in produtosEncontrados)
        {
            ExibirProduto(produto);
        }
    }
    public void ConsultarProdutoPorCodigo()
    {
        Console.WriteLine("\nDigite o código do produto desejado.");

        int codigo = validacao.ObterCodigo();
        var produtoEncontrado = ObterProduto(codigo);


        if (!produtoEncontrado.Any())
        {
            Console.WriteLine("Produto não encontrado.");
            return;
        }
        Produto produto = produtoEncontrado[0];
        ExibirProduto(produto);
    }
    public void AlterarProduto()
    {
        Console.Write("\nDigite o código do produto desejado: ");

        int codigo = validacao.ObterCodigo();
        var produtoEncontrado = ObterProduto(codigo);

        if (!produtoEncontrado.Any())
        {
            Console.WriteLine("Produto não encontrado.\n");
            return;
        }
        
        Produto produto = produtoEncontrado[0];

        produto.Descricao = validacao.ObterDescricaoValida();
        produto.Preco = validacao.ObterPrecoValido();
        produto.Estoque = validacao.ObterEstoqueValido();
        produto.Ativo = validacao.ObterAtivoValido();

        ExibirProduto(produto);

    }
    public void CadastrarProduto()
    {
        Produto produto = new Produto();

        Console.WriteLine("=== Cadastro de Produto ===");

        while (true)
        {
            int codigo = validacao.ObterCodigo();
            bool codigoExiste = produtos.Any(produto => produto.Codigo == codigo);

            if (codigoExiste)
            {
                Console.WriteLine("Este código já foi usado. Tente novamente.");
                continue;
            }

            produto.Codigo = codigo;
            break;
        }

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