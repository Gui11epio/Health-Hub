using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Hub.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string EmailCorporativo { get; set; }
        public string Nome { get; set; }
        public string SenhaHash { get; set; }
        public string TipoUsuario { get; set; } = "Funcionário";

        public ICollection<Questionario> Questionarios { get; set; } = new List<Questionario>();
        public ICollection<Relatorio> Relatorios { get; set; } = new List<Relatorio>();
    }
}
