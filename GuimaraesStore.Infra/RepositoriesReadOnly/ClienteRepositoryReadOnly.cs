using GuimaraesStore.Domain.Entities;
using GuimaraesStore.Domain.Interfaces.RepositoriesReadOnly;
using GuimaraesStore.Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GuimaraesStore.Infra.RepositoriesReadOnly
{
    public class ClienteRepositoryReadOnly : IClienteRepositoryReadOnly
    {
        protected readonly GuimaraesStoreContext _context;

        public ClienteRepositoryReadOnly(GuimaraesStoreContext contexto)
        {
            _context = contexto;
        }

        public async Task<List<Cliente>> ObterTodos()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
