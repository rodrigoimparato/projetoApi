using ProjetoWebApi.Domain.Entities.Logins;
using ProjetoWebApi.Infra.CrossCutting.Repository.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjetoWebAPI.Service.Business.Authentication
{
    public class ValidationBusiness
    {
        private readonly ValidationRepository<LoginRequestDTO, LoginResponseDTO> _validation;

        public ValidationBusiness()
        {
            _validation = new ValidationRepository<LoginRequestDTO, LoginResponseDTO>();
        }

        public LoginResponseDTO HasUser(LoginRequestDTO login)
        {
            return _validation.HasUser(login);
        }        

        public bool IsValidPassword(string password)
        {
            if (!CountCaracteres(password) || string.IsNullOrEmpty(password))
                return false;

            if (ContainsCaracterLow(password) &&
                ContainsCaracterUpper(password) &&
                ContainsCaracterNumber(password) &&
                ContainsCaracterSpecial(password) &&
                !ContainsSameCharacter(password) &&
                !ContainsCaracterWhiteSpace(password))
            {
                return true;
            }
            else
                return false;

        }

        private bool CountCaracteres(string password)
        {
            return password.Length >= 9 ? true : false;
        }

        private bool ContainsCaracterLow(string password)
        {
            Regex Low = new Regex(@"[a-z]");
            return Low.IsMatch(password);
        }

        private bool ContainsCaracterUpper(string password)
        {
            Regex Upper = new Regex(@"[A-Z]");
            return Upper.IsMatch(password);
        }

        private bool ContainsCaracterNumber(string password)
        {
            Regex Number = new Regex(@"[0-9]");
            return Number.IsMatch(password);
        }

        private bool ContainsCaracterSpecial(string password)
        {
            Regex Special = new Regex(@"[!@#$%^&*()]");
            return Special.IsMatch(password);
        }

        private bool ContainsCaracterWhiteSpace(string password)
        {
            return password.Contains(" ")? true : false;
        }

        private bool ContainsSameCharacter(string password)
        {
            char[] array = password.ToCharArray();

            foreach (var item in array)
            {
                int count = 0;
                var value = Convert.ToUInt64(item);

                foreach (var item2 in array)
                {
                    var value2 = Convert.ToUInt64(item2);
                    if (value == value2)
                        count++;
                }
                if (count > 1)
                    return true;
            }
            return false;
        }
    }
}
