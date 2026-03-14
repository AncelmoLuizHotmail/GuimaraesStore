// See https://aka.ms/new-console-template for more information
using GuimaraesStore.Domain.Entities;
using GuimaraesStore.Domain.Enums;

Console.WriteLine("Bem vindo ao GuimaraesStore");

var listaProdutos = new List<Produto>();

listaProdutos.Add(new Produto(1, "iPhone", "telefone apple", 2000m, TipoProdutoEnum.Telefonia, 20));
listaProdutos.Add(new Produto(2, "Samsung S20", "telefone samsung", 1500m, TipoProdutoEnum.Telefonia, 10));

Console.WriteLine();

foreach (var item in listaProdutos)
{
    Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Descrição: {item.Descricao} - Preço: {item.Preco} - Tipo Produto: {item.TipoProduto} - Quantidade Estoque: {item.QuantidadeEstoque}");
}

Console.WriteLine();

Console.WriteLine("Novo Cliente");
var cliente = new Cliente(1, "João Silva", "123.456.789-00", new DateTime(1990, 5, 20), "teste@teste.com", "69 9999-8888");
Console.WriteLine($"Nome: {cliente.Nome} ");

Console.WriteLine();

var pedido = new Pedido(cliente.Id, StatusPedidoEnum.Aberto);

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

Console.WriteLine($"Itens do Pedido:");
foreach (var item in pedido.Itens)
{
    var produto = listaProdutos.FirstOrDefault(p => p.Id == item.ProdutoId);
    Console.WriteLine($"Produto: {produto.Nome} - Quantidade: {item.Quantidade} - Total Item: R$ {item.ValorarItem()}");
}

Console.WriteLine();
Console.WriteLine($"Valor Total do Pedido: R$ {pedido.ValorTotal} ");

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

Console.WriteLine($"Itens do Pedido:");
foreach (var item in pedido.Itens)
{
    var produto = listaProdutos.FirstOrDefault(p => p.Id == item.ProdutoId);
    Console.WriteLine($"Produto: {produto.Nome} - Quantidade: {item.Quantidade} - Total Item: R$ {item.ValorarItem()}");
}

Console.WriteLine();
Console.WriteLine($"Valor Total do Pedido: R$ {pedido.ValorTotal} ");

//FECHAR O PEDIDO

//PAGAR O PEDIDO

//BAIXAR O ESTOQUE DOS PRODUTOS DO PEDIDO