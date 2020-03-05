using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.MeuPonto.WebApi.Domains;
using Senai.MeuPonto.WebApi.Interfaces;
using Senai.MeuPonto.WebApi.Repositorios;


namespace Senai.MeuPonto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/Json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        List<Usuarios> usuarios = new List<Usuarios>();

        private IUsuariosRepositorio usuarioRepositorio { get; set; }

        public UsuariosController()
        {
            usuarioRepositorio = new UsuariosRepositorio();
        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            return Ok(usuarioRepositorio.ListarUsuarios());
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuarios)
        {
            try
            {
                usuarioRepositorio.Cadastrar(usuarios);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                usuarioRepositorio.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("{ativar/id}")]
        //public IActionResult AtivarUsuarios(int id, bool ativar)
        //{
        //    try
        //    {
        //        return Ok(usuarioRepositorio.AtivarUsuarios(id, ativar));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { mensagem = "Nao foi poossivel ativar o usuario" + ex.Message });
        //    }
        //}

        [HttpGet("Pendentes")]
        public IActionResult ListarPendentes()
        {
            return Ok(usuarioRepositorio.ListarPendentes());
        }

        [HttpGet("Ativos")]
        public IActionResult ListarAtivos()
        {
            return Ok(usuarioRepositorio.ListarAtivos());
        }


    }
}