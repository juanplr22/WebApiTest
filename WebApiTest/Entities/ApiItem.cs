using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Entities.Attributes;

namespace WebApiTest.Entities
{
    public class ApiItem
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int identificacion { get; set; }
        public int edad { get; set; }
        public ApiCasaEstudio casaestudio { get; set; }

    }
}
