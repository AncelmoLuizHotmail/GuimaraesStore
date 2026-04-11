namespace GuimaraesStore.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        protected Cliente() { }
        public Cliente(string nome, string cpf, string email, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        public List<Pedido> Pedidos { get; private set; }
    }

}
