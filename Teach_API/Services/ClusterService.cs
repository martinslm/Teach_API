using Microsoft.ML;
using System;
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

        public IList<UsuariosPesquisa> RealizarPesquisaAvancada()
        {
            var mlcontext = new MLContext();

            var dadosUsuariosPesquisaConvert = ConverterDados();

            var teste = mlcontext.Data.LoadFromEnumerable<ClusterObjects>(dadosUsuariosPesquisaConvert);
            throw new NotImplementedException();
        }

        private IEnumerable<ClusterObjects> ConverterDados()
        {
            var dados = new List<ClusterObjects>();
            foreach(var usuario in _usuariosPesquisa)
            {
                var cluster = new ClusterObjects()
                {
                    Id = usuario.Id,
                    Genero = usuario.Genero,
                    DataNascimento = usuario.DataNascimento,
                    IdIdiomaOrigem = usuario.IdiomaOrigem.Id,
                    IdIdiomaParaAprender =usuario.IdiomaParaAprender.Id,
                    IdIdiomaFluenteSecundario = usuario.IdiomaFluenteSecundario.Id,
                    IdAreaEstudoDominioGeral = usuario.AreaEstudoDominioGeral.Id,
                    IdAreaEstudoDominioEspecifica = usuario.AreaEstudoDominioEspecifica.Id,
                    IdAreaEstudoParaAprenderGeral = usuario.AreaEstudoParaAprenderGeral.Id,
                    IdAreaEstudoParaAprenderEspecifico = usuario.AreaEstudoParaAprenderEspecifico.Id,
                    TipoIteracao = usuario.TipoIteracao
                };
            }

            return dados;
        }
    }
}
