using GuimaraesStore.Domain.Entities;
using GuimaraesStore.Domain.Enums;

namespace TesteDoDominio.Factories
{
    public static class DadosFakeFactory
    {
        public static List<Produto> CriarProdutos()
        {
            var listaProdutos = new List<Produto>();

            listaProdutos.Add(new Produto(1, "iPhone", "telefone apple", 2000m, TipoProdutoEnum.Telefonia, 20));
            listaProdutos.Add(new Produto(2, "Samsung S20", "telefone samsung", 1500m, TipoProdutoEnum.Telefonia, 10));

            return listaProdutos;
        }

      
    }
}
