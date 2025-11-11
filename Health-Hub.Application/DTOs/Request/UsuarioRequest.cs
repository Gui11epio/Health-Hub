using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Hub.Application.DTOs.Request
{
    public class UsuarioRequest
    {
        public string EmailCorporativo { get; set; }
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; } = "Funcionário";
    }
}
