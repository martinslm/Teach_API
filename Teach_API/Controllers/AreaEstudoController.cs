using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Repositories;
using Teach_API.Results;

namespace Teach_API.Controllers
{
    [Route("api/areaestudo")]
    [ApiController]
    public class AreaEstudoController : ControllerBase
    {
        [HttpGet]
        [Route("obterareasgerais")]
        public AreaEstudoGeralResult ObterAreasGerais()
        {
            var result = new AreaEstudoGeralResult();

            var repository = new AreaEstudoRepository();

            result.AreasEstudo = repository.ObterAreaEstudoGeral();

            if (!result.AreasEstudo.Any())
                result.Mensagem.Add("Houve um erro realizar a busca das áreas de estudo.");

            return result;
        }
    }
}
