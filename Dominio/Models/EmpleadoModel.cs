using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;
using DataAccess.Entities;
using DataAccess.Repositories;
using Dominio.ValueObjects;
using System.Data;

namespace Dominio.Models
{
    public class EmpleadoModel
    {

        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public int estado { get; set; }

        private IempleadoRepository empleadoRepository;
        public EntityState State { private get; set; }

        private List<EmpleadoModel> listEmpleados;

        public EmpleadoModel()
        {
            empleadoRepository = new EmpleadoRepository();
        }

        public string SaveChanges()
        {
            string message = "aqui no hay nada XD";
            try
            {
                var empleadoDataModel = new empleado();
                empleadoDataModel.id_empleado = id_empleado;
                empleadoDataModel.nombre = nombre;
                empleadoDataModel.apellido = apellido;
                empleadoDataModel.cedula = cedula;
                empleadoDataModel.estado = estado;

                switch (State)
                {
                    case EntityState.Added:
                        empleadoRepository.Add(empleadoDataModel);
                        message = "Ha sido Registrado";
                        break;

                    case EntityState.Modified:
                        empleadoRepository.Adit(empleadoDataModel);
                        message = "Ha sido Modificado";
                        break;

                    case EntityState.Deleted:
                        empleadoRepository.Remove(id_empleado);
                        message = "El usuario ha sido invalidado";
                        break;
                }

            }
            catch (Exception ex)
            {
                System.Data.SqlClient.SqlException sqlEx = ex as System.Data.SqlClient.SqlException;
                if (sqlEx != null && sqlEx.Number == 2627)
                {
                    message = "El usuario ya existe";
                }
                else
                {
                    message = ex.ToString();
                }
            }

            return message;
        }

        public List<EmpleadoModel> GetAll()
        {
            var empleadoDataModel = empleadoRepository.GetALL();
            listEmpleados = new List<EmpleadoModel>();
            foreach (empleado item in empleadoDataModel)
            {
                listEmpleados.Add(new EmpleadoModel
                {
                    id_empleado = item.id_empleado,
                    nombre = item.nombre,
                    apellido = item.apellido,
                    cedula = item.cedula,
                    estado = item.estado
                });
            }

            return listEmpleados;
        }

        public DataTable validarEmpleado()
        {
            return empleadoRepository.Encontrar();
        }

        public IEnumerable<EmpleadoModel> filtro(string filtrar)
        {
            return GetAll().FindAll(e => e.nombre.Contains( filtrar));
        }

    }// no pasar de aqui
}
