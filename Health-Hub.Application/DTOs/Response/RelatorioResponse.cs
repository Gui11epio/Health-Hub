using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Hub.Application.DTOs.Response
{
    public class RelatorioResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public double MediaEstresse { get; set; }
        public string Resumo { get; set; }
        public DateTime InicioPeriodo { get; set; }
        public DateTime FimPerido { get; set; }
        public DateTime GeradoEm {  get; set; }
    }
}
