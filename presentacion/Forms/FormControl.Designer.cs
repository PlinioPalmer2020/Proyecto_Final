namespace presentacion.Forms
{
    partial class FormControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNuevoUsuarios = new System.Windows.Forms.Button();
            this.btnNuevoEmpleados = new System.Windows.Forms.Button();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNuevoUsuarios
            // 
            this.btnNuevoUsuarios.Location = new System.Drawing.Point(82, 146);
            this.btnNuevoUsuarios.Name = "btnNuevoUsuarios";
            this.btnNuevoUsuarios.Size = new System.Drawing.Size(157, 91);
            this.btnNuevoUsuarios.TabIndex = 0;
            this.btnNuevoUsuarios.Text = "Manejador de Usuarios";
            this.btnNuevoUsuarios.UseVisualStyleBackColor = true;
            this.btnNuevoUsuarios.Click += new System.EventHandler(this.btnNuevoUsuarios_Click);
            // 
            // btnNuevoEmpleados
            // 
            this.btnNuevoEmpleados.Location = new System.Drawing.Point(297, 146);
            this.btnNuevoEmpleados.Name = "btnNuevoEmpleados";
            this.btnNuevoEmpleados.Size = new System.Drawing.Size(167, 91);
            this.btnNuevoEmpleados.TabIndex = 1;
            this.btnNuevoEmpleados.Text = "Manejador de  Empleados";
            this.btnNuevoEmpleados.UseVisualStyleBackColor = true;
            this.btnNuevoEmpleados.Click += new System.EventHandler(this.btnNuevoEmpleados_Click);
            // 
            // btnRegistro
            // 
            this.btnRegistro.Location = new System.Drawing.Point(527, 146);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(136, 91);
            this.btnRegistro.TabIndex = 2;
            this.btnRegistro.Text = "Manejador de Registro Entrada Y Salida";
            this.btnRegistro.UseVisualStyleBackColor = true;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(621, 28);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(119, 34);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver al login";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnRegistro);
            this.Controls.Add(this.btnNuevoEmpleados);
            this.Controls.Add(this.btnNuevoUsuarios);
            this.Name = "FormControl";
            this.Text = "FormControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevoUsuarios;
        private System.Windows.Forms.Button btnNuevoEmpleados;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.Button btnVolver;
    }
}