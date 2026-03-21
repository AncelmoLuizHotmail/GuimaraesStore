using GuimaraesStore.Domain.Entities;
using TesteDoDominio.Factories;

namespace TesteDoDominio.Services
{
    public class ClienteService
    {
        public Cliente CriarCliente()
        {
            return DadosFakeFactory.CriarCliente();
        }

        public void ExibirCliente(Cliente cliente)
        {
            Console.WriteLine("Dados do Cliente");
            Console.WriteLine($"Nome: {cliente.Nome} ");
            Console.WriteLine();
        }
    }
}
