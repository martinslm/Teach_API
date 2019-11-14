using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Teach_API.Models;
using Teach_API.Repositories;
using Teach_API.Results;
using Teach_API.Services;

namespace Teach_API.Controllers
{
    [Route("api/pesquisa")]
    [ApiController]
    public class PesquisaController : ControllerBase
    {
        [HttpGet]
        [Route("buscarRecomendacaoUsuarios")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public UsuarioPesquisaResult BuscarRecomendacoesUsuarios([FromHeader]int idUsuario)
        {
            var result = new UsuarioPesquisaResult();

            if (!result.ValidarModel(idUsuario))
                return result;

            var repository = new UsuarioRepository();

            var usuario = repository.ObterDadosUsuario(idUsuario);

            if(usuario == new Usuario())
            {
                result.Mensagem.Add("Não foi possível localizar o usuário pelo ID informado.");
                return result;
            }

            result.usuariosRecomendados = new PesquisaUsuarioService().ObterRecomendacoesUsuarios(usuario);

            if (!result.usuariosRecomendados.Any())
                result.Mensagem.Add("Não foi encontrado nenhuma recomendação para o usuário informado.");

            return result;
        }
    }
}
