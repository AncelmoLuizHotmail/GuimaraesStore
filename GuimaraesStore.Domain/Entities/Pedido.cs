using GuimaraesStore.Domain.Enums;

namespace GuimaraesStore.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        protected Pedido() { }
       
        public Pedido(Cliente cliente)
        {
            ClienteId = cliente.Id;
            DataCadastro = DateTime.Now;
            Itens = new List<ItemPedido>();
            Cliente = cliente;

            Abrir();
        }


        public DateTime DataCadastro { get; private set; }
        public int ClienteId { get; private set; }
        public StatusPedidoEnum Status { get; private set; }
        public decimal ValorTotal { get; private set; }

        public Cliente Cliente { get; private set; }
        public List<ItemPedido> Itens { get; private set; }

        private void Abrir()
        {
            Status = StatusPedidoEnum.Aberto;
        }

        public void Fechar()
        {
            if(Status != StatusPedidoEnum.Aberto)
                throw new InvalidOperationException("O pedido deve estar aberto para ser fechado!");

            if(Itens.Count == 0)
                throw new InvalidOperationException("O pedido deve conter pelo menos um item para ser fechado!");

            Status = StatusPedidoEnum.Fechado;
        }

        public void Pagar()
        {
            if(Status != StatusPedidoEnum.Fechado)
                throw new InvalidOperationException("O pedido deve estar fechado para ser pago!");

            Status = StatusPedidoEnum.Pago;
        }

        public void Cancelar()
        {
            if(Status == StatusPedidoEnum.Pago)
                throw new InvalidOperationException("O pedido pago não pode ser cancelado!");

            Status = StatusPedidoEnum.Cancelado;
        }


        public void AdicionarItem(Produto produto, int quantidade)
        {
            //Se o produto já existir no pedido, atualiza a quantidade
            var itemExistente = Itens.FirstOrDefault(i => i.ProdutoId == produto.Id);

            if (itemExistente != null)
            {
                itemExistente.SomarQuantidade(quantidade);
            }
            else
            {
                var novoItem = new ItemPedido(Id, produto, quantidade);
                Itens.Add(novoItem);
            }

            CalcularValorTotal();
        }

        //SERVER PARA DIMINUIR A QUANTIDADE DE UM ITEM, SE A QUANTIDADE FOR ZERO, O ITEM É REMOVIDO DO PEDIDO
        public void DiminuirQuantidadeItem(int produtoId, int quantidade)
        {
            var item = Itens.FirstOrDefault(i => i.ProdutoId == produtoId);
            
            if(item == null)
                throw new InvalidOperationException("O item não pertence ao pedido!");

            var novaQuantidade = item.Quantidade - quantidade;
            
            if (novaQuantidade < 0)
                throw new InvalidOperationException("Quantidade inválida!");

            if (novaQuantidade == 0)
            { 
                Itens.Remove(item);
            }
            else
            {
                item.AtualizarQuantidade(novaQuantidade);
            }

            item.Produto.ReporEstoque(quantidade);

            CalcularValorTotal();
        }

        private void CalcularValorTotal()
        {
            ValorTotal = Itens.Sum(i => i.Quantidade * i.Produto.Preco);
        }
    }
}

