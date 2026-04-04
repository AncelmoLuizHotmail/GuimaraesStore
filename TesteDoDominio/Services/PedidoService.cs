using GuimaraesStore.Domain.Entities;
using GuimaraesStore.Domain.Enums;

namespace TesteDoDominio.Services
{
    public class PedidoService
    {
        private Pedido _pedido;

        public void CriarPedido(Cliente cliente)
        {
            _pedido = new Pedido(cliente);

            Console.Clear();
            Console.WriteLine("** Criando um novo pedido **");
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            _pedido.AdicionarItem(produto, quantidade);

            produto.DebitarEstoque(quantidade);
        }

        public void DiminuirQuantidadeItem(int produtoId, int quantidade)
        {
            _pedido.DiminuirQuantidadeItem(produtoId, quantidade);
        }

        public void FecharPedido()
        {
            _pedido.Fechar();

            Console.Clear();
            Console.WriteLine("** Pedido fechado com sucesso! **");
        }

        public void PagarPedido()
        {
            _pedido.Pagar();

            Console.Clear();
            Console.WriteLine("** Pedido pago com sucesso! **");
        }

        public void CancelarPedido()
        {
            _pedido.Cancelar();

            foreach (var item in _pedido.Itens)
            {
                item.Produto.ReporEstoque(item.Quantidade);
            }

            Console.Clear();
            Console.WriteLine("** Pedido cancelado com sucesso! **");
        }

        public void ExibirPedido()
        {
            Console.Clear();
            Console.WriteLine("<<--- RESUMO DO PEDIDO --->>");
            Console.WriteLine($"Pedido do cliente: {_pedido.Cliente.Nome}");
            Console.WriteLine("Itens do Pedido:");
            foreach (var item in _pedido.Itens)
            {
                Console.WriteLine($"Codigo: {item.ProdutoId} | {item.Produto.Nome} | Qtd: {item.Quantidade} | Valor Unit.: {item.Produto.Preco:C} | Total: {item.ValorarItem():C}");
            }
            Console.WriteLine($"Valor Total do Pedido: {_pedido.ValorTotal:C}");
            Console.WriteLine($"Status do Pedido: {_pedido.Status}");
        }

        public bool ValidarPedido()
        {
            if (_pedido == null)
                return false;

            if (_pedido.Status != StatusPedidoEnum.Aberto)
                return false;

            return true;
        }

        public bool ValidarPedidoParaSerFechado()
        {
            if (_pedido == null)
                return false;

            if (_pedido.Status == StatusPedidoEnum.Fechado || _pedido.Status == StatusPedidoEnum.Pago)
                return false;

            return true;
        }

        public bool ValidarPedidoParaSerPago()
        {
            if (_pedido == null)
                return false;

            if (_pedido.Status == StatusPedidoEnum.Pago || _pedido.Status == StatusPedidoEnum.Cancelado)
                return false;

            return true;
        }

        public bool ValidarPedidoParaSerCancelado()
        {
            if (_pedido == null)
                return false;

            if (_pedido.Status == StatusPedidoEnum.Pago)
                return false;

            return true;
        }
    }
}
