using ProjetoWebApi.Domain.Entities.Logins;
using ProjetoWebApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoWebApi.Infra.CrossCutting.Repository.Validation
{
    public class ValidationRepository<Request, Response> : IValidation<Request, Response> where Request : LoginRequestDTO where Response : LoginResponseDTO
    {
        private Response response;

        public ValidationRepository()
        {
            response = (Response)new LoginResponseDTO();
        }

        public Response HasUser(Request data)
        {
            response.User = new LoginRequestDTO { Nome = "", Password = "" };
            return response;
        }

        public Response IsPasswordCorrect(Request data)
        {
            response.IsValidPassword = true;
            return response;
        }
    }
}
