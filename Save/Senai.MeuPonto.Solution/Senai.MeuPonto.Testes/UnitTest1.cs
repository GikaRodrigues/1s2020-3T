using Senai.MeuPonto.WebApi.Domains;
using System;
using Xunit;

namespace Senai.MeuPonto.Testes
{
    public class UnitTest1
    {
        [Fact]
        public void CadastroComSucesso()
        {
            var usuario = new Usuarios
            {
                IdUsuario= 1,
                Ni= "1",
                Nome= "Admin",
                Cpf= "111111111111",
                Email= "MeuPonto@email.com",
                Senha= "12345678",
                Tipo= "ADMINISTRADOR",
                Ativo= "True"
            };
        }
    }
}