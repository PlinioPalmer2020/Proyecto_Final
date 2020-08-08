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
    public class UsuarioRepository : MasterRepository, Iusuario
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;
        private string buscar;

        public UsuarioRepository()
        {
            selectAll = "SELECT *  FROM  usuario WHERE estado = 1";
            insert = "INSERT INTO usuario(username,pass,empleado_id) VALUES(@username,@pass,@empleado_id)";
            update = "UPDATE usuario SET username=@username, pass=@pass,empleado_id=@empleado_id WHERE id_user=@id_user ";
            delete = "UPDATE usuario SET estado=0 WHERE id_user = @id_user";
            buscar = "SELECT *  FROM  usuario WHERE estado = 1";
        }

        public int Add(usuario entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@username", entity.username));
            parameters.Add(new SqlParameter("@pass", entity.pass));
            parameters.Add(new SqlParameter("@empleado_id", entity.empleado_id));
            return ExecuteNonQuery(insert);

        }

        public int Adit(usuario entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id_user", entity.id_user));
            parameters.Add(new SqlParameter("@username", entity.username));
            parameters.Add(new SqlParameter("@pass", entity.pass));
            parameters.Add(new SqlParameter("@empleado_id", entity.empleado_id));
            return ExecuteNonQuery(update);

        }

        public DataTable Encontrar()
        {
           // parameters = new List<SqlParameter>();
          //  parameters.Add(new SqlParameter("@username", username));
          //  parameters.Add(new SqlParameter("@pass", pass));
            var tableResult = ExecuteReader(buscar);

         
                return tableResult;
           

  
        }



        public IEnumerable<usuario> GetALL()
        {
            var tableResult = ExecuteReader(selectAll);
            var listusuario = new List<usuario>();
            foreach (DataRow item in tableResult.Rows)
            {
                listusuario.Add(new usuario {
                    id_user = Convert.ToInt32(item[0]),
                    username = item[1].ToString(),
                    pass = item[2].ToString(),
                    empleado_id = Convert.ToInt32(item[3]),
                    estado = Convert.ToInt32(item[4])
                });
            }
            return listusuario;
        }

        public int Remove(int id_user)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id_user", id_user));
            return ExecuteNonQuery(delete);

        }
    }
}
