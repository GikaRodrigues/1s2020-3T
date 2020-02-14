using Senai.MeuPonto.WebApi.Domains;
using Senai.MeuPonto.WebApi.Interfaces;
using Senai.MeuPonto.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MeuPonto.WebApi.Repositorios
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private PontoContext context;

        public UsuariosRepositorio(PontoContext context)
        {
            this.context = context;
        }

        public void Cadastrar(Usuarios usuario)
        {
            using(PontoContext ctx = new PontoContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public Usuarios EfetuarLogin(LoginViewModel login)
        {
            using (PontoContext ctx = new PontoContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                {
                    return null;
                }
                return usuario;
            }
        }

        //public Usuarios EfetuarLogin(string email, string senha)
        //{
        //    try
        //    {
        //        //Busca um usuário a partir do seu e-mail e senha
        //        return _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw new System.Exception(ex.Message);
        //    }
        //}
    }
}
