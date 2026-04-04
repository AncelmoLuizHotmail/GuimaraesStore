using GuimaraesStore.Domain.Entities;
using TesteDoDominio.Factories;

namespace TesteDoDominio.Services
{
    public class ProdutoService
    {
        private List<Produto> _produtos;

        public void CriarProdutos()
        {
            _produtos = DadosFakeFactory.CriarProdutos();
        }

        public void ExibirProdutos()
        {
            Console.Clear();
            Console.WriteLine("Lista de Produtos");
            foreach (var produto in _produtos)
            {
                Console.WriteLine($"Código: {produto.Id} - Nome: {produto.Nome} - Preço: {produto.Preco:C} - Estoque: {produto.QuantidadeEstoque}");
            }
            Console.WriteLine();
        }

        public Produto BuscarPorId(int id)
        {
            return _produtos.FirstOrDefault(p => p.Id == id);
        }
    }
}
