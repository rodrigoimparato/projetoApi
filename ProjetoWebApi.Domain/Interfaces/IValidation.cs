using ProjetoWebApi.Domain.Entities.Logins;

namespace ProjetoWebApi.Domain.Interfaces
{
    public interface IValidation<Request, Response> where Request : LoginRequestDTO where Response : LoginResponseDTO
    {
        Response HasUser(Request data);

        Response IsPasswordCorrect(Request data);
    }
}
