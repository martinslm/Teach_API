using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Enums;

namespace Teach_API.Models
{
    public class ClusterObjects
    {
        [LoadColumn(0)] public long Id { get; set; }
        [LoadColumn(1)] public Genero Genero { get; set; }
        [LoadColumn(2)] public DateTime DataNascimento { get; set; }
        [LoadColumn(3)] public long IdIdiomaOrigem { get; set; }
        [LoadColumn(4)] public long IdIdiomaParaAprender { get; set; }
        [LoadColumn(5)] public long IdIdiomaFluenteSecundario { get; set; }
        [LoadColumn(6)] public long IdAreaEstudoDominioGeral { get; set; }
        [LoadColumn(7)] public long IdAreaEstudoDominioEspecifica { get; set; }
        [LoadColumn(8)] public long IdAreaEstudoParaAprenderGeral { get; set; }
        [LoadColumn(9)] public long IdAreaEstudoParaAprenderEspecifico { get; set; }
        [LoadColumn(10)] public TipoIteracao TipoIteracao { get; set; }
    }
}
