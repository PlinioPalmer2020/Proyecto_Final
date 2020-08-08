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
    public  class Registro_entradaModel
    {
        public int id_registro { get; set; }
        public int empleado_id { get; set; }
        public DateTime fecha_entrada { get; set; }
        public DateTime fecha_salida { get; set; }

        private Iregistro_entredaRepository registroRepository;
        public EntityState State { private get; set; }

        private List<Registro_entradaModel> listRegistro;

        public Registro_entradaModel()
        {
            registroRepository = new Registro_EntradaRepository();
        }

        public string SaveChanges()
        {
            string message = "aqui no hay nada XD";
            try
            {
                var registroDataModel = new registro_entrada();
                registroDataModel.id_registro = id_registro;
                registroDataModel.empleado_id = empleado_id;
                registroDataModel.fecha_entrada = fecha_entrada;
                registroDataModel.fecha_salida = fecha_salida;
                //registroDataModel.estado = estado;

                switch (State)
                {
                    case EntityState.Added:
                        registroRepository.Add(registroDataModel);
                        message = "Ha sido Registrado la Entrada del Empleado";
                        break;

                    case EntityState.Modified:
                        registroRepository.Adit(registroDataModel);
                        message = "Ha sido Registrado la Salida del Empleado";
                        break;

                    /*case EntityState.Deleted:
                        registroRepository.Remove(id);
                        message = "El usuario ha sido invalidado";
                        break;*/
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

        public List<Registro_entradaModel> GetAll()
        {
            var registroDataModel = registroRepository.GetALL();
            listRegistro = new List<Registro_entradaModel>();
            foreach (registro_entrada item in registroDataModel)
            {
                listRegistro.Add(new Registro_entradaModel
                {
                    id_registro = item.id_registro,
                    empleado_id = item.empleado_id,
                    fecha_entrada = item.fecha_entrada,
                    fecha_salida = item.fecha_salida,
                    //estado = item.estado
                });
            }

            return listRegistro;
        }

        public DataTable ultimoRegistro()
        {
            return registroRepository.Encontrar();
        }

        public DataTable validarEntrada()
        {
            return registroRepository.todoLosRegistros();
        }

    }// no pasa de aqui
}
