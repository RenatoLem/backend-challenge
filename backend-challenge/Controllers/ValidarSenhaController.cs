using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using backend_challenge.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace backend_challenge.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Route("ValidarSenha")]
    public class ValidarSenhaController : ControllerBase
    {
        private readonly ILogger<ValidarSenhaController> _logger;

        public ValidarSenhaController(ILogger<ValidarSenhaController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ValidarSenhaResponse ValidarSenha([FromBody] ValidarSenhaRequest Req)
        {
            ValidarSenhaResponse resposta = new ValidarSenhaResponse();
            Regex validacao = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d!@#$%^&*()-+]{9,}$");

            bool _caracteresValidos = validacao.IsMatch(Req.Senha);

            if (!Req.CaseSensitive)
            {
                Req.Senha = Req.Senha.ToLower();
            }

            List<char> caracteres = new List<char>();
            caracteres.AddRange(Req.Senha.ToCharArray());


            bool _caracteresRepetidos = false;
            for (int i = 0; i < caracteres.Count - 1; i++)
            {
                if (caracteres.IndexOf(caracteres[i]) != i || caracteres.LastIndexOf(caracteres[i]) != i)
                {
                    _caracteresRepetidos = true;
                    break;
                }
            }

            resposta.Valido = _caracteresValidos && !_caracteresRepetidos;
            return resposta;
        }

        [HttpGet]
        public String RecusarChamadaValidarSenha()
        {
            return "Apenas chamadas 'POST' são atendidas!";
        }

    }
}
