using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoWebApi.Domain.Entities.Logins
{
    public class LoginResponseDTO
    {
        public bool IsValidPassword { get; set; }

        public LoginRequestDTO User { get; set; }
    }
}
