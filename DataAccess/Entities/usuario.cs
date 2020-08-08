using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class usuario
    {

        public int id_user { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public int empleado_id { get; set; }
        public int estado { get; set; }




    }
}
