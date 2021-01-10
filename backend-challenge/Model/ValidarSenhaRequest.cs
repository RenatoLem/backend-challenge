using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_challenge.Model
{
    public class ValidarSenhaRequest
    {
        public string Senha { get; set; }
        public bool CaseSensitive { get; set; } = false;

    }
}
