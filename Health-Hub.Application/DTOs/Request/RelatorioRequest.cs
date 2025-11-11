using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Hub.Application.DTOs.Request
{
    public class RelatorioRequest
    {
        public Guid UsuarioId { get; set; }
        public DateTime InicioPeriodo {  get; set; }
        public DateTime FimPeriodo { get; set;}
    }
}
