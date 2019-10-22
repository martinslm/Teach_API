using Microsoft.AspNetCore.Mvc;
using Teach_API.Models;
using Teach_API.Repositories;
using Teach_API.Repositories.Interfaces;
using Teach_API.Results;

namespace Teach_API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //private readonly IUsuarioRepository _usuarioRepository;
        ////TODO: ADICIONAR INJEÇÃO DE DEPENDENCIA
        //public UsuarioController(IUsuarioRepository usuarioRepository)
        //{
        //    _usuarioRepository = usuarioRepository;
        //}
        //[RequireHttps]
        [HttpGet]
        [Route("fazerlogin")]
        public LoginResult FazerLogin([FromBody]LoginModel loginModel)
        {
            var result = new LoginResult();

            if (!result.ValidarModel(loginModel))
                return result;

            var repository = new UsuarioRepository();

            result.IdUsuario = repository.ValidarLogin(loginModel);

            if (result.IdUsuario == 0)
                result.Mensagem.Add("Não foi possível localizar o usuário informado. Verifique as credenciais de acesso");

            return result;
        }

        [HttpPost]
        [Route("cadastrar")]
        public CadastrarUsuarioResult CadastrarUsuario([FromBody]UsuarioModel dadosUsuario)
        {
            var result = new CadastrarUsuarioResult();

            if (!result.ValidarModel(dadosUsuario))
                return result;

            //validar usuario no repository.

            //esta função não precisa retornar o id do usuario, apenas verificar se o usuário foi cadastrado com sucesso ou não. 

            // se usuario for 0 add uma mensagem de erro, retorna o usuario 0. Sucesso = false.

            //se usuario for diferente de 0, retorna sucess = true e nenhuma mensagem de erro e o ID do usuario. 

            return result;
        }
    }
}
