using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Senai.MeuPonto.WebApi.Domains;
using Senai.MeuPonto.WebApi.Repositorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Senai.MeuPonto.Teste.XUnit.Repositorios
{
    class TestesUsuario
    {

        [Fact]
        public void VerificaSeUsuarioEInvalido()
        {
            var options = new DbContextOptionsBuilder<PontoContext>()
               .UseInMemoryDatabase(databaseName: "UsuarioEInvalido")
               .Options;

            // Use a clean instance of the context to run the test
            using (var context = new PontoContext(options))
            {
                var repositorio = new UsuariosRepositorio(context);
                var validacao = repositorio.EfetuarLogin("MeuPonto@email.com", "12345678");

                Assert.Null(validacao);
            }
        }

        [Fact]
        public void VerificaSeUsuarioEValido()
        {
            var options = new DbContextOptionsBuilder<PontoContext>()
               .UseInMemoryDatabase(databaseName: "UsuarioEValido")
               .Options;

            // Use a clean instance of the context to run the test
            using (var context = new PontoContext(options))
            {
                var repositorio = new UsuariosRepositorio(context);
                var validacao = repositorio.EfetuarLogin("MeuPonto@email.com", "12345678");

                Assert.Null(validacao);
            }
        }

        [Fact]
        public void VerificaSeUsuarioEValidoEInfoCorretas()
        {
            var options = new DbContextOptionsBuilder<PontoContext>()
               .UseInMemoryDatabase(databaseName: "UsuarioEValidoEInfoCorretas")
               .Options;

            Usuarios usuario = new Usuarios()
            {
                Email = "MeuPonto@email.com",
                Senha = "12345678",
                Tipo = "ADMINISTRADOR"
            };

            // Use a clean instance of the context to run the test
            using (var context = new PontoContext(options))
            {
                UsuariosRepositorio repositorio = new UsuariosRepositorio(context);

                context.Usuarios.Add(usuario);
                context.SaveChanges();

                Usuarios usuarioRetorno = repositorio.EfetuarLogin(usuario.Email, usuario.Senha);

                Assert.Equals(usuarioRetorno.Email, usuario.Email);
                Assert.Equals(usuarioRetorno.Senha, usuario.Senha);
            }
        }
    }
}