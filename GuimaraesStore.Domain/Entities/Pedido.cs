using GuimaraesStore.Domain.Enums;

namespace GuimaraesStore.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public Pedido(Cliente cliente, StatusPedidoEnum status)
        {
            ClienteId = cliente.Id;
            Status = status;
            DataCadastro = DateTime.Now;
            
            Itens = new List<ItemPedido>();
            Cliente = cliente;
        }


        public DateTime DataCadastro { get; private set; }
        public int ClienteId { get; private set; }
        public StatusPedidoEnum Status { get; private set; }
        public decimal ValorTotal { get; private set; }

        public Cliente Cliente { get; private set; }
        public List<ItemPedido> Itens { get; private set; }


        public void TrocarStatus(StatusPedidoEnum novoStatus)
        {
            Status = novoStatus;
            DataAlteracao = DateTime.Now;
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            var item = new ItemPedido(Id, produto, quantidade);
            Itens.Add(item);

            CalcularValorTotal();
        }

        public void RemoverItem(ItemPedido itemPedido)
        {
            var itemExistente = Itens.FirstOrDefault(ip => ip.Produto.Id == itemPedido.Produto.Id);

            if (itemExistente == null)
                throw new InvalidOperationException("O item não pertence ao pedido!");

            Itens.Remove(itemExistente);

            CalcularValorTotal();
        }

        private void CalcularValorTotal()
        {
            ValorTotal = Itens.Sum(i => i.Quantidade * i.Produto.Preco);
        }
    }
}

