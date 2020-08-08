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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private UsuarioModel Usuario = new UsuarioModel();


        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtPass.Text != "")
            {
                var exi = Usuario.buscarUsuario();
                DataRow[] user = exi.Select("username = '" + txtUsuario.Text + "'");
                DataRow[] pass = exi.Select("pass = '" + txtPass.Text + "'");

                if (user.Length != 0 && pass.Length !=0) {

                    FormControl formControl = new FormControl();
                    formControl.Show();

                    this.Hide();


                }
                else
                {
                    MessageBox.Show("El Usuario O Contraseña son incorrecta");
                }

            }
            else
            {
                MessageBox.Show("Los campos estan vacios");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
