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
using presentacion.Forms;

namespace presentacion.Forms
{
    public partial class FormEmpleado : Form
    {
        private EmpleadoModel Empleado = new EmpleadoModel();
        public FormEmpleado()
        {
            InitializeComponent();

        }

        private void cargarUsuarios()
        {
            try
            {
                ViewEmpleados.DataSource = Empleado.GetAll();
                panel1.Enabled = false;
                btnModificar.Enabled = false;
                btnDesactivar.Enabled = false;
                btnNuevo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormEmpleado_Load(object sender, EventArgs e)
        {
            cargarUsuarios();

        }

        private void ViewEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Empleado.id_empleado = Convert.ToInt32(ViewEmpleados.CurrentRow.Cells[0].Value);
            txtNombre.Text = ViewEmpleados.CurrentRow.Cells[1].Value.ToString();
            txtApellido.Text = ViewEmpleados.CurrentRow.Cells[2].Value.ToString();
            txtCedula.Text = ViewEmpleados.CurrentRow.Cells[3].Value.ToString();
            btnModificar.Enabled = true;
            btnDesactivar.Enabled = true;
            panel1.Enabled = true;
            btnNuevo.Enabled = false;
            btncrear.Enabled = false;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "" && txtNombre.Text != "" && txtApellido.Text != "")
            {
                Empleado.State = EntityState.Deleted;
                Empleado.id_empleado = Convert.ToInt32(ViewEmpleados.CurrentRow.Cells[0].Value);
                // Usuario.estado = 0;
                string mensaje = Empleado.SaveChanges();
                MessageBox.Show(mensaje);
                cargarUsuarios();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Para Desactivar el usuario necesita seleccionar una fila");
            }
        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "" && txtNombre.Text != "" && txtApellido.Text != "")
            {
                var exi = Empleado.validarEmpleado();
                DataRow[] cedula = exi.Select("cedula = '" + txtCedula.Text + "'");

              //  MessageBox.Show(cedula.Length.ToString());

                if (!(cedula.Length != 0))
                {
                Empleado.State = EntityState.Added;
                Empleado.nombre = txtNombre.Text;
                Empleado.apellido = txtApellido.Text;
                Empleado.cedula = txtCedula.Text;
                string mensaje = Empleado.SaveChanges();
                MessageBox.Show(mensaje);
                cargarUsuarios();
                Limpiar();

                }
                else
                {
                    MessageBox.Show("Este Empleado ya existe en el sistema");
                }
            }
            else
            {
                MessageBox.Show("Algunas de las campos esta vacio");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnDesactivar.Enabled = false;
            btncrear.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "" && txtNombre.Text != "" && txtApellido.Text != "")
            {
                Empleado.State = EntityState.Modified;
                Empleado.nombre = txtNombre.Text;
                Empleado.apellido = txtApellido.Text;
                Empleado.cedula = txtCedula.Text;
                string mensaje = Empleado.SaveChanges();
                MessageBox.Show(mensaje);
                cargarUsuarios();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Para Editar o Modificar necesita seleccionar una fila");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormControl formControl = new FormControl();
            formControl.Show();
            this.Hide();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Numeros","Alerta", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }


    }
}
