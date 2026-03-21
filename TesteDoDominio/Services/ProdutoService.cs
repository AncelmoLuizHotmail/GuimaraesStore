using GuimaraesStore.Domain.Entities;
using TesteDoDominio.Factories;

namespace TesteDoDominio.Services
{
    public class ProdutoService
    {
        public List<Produto> CriarProdutos()
        {
            return DadosFakeFactory.CriarProdutos();
        }

        public void ExibirProdutos(List<Produto> produtos)
        {
            Console.WriteLine("Lista de Produtos");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Código: {produto.Id} - Nome: {produto.Nome} - Preço: {produto.Preco:C} - Estoque: {produto.QuantidadeEstoque}");
            }
            Console.WriteLine();
        }
    }
}
