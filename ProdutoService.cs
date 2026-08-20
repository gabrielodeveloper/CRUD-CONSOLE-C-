namespace PrimeiroProjeto;

public class ProdutoService
{
    static ProdutoColecao produtos = new ProdutoColecao();
 public static void ConsultarProduto()
    {
        foreach (var item in produtos)
        {
            Console.WriteLine("\n\n===== PRODUTOS CADASTRADOS =====");
            Console.WriteLine($"Código: {item.Codigo}");
            Console.WriteLine($"Descrição: {item.Descricao}");
            Console.WriteLine($"Preço: {item.Preco}");
            Console.WriteLine($"Estoque: {item.Estoque}");
            Console.WriteLine($"Ativo: {item.Ativo}");
        }
    }
        public static void ConsultarProdutoPorCodigo()
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
        public static void AlterarProduto()
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
                produto.Descricao = ObterValidacao.ObterDescricaoValida();
                produto.Preco = ObterValidacao.ObterPrecoValido();
                produto.Estoque = ObterValidacao.ObterEstoqueValido();
                produto.Ativo = ObterValidacao.ObterAtivoValido();

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
        public static void CadastrarProduto()
    {
        Produto produto = new Produto();

        Console.WriteLine("=== Cadastro de Produto ===");

        produto.Codigo = ObterValidacao.ObterCodigoValido();
        produto.Descricao = ObterValidacao.ObterDescricaoValida();
        produto.Preco = ObterValidacao.ObterPrecoValido();
        produto.Estoque = ObterValidacao.ObterEstoqueValido();
        produto.Ativo = ObterValidacao.ObterAtivoValido();
        produtos.Add(produto);
    }

        public static void ExcluirProduto()
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