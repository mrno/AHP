namespace sisExperto
{
    partial class CrearExperto
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxClaveRepetida = new System.Windows.Forms.TextBox();
            this.textBoxClave = new System.Windows.Forms.TextBox();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelClaveRepetida = new System.Windows.Forms.Label();
            this.labelClave = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.buttonCrearContinuar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonCrearSalir = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.labelValidacion = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.textBoxClaveRepetida);
            this.groupBox2.Controls.Add(this.textBoxClave);
            this.groupBox2.Controls.Add(this.textBoxUsuario);
            this.groupBox2.Controls.Add(this.textBoxApellido);
            this.groupBox2.Controls.Add(this.textBoxNombre);
            this.groupBox2.Controls.Add(this.labelClaveRepetida);
            this.groupBox2.Controls.Add(this.labelClave);
            this.groupBox2.Controls.Add(this.labelUsuario);
            this.groupBox2.Controls.Add(this.labelApellido);
            this.groupBox2.Controls.Add(this.labelNombre);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 191);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del nuevo Experto";
            // 
            // textBoxClaveRepetida
            // 
            this.textBoxClaveRepetida.Location = new System.Drawing.Point(156, 135);
            this.textBoxClaveRepetida.Name = "textBoxClaveRepetida";
            this.textBoxClaveRepetida.PasswordChar = '*';
            this.textBoxClaveRepetida.Size = new System.Drawing.Size(239, 23);
            this.textBoxClaveRepetida.TabIndex = 4;
            // 
            // textBoxClave
            // 
            this.textBoxClave.Location = new System.Drawing.Point(156, 106);
            this.textBoxClave.Name = "textBoxClave";
            this.textBoxClave.PasswordChar = '*';
            this.textBoxClave.Size = new System.Drawing.Size(239, 23);
            this.textBoxClave.TabIndex = 3;
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(156, 77);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(239, 23);
            this.textBoxUsuario.TabIndex = 2;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(156, 48);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(239, 23);
            this.textBoxApellido.TabIndex = 1;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(156, 19);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(239, 23);
            this.textBoxNombre.TabIndex = 0;
            // 
            // labelClaveRepetida
            // 
            this.labelClaveRepetida.AutoSize = true;
            this.labelClaveRepetida.Location = new System.Drawing.Point(6, 138);
            this.labelClaveRepetida.Name = "labelClaveRepetida";
            this.labelClaveRepetida.Size = new System.Drawing.Size(95, 17);
            this.labelClaveRepetida.TabIndex = 25;
            this.labelClaveRepetida.Text = "Repetir clave:";
            // 
            // labelClave
            // 
            this.labelClave.AutoSize = true;
            this.labelClave.Location = new System.Drawing.Point(6, 109);
            this.labelClave.Name = "labelClave";
            this.labelClave.Size = new System.Drawing.Size(47, 17);
            this.labelClave.TabIndex = 24;
            this.labelClave.Text = "Clave:";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(6, 80);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(133, 17);
            this.labelUsuario.TabIndex = 23;
            this.labelUsuario.Text = "Nombre de usuario:";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(6, 51);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(62, 17);
            this.labelApellido.TabIndex = 22;
            this.labelApellido.Text = "Apellido:";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(6, 22);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(62, 17);
            this.labelNombre.TabIndex = 21;
            this.labelNombre.Text = "Nombre:";
            // 
            // buttonCrearContinuar
            // 
            this.buttonCrearContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCrearContinuar.Location = new System.Drawing.Point(419, 19);
            this.buttonCrearContinuar.Name = "buttonCrearContinuar";
            this.buttonCrearContinuar.Size = new System.Drawing.Size(140, 30);
            this.buttonCrearContinuar.TabIndex = 1;
            this.buttonCrearContinuar.Text = "Crear y Continuar";
            this.buttonCrearContinuar.UseVisualStyleBackColor = true;
            this.buttonCrearContinuar.Click += new System.EventHandler(this.buttonCrearContinuar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(419, 127);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(140, 30);
            this.buttonCancelar.TabIndex = 4;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonCrearSalir
            // 
            this.buttonCrearSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCrearSalir.Location = new System.Drawing.Point(419, 55);
            this.buttonCrearSalir.Name = "buttonCrearSalir";
            this.buttonCrearSalir.Size = new System.Drawing.Size(140, 30);
            this.buttonCrearSalir.TabIndex = 2;
            this.buttonCrearSalir.Text = "Crear y Salir";
            this.buttonCrearSalir.UseVisualStyleBackColor = true;
            this.buttonCrearSalir.Click += new System.EventHandler(this.buttonCrearSalir_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimpiar.Location = new System.Drawing.Point(419, 91);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(140, 30);
            this.buttonLimpiar.TabIndex = 3;
            this.buttonLimpiar.Text = "Limpiar Campos";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // labelValidacion
            // 
            this.labelValidacion.AutoSize = true;
            this.labelValidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValidacion.Location = new System.Drawing.Point(12, 206);
            this.labelValidacion.Name = "labelValidacion";
            this.labelValidacion.Size = new System.Drawing.Size(233, 17);
            this.labelValidacion.TabIndex = 28;
            this.labelValidacion.Text = "Ingrese los datos del nuevo usuario";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(156, 164);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(114, 21);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "Administrador";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // CrearExperto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 229);
            this.Controls.Add(this.labelValidacion);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonCrearSalir);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCrearContinuar);
            this.Controls.Add(this.groupBox2);
            this.Name = "CrearExperto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrearExperto";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxClaveRepetida;
        private System.Windows.Forms.TextBox textBoxClave;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelClaveRepetida;
        private System.Windows.Forms.Label labelClave;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Button buttonCrearContinuar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonCrearSalir;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Label labelValidacion;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}