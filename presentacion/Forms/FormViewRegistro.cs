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
using Dominio.Models;
using Dominio.ValueObjects;

namespace presentacion.Forms
{
    public partial class FormViewRegistro : Form
    {
        public FormViewRegistro()
        {
            InitializeComponent();
        }

        private Registro_entradaModel registro = new Registro_entradaModel();

        public void cargarRegistro()
        {
            try
            {
                ViewRegistro.DataSource = registro.GetAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormViewRegistro_Load(object sender, EventArgs e)
        {
            cargarRegistro();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormRegistro_entrada f = new FormRegistro_entrada();
            f.Show();
            this.Hide();
        }
    }
}
