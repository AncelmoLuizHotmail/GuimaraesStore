using GuimaraesStore.Domain.Entities;

namespace GuimaraesStore.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task Criar(Cliente cliente);
        Task Alterar (Cliente cliente);
        Task Excluir (Cliente cliente);
    }
}
