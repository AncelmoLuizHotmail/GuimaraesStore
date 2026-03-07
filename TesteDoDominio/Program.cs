// See https://aka.ms/new-console-template for more information
using GuimaraesStore.Domain.Entities;
using GuimaraesStore.Domain.Enums;

Console.WriteLine("Bem vindo ao GuimaraesStore");

var listaProdutos = new List<Produto>();

listaProdutos.Add(new Produto(1, "iPhone", "telefone apple", 2000m, TipoProdutoEnum.Telefonia, 20));
listaProdutos.Add(new Produto(2, "Samsung S20", "telefone samsung", 1500m, TipoProdutoEnum.Telefonia, 10));

foreach (var item in listaProdutos)
{
    Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Descrição: {item.Descricao} - Preço: {item.Preco} - Tipo Produto: {item.TipoProduto} - Quantidade Estoque: {item.QuantidadeEstoque}");
}

Console.WriteLine();

Console.WriteLine("Novo Cliente");
var cliente = new Cliente(1, "João Silva", "123.456.789-00", new DateTime(1990, 5, 20), "teste@teste.com", "69 9999-8888");

var pedido = new Pedido(cliente.Id, StatusPedidoEnum.Aberto);

pedido.AdicionarItem(listaProdutos[0], 2);
pedido.AdicionarItem(listaProdutos[1], 1);


Console.WriteLine($"Pedido do cliente: {cliente.Nome} - Status: {pedido.Status} - Data Cadastro: {pedido.DataCadastro}");
Console.WriteLine($"Itens do Pedido:");
foreach (var item in pedido.Itens)
{
    var produto = listaProdutos.FirstOrDefault(p => p.Id == item.ProdutoId);
    Console.WriteLine($"Produto: {produto.Nome} - Quantidade: {item.Quantidade} - Total Item: R$ {item.ValorarItem()}");
}
Console.WriteLine();
Console.WriteLine($"Valor Total do Pedido: R$ {pedido.ValorTotal} ");

