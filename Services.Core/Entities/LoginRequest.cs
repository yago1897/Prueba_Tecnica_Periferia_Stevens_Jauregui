using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Entities
{
    public class LoginRequest
    {
        // Esto es una simulación de una validación simple solo para probar la generación de Tokens y poder acceder a los endPoints ya que están protegidos
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
