using GuimaraesStore.Domain.Entities;

namespace TesteDoDominio
{
    public static class Impressao
    {
        public static void ImprimirPedido(Pedido pedido)
        {
            Console.WriteLine($"Itens do Pedido:");
            foreach (var item in pedido.Itens)
            {
                Console.WriteLine($"Produto: {item.Produto.Nome} - Quantidade: {item.Quantidade} - Total Item: R$ {item.ValorarItem()}");
            }

            Console.WriteLine();
            Console.WriteLine($"Valor Total do Pedido: R$ {pedido.ValorTotal} ");
        }

        public static void ImprimirProduto(List<Produto> produtos)
        {
            foreach (var item in produtos)
            {
                Console.WriteLine($"Produto: {item.Nome}");
                Console.WriteLine($"Descrição: {item.Descricao}");
                Console.WriteLine($"Preço: R$ {item.Preco}");
                Console.WriteLine($"Tipo: {item.TipoProduto}");
                Console.WriteLine($"Quantidade em Estoque: {item.QuantidadeEstoque}");
                Console.WriteLine();
            }
        }
    }
}
