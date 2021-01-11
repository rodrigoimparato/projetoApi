using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoWebApi.Domain.Entities.Logins
{
    public class LoginRequestDTO
    {
        public string Nome { get; set; }

        public string Password { get; set; }
    }
}
