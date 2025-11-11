using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Hub.Domain.Entities
{
    public class Relatorio
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime ComecoPeriodo { get; set; }
        public DateTime FimPeriodo { get; set; }
        public double EstresseMedio { get; set; }
        public string Resumo { get; set; }
        public DateTime GeradoEm { get; set; } = DateTime.UtcNow;
    }
}
