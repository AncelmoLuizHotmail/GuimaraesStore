using GuimaraesStore.Domain.Enums;

namespace GuimaraesStore.Domain.Entities
{
    public class Produto : BaseEntity
    {
        //EF
        protected Produto() { }

        public Produto(int id,
            string nome,
            string descricao,
            decimal preco,
            TipoProdutoEnum tipoProduto,
            int quantidadeEstoque)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            TipoProduto = tipoProduto;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public TipoProdutoEnum TipoProduto { get; private set; }
        public int QuantidadeEstoque { get; private set; }


        public void Atualizar(string nome, string descricao, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            DataAlteracao = DateTime.Now;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade > QuantidadeEstoque)
                throw new InvalidOperationException("Quantidade em estoque insuficiente.");

            QuantidadeEstoque -= quantidade;
            DataAlteracao = DateTime.Now;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
            DataAlteracao = DateTime.Now;
        }

    }

}
