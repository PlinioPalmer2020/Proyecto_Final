using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class registro_entrada
    {
        public int id_registro { get; set; }
        public int empleado_id { get; set; }
        public DateTime fecha_entrada  { get; set; }
        public DateTime fecha_salida { get; set; }

    }
}
