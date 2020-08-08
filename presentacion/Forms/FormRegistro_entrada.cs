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

namespace presentacion.Forms
{
    public partial class FormRegistro_entrada : Form
    {
        public FormRegistro_entrada()
        {
            InitializeComponent();
        }

        private EmpleadoModel Empleado = new EmpleadoModel();
        private Registro_entradaModel registro = new Registro_entradaModel();




        public void cargarUsuarios()
        {
            try
            {
                ViewEmpleados.DataSource = Empleado.GetAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void FormRegistro_entrada_Load(object sender, EventArgs e)
        {
            cargarUsuarios();
            txtEmpleado.Enabled = false;
            btnRegistrarEntrada.Enabled = false;
            btnRegistrarSalida.Enabled = false;
        }

        private void ViewEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            registro.empleado_id = Convert.ToInt32(ViewEmpleados.CurrentRow.Cells[0].Value);
            txtEmpleado.Text = ViewEmpleados.CurrentRow.Cells[1].Value.ToString() + " " + ViewEmpleados.CurrentRow.Cells[2].Value.ToString();

            var Datos = registro.validarEntrada(); // buscar a todos registros de entrada
            var ultimaFecha = registro.ultimoRegistro();// buscar la ultima fecha introducida

            /*
             *
             * Validar si hay registro en la base de datos
             *
             */

            if (ultimaFecha.Rows.Count != 0)
            {
                /*
                 *
                 * Validar si hay registro en la base de datos
                 *
                 */
                if (Datos.Rows.Count != 0)
                {
                    DataRow data = ultimaFecha.Rows[0]; // Guarda la ultima fecha introducida
 
                    string fecha = data["fecha_entrada"].ToString(); // toma esa fecha y la convierte a una string

                    var f = Convert.ToDateTime(fecha).ToString("yyyy-MM-dd"); // le cambia el formato a solo fecha 

                    DataRow[] datosEmpleados = Datos.Select("empleado_id = '" + registro.empleado_id + "'");// buscar las fechas y horas del empleados y guardar todas las fechas
                                                                                                            //

                    /*
                     *validar si hay registro de ese empleado 
                     */
                    if (datosEmpleados.Length != 0)
                    {

                        DataRow a = datosEmpleados[datosEmpleados.Length - 1]; // guardar la ultima fecha que hay de ese empleado
                        //DataRow aa = datosEmpleados[datosEmpleados.Length - 1];

                        string fff = a["fecha_salida"].ToString(); // guarda la fecha de salida

                        string ff = a["fecha_entrada"].ToString(); // guarda la ultima fecha de empleado como string

                        ff = Convert.ToDateTime(ff).ToString("yyyy-MM-dd");// lo convierte a solo fecha

                        /*
                         * validacion si la ultima fecha insertada es igual la fecha de entrar del empleado
                         * y su fecha de salida no ha sido ensertado 
                         * el empleado ya entro al trabajo
                         * 
                         * de lo contrario si su fecha de salida es diferente a null o vacio
                         * pues el empleado de acabo de trabajar
                         * 
                         * de lo contrario el empleado no a empezado a trabajar
                         */
                        if (f == ff && fff == "" )
                        {
                            MessageBox.Show("Este Empleado empezado su horario laborar");
                            btnRegistrarSalida.Enabled = true;
                        }
                        else if (fff != "")
                        {
                            MessageBox.Show("Este Empleado acabo con su horario laborar");
                        }
                        else
                        {
                            btnRegistrarEntrada.Enabled = true;
                        }
                    }
                    else
                    {
                        btnRegistrarEntrada.Enabled = true;
                    }


                }

            }
            else
            {
                btnRegistrarEntrada.Enabled = true;
            }


          //  MessageBox.Show(ff.ToString());

        }

        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            if (txtEmpleado.Text != "" )
            {
                DateTime dateTime = DateTime.Now;

              //  MessageBox.Show(dateTime.ToString("yyyMMdd HH:mm:ss"));
                registro.State = EntityState.Added;
                //registro.empleado_id = txtNombre.Text;
                registro.fecha_entrada = dateTime;
                //registro.cedula = txtCedula.Text;
                string mensaje = registro.SaveChanges();
                MessageBox.Show(mensaje);
                cargarUsuarios();
                txtEmpleado.Clear();
                //Limpiar();
                btnRegistrarEntrada.Enabled = false;
            }
            else
            {
                MessageBox.Show("No a Seleccionado a un empleado");
            }
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (txtEmpleado.Text != "")
            {
                DateTime dateTime = DateTime.Now;
               // MessageBox.Show(dateTime.ToString());
                registro.State = EntityState.Modified;
                //registro.empleado_id = txtNombre.Text;
                registro.fecha_salida = dateTime;
                //registro.cedula = txtCedula.Text;
                string mensaje = registro.SaveChanges();
                MessageBox.Show(mensaje);
                cargarUsuarios();
                txtEmpleado.Clear();
                //Limpiar();
                btnRegistrarSalida.Enabled = false;
                
            }
            else
            {
                MessageBox.Show("No a Seleccionado a un empleado");
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormControl formControl = new FormControl();
            formControl.Show();
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                ViewEmpleados.DataSource = Empleado.filtro(txtBuscar.Text);

            }
            else
            {
                cargarUsuarios();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            FormViewRegistro formControl = new FormViewRegistro();
            formControl.Show();
            this.Hide();
        }
    }
}
