using GuimaraesStore.Domain.Entities;
using GuimaraesStore.Domain.Interfaces.Repositories;
using GuimaraesStore.Domain.Interfaces.Services;

namespace GuimaraesStore.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Criar(Cliente cliente)
        {
            // regras de necessárias para criar um cliente

            await _clienteRepository.Criar(cliente);
        }

        public async Task Alterar(Cliente cliente)
        {
            // regras de necessárias para alterar um cliente

            await _clienteRepository.Alterar(cliente);
        }

        public async Task Excluir(Cliente cliente)
        {
            // regras de necessárias para excluir um cliente

            await _clienteRepository.Excluir(cliente);
        }
    }
}
