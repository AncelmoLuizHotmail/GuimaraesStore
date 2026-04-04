// See https://aka.ms/new-console-template for more information
using TesteDoDominio.Services;

//Services do projeto
var produtoService = new ProdutoService();
var clienteService = new ClienteService();
var pedidoService = new PedidoService();

//Criar produtos
produtoService.CriarProdutos();

//Criar cliente
var cliente = clienteService.CriarCliente();


Console.WriteLine("Bem vindo ao GuimaraesStore");
Console.WriteLine();

var executando = true;

while (executando)
{
    Console.WriteLine();
    Console.WriteLine("-- MENU --");
    Console.WriteLine("[ 1 ] - Listar Produtos");
    Console.WriteLine("[ 2 ] - Criar Pedido");
    Console.WriteLine("[ 3 ] - Adicionar Item");
    Console.WriteLine("[ 4 ] - Remover Item");
    Console.WriteLine("[ 5 ] - Exibir Resumo do Pedido");
    Console.WriteLine("[ 6 ] - Fechar Pedido");
    Console.WriteLine("[ 7 ] - Pagar Pedido");
    Console.WriteLine("[ 8 ] - Cancelar Pedido");
    Console.WriteLine("[ 0 ] - Sair");

    Console.Write("Escolha uma opção: ");
    int opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 0:
            executando = false;
            break;
        case 1:
            produtoService.ExibirProdutos();
            break;
        case 2:
            pedidoService.CriarPedido(cliente);
            break;
        case 3:
            if (ValidarPedido())
                AdicionarItem();
            break;
        case 4:
            if (ValidarPedido())
                RemoverItem();
            break;
        case 5:
            pedidoService.ExibirPedido();
            break;
        case 6:
            if (ValidarPedidoParaFechar())
                pedidoService.FecharPedido();
            break;
        case 7:
            if (ValidarPedidoParaPagar())
                pedidoService.PagarPedido();
            break;
        case 8:
            if (ValidarPedidoParaCancelar())
                pedidoService.CancelarPedido();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Opção Inválida. Por favor, escolha uma opção válida.");
            break;
    }
}

void AdicionarItem()
{
    Console.Write("Informe o código do produto: ");
    var codigoProduto = int.Parse(Console.ReadLine());
    var produtoSelecionado = produtoService.BuscarPorId(codigoProduto);

    Console.Write("Informe a quantidade: ");
    var quantidade = int.Parse(Console.ReadLine());

    if (produtoSelecionado == null || quantidade <= 0)
    {
        Console.Clear();
        Console.WriteLine("Produto inválido ou quantidade inválida. Tente novamente.");
    }
    else
    {
        Console.Clear();
        pedidoService.AdicionarItem(produtoSelecionado, quantidade);
        Console.WriteLine("Item adicionado com sucesso!");
    }
}

bool ValidarPedido()
{
    if (!pedidoService.ValidarPedido())
    {
        Console.Clear();
        Console.WriteLine("Nenhum pedido criado. Por favor, crie um pedido antes de adicionar/remover itens.");
        return false;
    }

    return true;
}

bool ValidarPedidoParaFechar()
{
    if (!pedidoService.ValidarPedidoParaSerFechado())
    {
        Console.Clear();
        Console.WriteLine("Pedido não foi criado ou o pedido não está aberto.");
        return false;
    }
    return true;
}

bool ValidarPedidoParaPagar()
{
    if (!pedidoService.ValidarPedidoParaSerPago())
    {
        Console.Clear();
        Console.WriteLine("Pedido não foi criado ou o pedido não está fechado.");
        return false;
    }
    return true;
}

bool ValidarPedidoParaCancelar()
{
    if (!pedidoService.ValidarPedidoParaSerCancelado())
    {
        Console.Clear();
        Console.WriteLine("Pedido não foi criado ou o pedido já está pago.");
        return false;
    }
    return true;
}

void RemoverItem()
{
    Console.Write("Digite o código do produto a ser removido: ");
    var codigoProdutoRemover = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite a quantidade a remover: ");
    var quantidadeRemover = int.Parse(Console.ReadLine());

    pedidoService.DiminuirQuantidadeItem(codigoProdutoRemover, quantidadeRemover);

    Console.Clear();
    Console.WriteLine("Item removido com sucesso!");
}



