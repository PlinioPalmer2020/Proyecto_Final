using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;
using DataAccess.Entities;
using DataAccess.Repositories;
using Dominio.ValueObjects;
using System.Data.SqlClient;
using System.Data;

namespace Dominio.Models
{
    public  class UsuarioModel
    {

        public int id_user { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public int empleado_id { get; set; }
        public int estado { get; set; }

        private Iusuario usuarioRepository;
        public EntityState State { private get; set; }

        private List<UsuarioModel> listUsuarios ;

        public UsuarioModel()
        {
            usuarioRepository = new UsuarioRepository();
        }

        public string SaveChanges()
        {
            string message = "aqui no hay nada XD";
            try
            {
                var usuarioDataModel = new usuario();
                usuarioDataModel.id_user = id_user;
                usuarioDataModel.username = username;
                usuarioDataModel.pass = pass;
                usuarioDataModel.empleado_id = empleado_id;
                usuarioDataModel.estado = estado;

                switch (State)
                {
                    case EntityState.Added:
                        usuarioRepository.Add(usuarioDataModel);
                        message = "Ha sido Registrado";
                        break;

                    case EntityState.Modified:
                        usuarioRepository.Adit(usuarioDataModel);
                        message = "Ha sido Modificado";
                        break;

                    case EntityState.Deleted:
                        usuarioRepository.Remove(id_user);
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

        public List<UsuarioModel> GetAll()
        {
            var usuarioDataModel = usuarioRepository.GetALL();
            listUsuarios = new List<UsuarioModel>();
            foreach (usuario item in usuarioDataModel)
            {
                listUsuarios.Add(new UsuarioModel {
                    id_user = item.id_user,
                    username = item.username,
                    pass = item.pass,
                    empleado_id = item.empleado_id,
                    estado = item.estado
                });
            }

            return listUsuarios;
        }

        public DataTable buscarUsuario()
        {
            return usuarioRepository.Encontrar();
        }

    }// de aqui no pasa

}
