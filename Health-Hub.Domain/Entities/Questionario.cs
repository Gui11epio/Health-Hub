namespace Health_Hub.Domain.Entities
{
    public class Questionario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime RespondidoEm  { get; set; } = DateTime.UtcNow;
        public int NivelEstresse { get; set; }
        public int HorasSono { get; set; }
        public string Anotacoes { get; set; }

    }
}