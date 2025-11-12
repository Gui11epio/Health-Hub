using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Hub.Application.DTOs.Response
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string EmailCorporativo { get; set; }
        public string Nome { get; set; }
        public string TipoUsuario { get; set; }
        
    }
}
