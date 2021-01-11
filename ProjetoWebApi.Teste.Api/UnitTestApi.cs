using ProjetoWebAPI.Service.Business.Authentication;
using System;
using Xunit;

namespace ProjetoWebApi.Teste.Api
{
    public class UnitTestApi
    {
        [Theory]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        [InlineData("AbTp9!fok")]
        public void IsValid(string value)
        {
            try
            {
                ValidationBusiness business = new ValidationBusiness();
                bool result = business.IsValidPassword(value);
                Assert.True(result, $"{value} corresponde a uma senha válida.");
            }
            catch (Exception)
            {
                throw new Exception($"{value} não corresponde a uma senha válida.");
            }
        }
    }
}
