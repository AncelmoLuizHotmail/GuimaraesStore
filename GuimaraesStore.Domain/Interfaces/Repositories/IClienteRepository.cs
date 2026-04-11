using GuimaraesStore.Domain.Entities;

namespace GuimaraesStore.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task Criar(Cliente cliente);
        Task Alterar(Cliente cliente);
        Task Excluir(Cliente cliente);
    }
}
