using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Contracts;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class EmpleadoRepository : MasterRepository, IempleadoRepository
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public EmpleadoRepository()
        {
            selectAll = "SELECT *  FROM  empleados WHERE estado = 1";
            insert = "INSERT INTO empleados(nombre,apellido,cedula) VALUES(@nombre,@apellido,@cedula)";
            update = "UPDATE empleados SET nombre=@nombre, apellido=@apellido,cedula=@cedula WHERE id_empleado=@id_empleado ";
            delete = "UPDATE empleados SET estado=0 WHERE id_empleado = @id_empleado";
        }

        public int Add(empleado entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nombre", entity.nombre));
            parameters.Add(new SqlParameter("@apellido", entity.apellido));
            parameters.Add(new SqlParameter("@cedula", entity.cedula));
            return ExecuteNonQuery(insert);

        }

        public int Adit(empleado entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id_empleado", entity.id_empleado));
            parameters.Add(new SqlParameter("@nombre", entity.nombre));
            parameters.Add(new SqlParameter("@apellido", entity.apellido));
            parameters.Add(new SqlParameter("@cedula", entity.cedula));
            return ExecuteNonQuery(update);

        }

        public DataTable Encontrar()
        {
            var tableResult = ExecuteReader(selectAll);
            return tableResult;
        }

        public IEnumerable<empleado> GetALL()
        {
            var tableResult = ExecuteReader(selectAll);
            var listusuario = new List<empleado>();
            foreach (DataRow item in tableResult.Rows)
            {
                listusuario.Add(new empleado
                {
                    id_empleado = Convert.ToInt32(item[0]),
                    nombre = item[1].ToString(),
                    apellido = item[2].ToString(),
                    cedula = item[3].ToString(),
                    estado = Convert.ToInt32(item[4])
                });
            }
            return listusuario;
        }

        public int Remove(int id_empleado)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id_empleado", id_empleado));
            return ExecuteNonQuery(delete);

        }
    }
}
