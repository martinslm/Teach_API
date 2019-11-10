using System.Collections.Generic;
using Teach_API.Models;

namespace Teach_API.Services
{
    public class ClusterService
    {
        private IList<UsuariosPesquisa> _usuariosPesquisa;
        private Usuario _usuarioPrincipal;

        public ClusterService(IList<UsuariosPesquisa> usuarios, Usuario usuarioPrincipal)
        {
            _usuarioPrincipal = usuarioPrincipal;
            _usuariosPesquisa = usuarios;
        }

    }
}
