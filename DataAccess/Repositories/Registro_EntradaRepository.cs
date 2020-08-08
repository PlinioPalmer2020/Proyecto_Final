using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;
using DataAccess.Entities;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class Registro_EntradaRepository : MasterRepository, Iregistro_entredaRepository
    {
        private string selectAll;
        private string insert;
        private string update;
       // private string delete;
        private string buscar;

        /*
         * id_registro int identity(1,1) primary key,
            empleado_id int not null,
            fecha_entrada  date not null,
            fecha_salida  date
         */

        public Registro_EntradaRepository()
        {
            selectAll = "SELECT *  FROM  registro_entradas";
            insert = "INSERT INTO registro_entradas(empleado_id,fecha_entrada) VALUES(@empleado_id,@fecha_entrada)";
            update = "UPDATE registro_entradas SET fecha_salida=@fecha_salida WHERE empleado_id=@empleado_id ";
            //delete = "UPDATE registro_entradas SET estado=0 WHERE id_user = @id_user";
            buscar = "select fecha_entrada from registro_entradas where id_registro = (select MAX(id_registro) from registro_entradas)";
        }

        public int Add(registro_entrada entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@empleado_id", entity.empleado_id));
            parameters.Add(new SqlParameter("@fecha_entrada", entity.fecha_entrada));
           // parameters.Add(new SqlParameter("@empleado_id", entity.empleado_id));
            return ExecuteNonQuery(insert);

        }

        public int Adit(registro_entrada entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@empleado_id", entity.empleado_id));
           // parameters.Add(new SqlParameter("@username", entity.username));
           // parameters.Add(new SqlParameter("@pass", entity.pass));
            parameters.Add(new SqlParameter("@fecha_salida", entity.fecha_salida));
            return ExecuteNonQuery(update);

        }

        public DataTable Encontrar()
        {
            var tableResult = ExecuteReader(buscar);
            return tableResult;
        }

        public IEnumerable<registro_entrada> GetALL()
        {
            var tableResult = ExecuteReader(selectAll);
            var listregistro_entrada = new List<registro_entrada>();
            foreach (DataRow item in tableResult.Rows)
            {
                listregistro_entrada.Add(new registro_entrada
                {
                    id_registro = Convert.ToInt32(item[0]),
                    empleado_id = Convert.ToInt32(item[1]),
                    fecha_entrada = Convert.ToDateTime(item[2]),
                    fecha_salida = Convert.ToDateTime(item[3]),
                  //  estado = Convert.ToInt32(item[4])
                });
            }
            return listregistro_entrada;
        }

        public int Remove(int id_registro)
        {
            /*
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id_registro", id_registro));
            return ExecuteNonQuery(delete);
            */
            return 0;
        }

        public DataTable todoLosRegistros()
        {
            var tableResult = ExecuteReader(selectAll);
            return tableResult;
        }
    }
}
