using GuimaraesStore.Domain.Enums;

namespace GuimaraesStore.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public Pedido(int clienteId, StatusPedidoEnum status)
        {
            ClienteId = clienteId;
            Status = status;
            DataCadastro = DateTime.Now;
            Itens = new List<ItemPedido>();
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

        private void CalcularValorTotal()
        {
            ValorTotal = Itens.Sum(i => i.Quantidade * i.Produto.Preco);
        }
    }
}

