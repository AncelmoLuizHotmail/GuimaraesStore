namespace GuimaraesStore.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(int id, string nome, string cpf, DateTime dataNascimento, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            Telefone = telefone;
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        public List<Pedido> Pedidos { get; private set; }
    }

}
