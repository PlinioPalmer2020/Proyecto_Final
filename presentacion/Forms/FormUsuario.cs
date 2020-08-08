using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Models;
using Dominio.ValueObjects;
using System.Data.SqlClient;

namespace presentacion.Forms
{
    public partial class FormUsuario : Form
    {
        private UsuarioModel Usuario = new UsuarioModel();
        private EmpleadoModel Empleado = new EmpleadoModel();

        public FormUsuario()
        {
            InitializeComponent();
        }


        private void cargarUsuarios()
        {
            try
            {
                ViewUsuario.DataSource = Usuario.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            cargarUsuarios();
            var exi = Empleado.validarEmpleado();
            // DataRow[] rows;

            cbEmpleados.DisplayMember = "nombre";
            cbEmpleados.ValueMember = "id_empleado";
            cbEmpleados.DataSource = exi;
            panel1.Enabled = false; 

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if ( txtPass.Text != "" && txtUsername.Text != "")
            {
                Usuario.State = EntityState.Modified;
                Usuario.username = txtUsername.Text;
                Usuario.pass = txtPass.Text;
                Usuario.empleado_id = Convert.ToInt32(cbEmpleados.SelectedValue.ToString());
               string mensaje =  Usuario.SaveChanges();
                MessageBox.Show(mensaje);
                cargarUsuarios();
                Limpiar();
                panel1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Para Editar o Modificar necesita seleccionar una fila");
            }
        }

        private void ViewUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            Usuario.id_user = Convert.ToInt32(ViewUsuario.CurrentRow.Cells[0].Value);
            txtUsername.Text = ViewUsuario.CurrentRow.Cells[1].Value.ToString();
            txtPass.Text = ViewUsuario.CurrentRow.Cells[2].Value.ToString();
            cbEmpleados.SelectedValue = ViewUsuario.CurrentRow.Cells[3].Value;
            panel1.Enabled = true;
            button1.Enabled = false;
           // button3.Enabled = false;
        }

        private void Limpiar()
        {
         //   txtEmpleado.Clear();
            txtPass.Clear();
            txtUsername.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ( txtPass.Text != "" && txtUsername.Text != "")
            {
                Usuario.State = EntityState.Deleted;
                Usuario.id_user = Convert.ToInt32(ViewUsuario.CurrentRow.Cells[0].Value);
               // Usuario.estado = 0;
                string mensaje = Usuario.SaveChanges();
                MessageBox.Show(mensaje);
                cargarUsuarios();
                Limpiar();
                panel1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Para Desactivar el usuario necesita seleccionar una fila");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( txtPass.Text != "" && txtUsername.Text != "")
            {
                var exi = Usuario.buscarUsuario();
                DataRow[] user = exi.Select("username = '" + txtUsername.Text + "'");
                if (!(user.Length != 0))
                {
                    Usuario.State = EntityState.Added;
                    Usuario.username = txtUsername.Text;
                    Usuario.pass = txtPass.Text;
                    Usuario.empleado_id = Convert.ToInt32(cbEmpleados.SelectedValue.ToString());
                    string mensaje = Usuario.SaveChanges();
                    MessageBox.Show(mensaje);
                    cargarUsuarios();
                    Limpiar();
                    panel1.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Este usuario ya existe");
                }

            }
            else
            {
                MessageBox.Show("Algunas de las campos esta vacio");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormControl formControl = new FormControl();
            formControl.Show();
            this.Hide();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            button1.Enabled = true;
            btnModificar.Enabled = false;
            button3.Enabled = false;
        }
    }
}
