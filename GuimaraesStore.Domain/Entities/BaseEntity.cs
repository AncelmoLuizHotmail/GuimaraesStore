namespace GuimaraesStore.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime? DataInclusao { get; protected set; }
        public DateTime? DataAlteracao { get; protected set; }
        public DateTime? DataExclusao { get; protected set; }
    }
}
