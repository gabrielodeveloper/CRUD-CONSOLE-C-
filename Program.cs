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
    public static void Main(string[] args)
    {
        Validacao validacao = new Validacao();
        ProdutoService service = new ProdutoService(produtos, validacao);
        
        try
        {
            ExibirMenu();
            int opcao = Convert.ToInt32(Console.ReadLine());

            while (opcao != 0)
            {
                switch (opcao)
                {
                    case 1:
                        service.CadastrarProduto();
                        break;

                    case 2:
                        service.ConsultarProduto();
                        break;

                    case 3:
                        service.ConsultarProdutoPorCodigo();
                        break;

                    case 4:
                        service.AlterarProduto();
                        break;
                    case 5:
                        service.ExcluirProduto();
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                ExibirMenu();
                opcao = Convert.ToInt32(Console.ReadLine());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível identificar a opção, detalhe: {ex.Message}");
        }

    }
}


