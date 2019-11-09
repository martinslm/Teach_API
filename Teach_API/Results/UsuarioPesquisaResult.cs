using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Models;

namespace Teach_API.Results
{
    public class UsuarioPesquisaResult : ResultBase
    {
        public IList<UsuariosPesquisa> usuariosRecomendados { get; set; }

        public UsuarioPesquisaResult()
        {
            usuariosRecomendados = new List<UsuariosPesquisa>();
        }
    }
}
