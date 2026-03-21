namespace GuimaraesStore.Domain.Entities
{
    public class ItemPedido : BaseEntity
    {
        protected ItemPedido() { }
        public ItemPedido(int pedidoId, Produto produto, int quantidade)
        {
            PedidoId = pedidoId;
            ProdutoId = produto.Id;
            Quantidade = quantidade;

            Produto = produto;
        }

        public int PedidoId { get; private set; }
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }


        public Pedido Pedido { get; private set; }
        public Produto Produto { get; private set; }

        public decimal ValorarItem()
        {
            return Quantidade * Produto.Preco;
        }

        public void SomarQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new InvalidOperationException("A quantidade deve ser maior que zero!");

            Quantidade += quantidade;
        }

        public void AtualizarQuantidade(int novaQuantidade)
        {
            if (novaQuantidade < 0)
                throw new InvalidOperationException("Quantidade inválida!");

            Quantidade = novaQuantidade;
        }
    }
}
