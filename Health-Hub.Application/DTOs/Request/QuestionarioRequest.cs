using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Hub.Application.DTOs.Request
{
    public class QuestionarioRequest
    {
        public Guid UsuarioId { get; set; }
        public int NivelEstresse { get; set; }
        public int HorasSono {  get; set; }
        public string Observacoes { get; set; }
    }
}
