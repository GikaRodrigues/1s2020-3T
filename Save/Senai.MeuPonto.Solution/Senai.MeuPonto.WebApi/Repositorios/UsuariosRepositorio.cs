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
        public void Cadastrar(Usuarios usuario)
        {
            using (PontoContext ctx = new PontoContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (PontoContext ctx = new PontoContext())
            {
                Usuarios usuario = ctx.Usuarios.Find(id);
                ctx.Usuarios.Remove(usuario);
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

        public List<Usuarios> ListarUsuarios()
        {
            using (PontoContext ctx = new PontoContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public List<Usuarios> ListarPendentes()
        {
            using (PontoContext ctx = new PontoContext())
            {
                return ctx.Usuarios.Where(x => x.Ativo == false).ToList();
            }
        }

        public List<Usuarios> ListarAtivos()
        {
            using (PontoContext ctx = new PontoContext())
            {
                return ctx.Usuarios.Where(x => x.Ativo == true).ToList();
            }
        }

        //public List<Usuarios> AtivarUsuarios(int id, bool ativar)
        //{
        //    using (PontoContext ctx = new PontoContext())
        //    {
        //        Usuarios usuarioBuscado = ctx.Usuarios.FirstOrDefault(x =>
        //        x.IdUsuario == id);
        //        if (usuarioBuscado != null)
        //        {
        //            ativar = true;
        //            ctx.Usuarios.Add(usuarioBuscado);
        //            return ctx.Usuarios.ToList();
        //        }
        //        return null;
        //    }
        //}




    }
}