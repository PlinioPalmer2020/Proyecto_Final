using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
     public class empleado
    {
        /*
         * id_empleado int identity(1,1) primary key,
nombre nvarchar(50) not null,
apellido nvarchar(50) not null,
cedula nvarchar(50) not null,
estado bit default 1
         * 
         */

        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public int estado { get; set; }

    }
}
