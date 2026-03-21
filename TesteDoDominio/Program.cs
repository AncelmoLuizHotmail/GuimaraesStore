// See https://aka.ms/new-console-template for more information
using TesteDoDominio.Services;

Console.WriteLine("Bem vindo ao GuimaraesStore");
//Services do projeto
var produtoService = new ProdutoService();
var clienteService = new ClienteService();
var pedidoService = new PedidoService();

//Criar produtos
var produtos = produtoService.CriarProdutos();
produtoService.ExibirProdutos(produtos);

//Criar cliente
var cliente = clienteService.CriarCliente();
clienteService.ExibirCliente(cliente);

Console.WriteLine();

//Criar pedido
var pedido = pedidoService.CriarPedido(cliente);

//Adicionar itens ao pedido
Console.WriteLine("Adicionar itens ao pedido");

char resposta;

do
{
    Console.Write("Informe o código do produto: ");
    var codigoProduto = int.Parse(Console.ReadLine());
    var produtoSelecionado = produtos.FirstOrDefault(p => p.Id == codigoProduto);

    Console.Write("Informe a quantidade: ");
    var quantidade = int.Parse(Console.ReadLine());

    if (produtoSelecionado == null || quantidade <= 0)
    {
        Console.WriteLine("Produto inválido ou quantidade inválida. Tente novamente.");
    }
    else
    {
        pedidoService.AdicionarItem(pedido, produtoSelecionado, quantidade);
    }

    Console.WriteLine("Deseja adicionar mais itens? (S/N)");
    resposta = char.Parse(Console.ReadLine());

    Console.WriteLine();
} while (resposta == 'S' || resposta == 's');

//Exibir resumo do pedido
pedidoService.ExibirPedido(pedido);

Console.WriteLine();
Console.WriteLine("Deseja remover algum item do pedido? (S/N)");
var respostaRemover = char.Parse(Console.ReadLine());

while (respostaRemover == 'S' || respostaRemover == 's')
{
    Console.Write("Digite o código do produto: ");
    var codigoProdutoRemover = int.Parse(Console.ReadLine());
    var itemPedido = pedido.Itens.FirstOrDefault(i => i.ProdutoId == codigoProdutoRemover);

    Console.WriteLine("Digite a quantidade a remover: ");
    var quantidadeRemover = int.Parse(Console.ReadLine());

    pedidoService.DiminuirQuantidadeItem(pedido, itemPedido.ProdutoId, quantidadeRemover);

    Console.WriteLine("Deseja remover mais algum item do pedido? (S/N)");
    respostaRemover = char.Parse(Console.ReadLine());
}

//Exibir resumo do pedido
pedidoService.ExibirPedido(pedido);

////FECHAR O PEDIDO
Console.WriteLine();
Console.WriteLine("Deseja Fechar o pedido? (S/N)");
var respostaFechar = char.Parse(Console.ReadLine());

if (respostaFechar == 'S' || respostaFechar == 's')
{
    pedidoService.FecharPedido(pedido);
}

//PAGAR O PEDIDO
Console.WriteLine();
Console.WriteLine("Deseja Pagar o pedido? (S/N)");
var respostaPagar = char.Parse(Console.ReadLine());

if (respostaPagar == 'S' || respostaPagar == 's')
{
    pedidoService.PagarPedido(pedido);
}
else
{
    pedidoService.CancelarPedido(pedido);
}

Console.WriteLine();
pedidoService.ExibirPedido(pedido);

Console.WriteLine();
produtoService.ExibirProdutos(produtos);



