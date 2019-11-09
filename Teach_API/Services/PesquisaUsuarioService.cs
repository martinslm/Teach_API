using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Models;
using Teach_API.Repositories;

namespace Teach_API.Services
{
    public class PesquisaUsuarioService
    {
        public IList<UsuariosPesquisa> ObterRecomendacoesUsuarios(Usuario usuario)
        {

            var repository = new PesquisaRepository();

            var usuarios = repository.ObterUsuariosCombinacao(usuario);

            return new List<UsuariosPesquisa>();

        }
    }
}
