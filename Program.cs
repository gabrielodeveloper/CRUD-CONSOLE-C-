using System.Reflection.Metadata;

namespace PrimeiroProjeto;

public class Program
{
    static ProdutoColecao produtos = new ProdutoColecao();

    public static void ExibirMenu()
    {
        Console.WriteLine("\n\n=== Escolha qual sua opção!");
        Console.WriteLine("1 - Cadastrar Produto.");
        Console.WriteLine("2 - Consultar Produtos.");
        Console.WriteLine("3 - Consultar Produtos Por Código.");
        Console.WriteLine("4 - Alterar Produto.");
        Console.WriteLine("5 - Excluir Produto.");
        Console.WriteLine("0 - Sair.");
    }

    public static int ObterCodigoValido()
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

            bool codigoExiste = false;

            foreach (var item in produtos)
            {
                if (item.Codigo == codigo)
                {
                    codigoExiste = true; break;
                }
            }

            if (codigoExiste)
            {
                Console.WriteLine("Este código já foi usado. Tente novamente.");
                continue;
            }
            return codigo;
        }
    }

    public static string ObterDescricaoValida()
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

    public static decimal ObterPrecoValido()
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

    public static int ObterEstoqueValido()
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

    public static bool ObterAtivoValido()
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
                produto.Descricao = ObterDescricaoValida();
                produto.Preco = ObterPrecoValido();
                produto.Estoque = ObterEstoqueValido();
                produto.Ativo = ObterAtivoValido();

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
    public static void CadastrarProduto()
    {
        Produto produto = new Produto();

        Console.WriteLine("=== Cadastro de Produto ===");

        produto.Codigo = ObterCodigoValido();
        produto.Descricao = ObterDescricaoValida();
        produto.Preco = ObterPrecoValido();
        produto.Estoque = ObterEstoqueValido();
        produto.Ativo = ObterAtivoValido();
        produtos.Add(produto);

    }
    public static void Main(string[] args)
    {
        ExibirMenu();
        int opcao = Convert.ToInt32(Console.ReadLine());

        while (opcao != 0)
        {
            switch (opcao)
            {
                case 1:
                    CadastrarProduto();
                    break;

                case 2:
                    ConsultarProduto();
                    break;

                case 3:
                    ConsultarProdutoPorCodigo();
                    break;

                case 4:
                    AlterarProduto();
                    break;
                case 5:
                    ExcluirProduto();
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            ExibirMenu();
            opcao = Convert.ToInt32(Console.ReadLine());
        }

    }
}


