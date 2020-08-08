using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using presentacion.Forms;

namespace presentacion.Forms
{
    public partial class FormControl : Form
    {
        public FormControl()
        {
            InitializeComponent();
        }

        private void btnNuevoUsuarios_Click(object sender, EventArgs e)
        {
            FormUsuario formUsuario = new FormUsuario();

            formUsuario.Show();

            this.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();

            this.Hide();
        }

        private void btnNuevoEmpleados_Click(object sender, EventArgs e)
        {
            FormEmpleado formEmpleado = new FormEmpleado();
            formEmpleado.Show();

            this.Hide();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            FormRegistro_entrada formRegistro_Entrada = new FormRegistro_entrada();
            formRegistro_Entrada.Show();

            this.Hide();
        }
    }
}
