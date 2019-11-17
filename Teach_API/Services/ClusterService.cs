using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using Teach_API.Models;

namespace Teach_API.Services
{
    public class prediction
    {
            public int Label;
            public float Score;
    }
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
            var objetoBusca = InverterPreferenciasParaPesquisa();
            var populacaoTreino = mlcontext.Data.LoadFromEnumerable<ClusterObjects>(dadosUsuariosPesquisaConvert);
            var teste = mlcontext.Data.LoadFromEnumerable<ClusterObjects>(dadosUsuariosPesquisaConvert);

            IEstimator<ITransformer> estimator = mlcontext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: "userId")
        .Append(mlcontext.Transforms.Conversion.MapValueToKey(outputColumnName: "nameIdEncoded", inputColumnName: "nameId"));

            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "userIdEncoded",
                MatrixRowIndexColumnName = "nameIdEncoded",
                LabelColumnName = "Label",
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var trainerEstimator = estimator.Append(mlcontext.Recommendation().Trainers.MatrixFactorization(options));

            ITransformer model = trainerEstimator.Fit(populacaoTreino);

            var prediction = model.Transform(teste);

            var metrics = mlcontext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName: "Score");

            var predictionEngine = mlcontext.Model.CreatePredictionEngine<ClusterObjects, prediction>(model);

            var testInput = InverterPreferenciasParaPesquisa();

            var movieRatingPrediction = predictionEngine.Predict(testInput);

           // var top5 = (from m in 
             //           let p = predictionEngine.Predict(testInput)
              //          orderby p.Score descending
                //        select (MovieId: m.ID, Score: p.Score)).Take(5);

            return new List<UsuariosPesquisa>();
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

            dados.Add(InverterPreferenciasParaPesquisa());
            return dados;
        }

        private ClusterObjects InverterPreferenciasParaPesquisa()
        {
            return new ClusterObjects()
            {
                Id = _usuarioPrincipal.Id,
                Genero = _usuarioPrincipal.Genero,
                DataNascimento = _usuarioPrincipal.DataNascimento,
                IdIdiomaOrigem = _usuarioPrincipal.IdiomaParaAprender.Id,
                IdIdiomaParaAprender = _usuarioPrincipal.IdiomaOrigem.Id,
                IdIdiomaFluenteSecundario = _usuarioPrincipal.IdiomaFluenteSecundario.Id,
                IdAreaEstudoDominioGeral = _usuarioPrincipal.AreaEstudoParaAprenderGeral.Id,
                IdAreaEstudoDominioEspecifica = _usuarioPrincipal.AreaEstudoParaAprenderEspecifico.Id,
                IdAreaEstudoParaAprenderGeral = _usuarioPrincipal.AreaEstudoDominioGeral.Id,
                IdAreaEstudoParaAprenderEspecifico = _usuarioPrincipal.AreaEstudoDominioEspecifica.Id,
                TipoIteracao = _usuarioPrincipal.TipoIteracao
            };
        }
    }
}
