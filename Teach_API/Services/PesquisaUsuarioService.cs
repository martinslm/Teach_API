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
            try
            {
                var repository = new PesquisaRepository();

                var usuarios = repository.ObterUsuariosCombinacao(usuario);

                //return new ClusterService(usuarios, usuario).RealizarPesquisaAvancada();

                return RefinarPesquisa(usuarios, usuario);
            }
            catch(Exception ex)
            {
                var teste = ex;
                return new List<UsuariosPesquisa>();
            }
        }

        private IList<UsuariosPesquisa> RefinarPesquisa(IList<UsuariosPesquisa> listaOriginal, Usuario usuarioLogado)
        {
            if (listaOriginal.Count() <= 10)
                return listaOriginal;

            var listaRefinada = new List<UsuariosPesquisa>();

            listaRefinada = (List<UsuariosPesquisa>)listaOriginal
                                .Where(u => u.AreaEstudoDominioEspecifica == usuarioLogado.AreaEstudoParaAprenderEspecifico);

            if (listaRefinada.Count() < 10)
                return listaOriginal;

            listaOriginal = listaRefinada;

            listaRefinada = (List<UsuariosPesquisa>)listaOriginal
                            .Where(u => u.AreaEstudoParaAprenderGeral == usuarioLogado.AreaEstudoDominioGeral);

            if (listaRefinada.Count() < 10)
                return listaOriginal;

            listaOriginal = listaRefinada;

            listaRefinada = (List<UsuariosPesquisa>)listaOriginal
                            .Where(u => u.AreaEstudoParaAprenderEspecifico == usuarioLogado.AreaEstudoDominioEspecifica);

            if (listaRefinada.Count() < 10)
                return listaOriginal;

            return listaRefinada;
        }
    }
}
