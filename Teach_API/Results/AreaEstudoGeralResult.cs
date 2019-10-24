using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Models;

namespace Teach_API.Results
{
    public class AreaEstudoGeralResult : ResultBase
    {
        public IList<AreaEstudo> AreasEstudo { get; set; }

        public AreaEstudoGeralResult()
        {
            AreasEstudo = new List<AreaEstudo>();
        }
    }
}
