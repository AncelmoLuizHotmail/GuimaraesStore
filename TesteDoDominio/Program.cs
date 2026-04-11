// See https://aka.ms/new-console-template for more information
using GuimaraesStore.Domain.Entities;
using GuimaraesStore.Domain.Interfaces.RepositoriesReadOnly;
using GuimaraesStore.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using TesteDoDominio.Ioc;
using TesteDoDominio.Services;


//Configuração IOC
var services = new ServiceCollection();
services.AddConsoleApp();
var provider = services.BuildServiceProvider();

var scopedServices = provider.CreateScope().ServiceProvider;

//ACESSO AOS SERVIÇOS
var clienteService = scopedServices.GetRequiredService<IClienteService>();
var clienteRepositoryReadOnly = scopedServices.GetRequiredService<IClienteRepositoryReadOnly>();

//Services do projeto
var produtoService = new ProdutoService();
var pedidoService = new PedidoService();

//Criar produtos
produtoService.CriarProdutos();



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
    Console.WriteLine("[ 9 ] - Criar Cliente");
    Console.WriteLine("[ 10 ] - Listar Clientes");
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
            //pedidoService.CriarPedido(cliente);
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
        case 9:
            await CriarCliente();
            break;
        case 10:
            await ListarClientes();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Opção Inválida. Por favor, escolha uma opção válida.");
            break;
    }
}

async Task CriarCliente()
{
    Console.Clear();

    Console.Write("Informe o nome do cliente: ");
    var nome = Console.ReadLine();

    Console.Write("Informe o nome do email: ");
    var email = Console.ReadLine();

    Console.Write("Informe o telefone: ");
    var telefone = Console.ReadLine();

    Console.Write("Informe o cpf: ");
    var cpf = Console.ReadLine();

    var cliente = new Cliente(nome, cpf, email, telefone);

    await clienteService.Criar(cliente);

    Console.WriteLine("Cliente criado com sucesso!");
}

async Task ListarClientes()
{
    Console.Clear();
    var clientes = await clienteRepositoryReadOnly.ObterTodos();
    Console.WriteLine("Lista de Clientes:");
    foreach (var cliente in clientes)
    {
        Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Email: {cliente.Email}, Telefone: {cliente.Telefone}, CPF: {cliente.Cpf}");
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



