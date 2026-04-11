using GuimaraesStore.Domain.Entities;

namespace GuimaraesStore.Domain.Interfaces.RepositoriesReadOnly
{
    public interface IClienteRepositoryReadOnly
    {
        Task<List<Cliente>> ObterTodos();
    }
}
