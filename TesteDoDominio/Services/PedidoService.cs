using GuimaraesStore.Domain.Entities;

namespace TesteDoDominio.Services
{
    public class PedidoService
    {
        public Pedido CriarPedido(Cliente cliente)
        {
            var teste = new Pedido();

            return new Pedido(cliente);
        }

        public void AdicionarItem(Pedido pedido, Produto produto, int quantidade)
        {
            pedido.AdicionarItem(produto, quantidade);

            produto.DebitarEstoque(quantidade);
        }

        public void DiminuirQuantidadeItem(Pedido pedido, int produtoId, int quantidade)
        {
            pedido.DiminuirQuantidadeItem(produtoId, quantidade);
        }

        public void FecharPedido(Pedido pedido)
        {
            pedido.Fechar();
            Console.WriteLine("** Pedido fechado com sucesso! **");
        }

        public void PagarPedido(Pedido pedido)
        {
            pedido.Pagar();
            Console.WriteLine("** Pedido pago com sucesso! **");
        }

        public void CancelarPedido(Pedido pedido)
        {
            pedido.Cancelar();

            foreach (var item in pedido.Itens)
            {
                item.Produto.ReporEstoque(item.Quantidade);
            }

            Console.WriteLine("** Pedido cancelado com sucesso! **");
        }

        public void ExibirPedido(Pedido pedido)
        {
            Console.WriteLine("<<--- RESUMO DO PEDIDO --->>");
            Console.WriteLine($"Pedido do cliente: {pedido.Cliente.Nome}");
            Console.WriteLine("Itens do Pedido:");
            foreach (var item in pedido.Itens)
            {
                Console.WriteLine($"Codigo: {item.ProdutoId} | {item.Produto.Nome} | Qtd: {item.Quantidade} | Valor Unit.: {item.Produto.Preco:C} | Total: {item.ValorarItem():C}");
            }
            Console.WriteLine($"Valor Total do Pedido: {pedido.ValorTotal:C}");
            Console.WriteLine($"Status do Pedido: {pedido.Status}");
        }
    }
}
