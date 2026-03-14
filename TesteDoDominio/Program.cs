// See https://aka.ms/new-console-template for more information
using GuimaraesStore.Domain.Entities;
using GuimaraesStore.Domain.Enums;
using TesteDoDominio;

Console.WriteLine("Bem vindo ao GuimaraesStore");

var listaProdutos = new List<Produto>();

listaProdutos.Add(new Produto(1, "iPhone", "telefone apple", 2000m, TipoProdutoEnum.Telefonia, 20));
listaProdutos.Add(new Produto(2, "Samsung S20", "telefone samsung", 1500m, TipoProdutoEnum.Telefonia, 10));

Console.WriteLine();

Impressao.ImprimirProduto(listaProdutos);

Console.WriteLine();

Console.WriteLine("Novo Cliente");
var cliente = new Cliente(1, "João Silva", "123.456.789-00", new DateTime(1990, 5, 20), "teste@teste.com", "69 9999-8888");
Console.WriteLine($"Nome: {cliente.Nome} ");

Console.WriteLine();

var pedido = new Pedido(cliente, StatusPedidoEnum.Aberto);

Console.WriteLine("Adicionar itens ao pedido");

char resposta;

do
{
    Console.Write("Informe o código do produto: ");
    var codigoProduto = int.Parse(Console.ReadLine());
    var produtoSelecionado = listaProdutos.FirstOrDefault(p => p.Id == codigoProduto);

    Console.Write("Informe a quantidade: ");
    var quantidade = int.Parse(Console.ReadLine());

    if (produtoSelecionado == null || quantidade <= 0)
    {
        Console.WriteLine("Produto inválido ou quantidade inválida. Tente novamente.");
    }
    else
    {
        pedido.AdicionarItem(produtoSelecionado, quantidade);
    }

    Console.WriteLine("Deseja adicionar mais itens? (S/N)");
    resposta = char.Parse(Console.ReadLine());

    Console.WriteLine();

} while (resposta == 'S' || resposta == 's');


Console.WriteLine();
Console.WriteLine($"Pedido do cliente: {cliente.Nome} - Status: {pedido.Status} - Data Cadastro: {pedido.DataCadastro}");
Console.WriteLine();

Impressao.ImprimirPedido(pedido);

Console.WriteLine();
Console.WriteLine("Deseja remover algum item do pedido? (S/N)");
var respostaRemover = char.Parse(Console.ReadLine());

while (respostaRemover == 'S' || respostaRemover == 's')
{
    Console.Write("Digite o código do produto que deseja remover: ");
    var codigoProdutoRemover = int.Parse(Console.ReadLine());
    var itemRemover = pedido.Itens.FirstOrDefault(i => i.ProdutoId == codigoProdutoRemover);

    pedido.RemoverItem(itemRemover);

    Console.WriteLine("Deseja remover mais algum item do pedido? (S/N)");
    respostaRemover = char.Parse(Console.ReadLine());
}

Impressao.ImprimirPedido(pedido);

//FECHAR O PEDIDO
Console.WriteLine();
Console.WriteLine("Deseja Fechar o pedido? (S/N)");
var respostaFechar = char.Parse(Console.ReadLine());

if (respostaFechar == 'S' || respostaFechar == 's')
{
    pedido.TrocarStatus(StatusPedidoEnum.Fechado);
    Console.WriteLine($"Pedido fechado. Status atual: {pedido.Status}");
    Console.WriteLine($"Valor total do pedido: R$ {pedido.ValorTotal}");
}

//PAGAR O PEDIDO
Console.WriteLine($"Cliente: {pedido.Cliente.Nome} pagar o valor de R$ {pedido.ValorTotal} ");
if (pedido.Status == StatusPedidoEnum.Fechado)
{
    pedido.TrocarStatus(StatusPedidoEnum.Pago);
    Console.WriteLine($"Pedido pago. Status atual: {pedido.Status}");

    foreach (var item in pedido.Itens)
    {
        item.Produto.DebitarEstoque(item.Quantidade);
    }
}

Impressao.ImprimirProduto(listaProdutos);

