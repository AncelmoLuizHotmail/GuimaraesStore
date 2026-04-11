using GuimaraesStore.Domain.Entities;
using GuimaraesStore.Domain.Interfaces.Repositories;
using GuimaraesStore.Infra.Contexto;

namespace GuimaraesStore.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        protected readonly GuimaraesStoreContext _context;

        public ClienteRepository(GuimaraesStoreContext context)
        {
            _context = context;
        }

        public async Task Criar(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
