using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Hub.Application.DTOs.Response
{
    public class QuestionarioResponse
    {
        public Guid Id { get; set; }
        public DateTime RespondidoEm { get; set; }
        public int NivelEstresse { get; set; }
        public int HorasSono {  get; set; }
        public string Observacoes { get; set; }
    }
}
