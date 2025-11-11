using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Hub.Application.DTOs.Response
{
    public class UsuarioResponse
    {
        public Guid Id { get; set; }
        public string EmailCorporativo { get; set; }
        public string NomeCompleto { get; set; }
        public string TipoUsuario { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
