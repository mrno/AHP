namespace sisexperto.UI
{
    partial class CrearProyecto
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
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxProyectos = new System.Windows.Forms.ComboBox();
            this.proyectoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxClonacion = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTipoModelo = new System.Windows.Forms.ComboBox();
            this.labelNombreExperto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxObjetivoProyecto = new System.Windows.Forms.TextBox();
            this.textBoxNombreProyecto = new System.Windows.Forms.TextBox();
            this.buttonCrearYContinuar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxProyectos);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.checkBoxClonacion);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBoxTipoModelo);
            this.groupBox3.Controls.Add(this.labelNombreExperto);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxObjetivoProyecto);
            this.groupBox3.Controls.Add(this.textBoxNombreProyecto);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(460, 260);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos de proyecto";
            // 
            // comboBoxProyectos
            // 
            this.comboBoxProyectos.DataSource = this.proyectoBindingSource;
            this.comboBoxProyectos.DisplayMember = "Nombre";
            this.comboBoxProyectos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProyectos.FormattingEnabled = true;
            this.comboBoxProyectos.Location = new System.Drawing.Point(82, 55);
            this.comboBoxProyectos.Name = "comboBoxProyectos";
            this.comboBoxProyectos.Size = new System.Drawing.Size(372, 28);
            this.comboBoxProyectos.TabIndex = 2;
            this.comboBoxProyectos.ValueMember = "Nombre";
            // 
            // proyectoBindingSource
            // 
            this.proyectoBindingSource.DataSource = typeof(sisExperto.Entidades.Proyecto);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Proyecto:";
            // 
            // checkBoxClonacion
            // 
            this.checkBoxClonacion.AutoSize = true;
            this.checkBoxClonacion.Location = new System.Drawing.Point(6, 25);
            this.checkBoxClonacion.Name = "checkBoxClonacion";
            this.checkBoxClonacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxClonacion.Size = new System.Drawing.Size(165, 24);
            this.checkBoxClonacion.TabIndex = 0;
            this.checkBoxClonacion.Text = "Crear por clonación";
            this.checkBoxClonacion.UseVisualStyleBackColor = true;
            this.checkBoxClonacion.CheckedChanged += new System.EventHandler(this.checkBoxClonacion_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Modelo/s que ejecuta:";
            // 
            // comboBoxTipoModelo
            // 
            this.comboBoxTipoModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoModelo.FormattingEnabled = true;
            this.comboBoxTipoModelo.Items.AddRange(new object[] {
            "AHP",
            "IL",
            "Ambos"});
            this.comboBoxTipoModelo.Location = new System.Drawing.Point(176, 89);
            this.comboBoxTipoModelo.Name = "comboBoxTipoModelo";
            this.comboBoxTipoModelo.Size = new System.Drawing.Size(278, 28);
            this.comboBoxTipoModelo.TabIndex = 4;
            // 
            // labelNombreExperto
            // 
            this.labelNombreExperto.AutoSize = true;
            this.labelNombreExperto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreExperto.Location = new System.Drawing.Point(83, 230);
            this.labelNombreExperto.Name = "labelNombreExperto";
            this.labelNombreExperto.Size = new System.Drawing.Size(51, 20);
            this.labelNombreExperto.TabIndex = 10;
            this.labelNombreExperto.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Creador:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Objetivo:";
            // 
            // textBoxObjetivoProyecto
            // 
            this.textBoxObjetivoProyecto.Location = new System.Drawing.Point(82, 155);
            this.textBoxObjetivoProyecto.Multiline = true;
            this.textBoxObjetivoProyecto.Name = "textBoxObjetivoProyecto";
            this.textBoxObjetivoProyecto.Size = new System.Drawing.Size(372, 72);
            this.textBoxObjetivoProyecto.TabIndex = 8;
            // 
            // textBoxNombreProyecto
            // 
            this.textBoxNombreProyecto.Location = new System.Drawing.Point(82, 123);
            this.textBoxNombreProyecto.Name = "textBoxNombreProyecto";
            this.textBoxNombreProyecto.Size = new System.Drawing.Size(372, 26);
            this.textBoxNombreProyecto.TabIndex = 6;
            // 
            // buttonCrearYContinuar
            // 
            this.buttonCrearYContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCrearYContinuar.Location = new System.Drawing.Point(42, 278);
            this.buttonCrearYContinuar.Name = "buttonCrearYContinuar";
            this.buttonCrearYContinuar.Size = new System.Drawing.Size(140, 30);
            this.buttonCrearYContinuar.TabIndex = 1;
            this.buttonCrearYContinuar.Text = "Crear Proyecto";
            this.buttonCrearYContinuar.UseVisualStyleBackColor = true;
            this.buttonCrearYContinuar.Click += new System.EventHandler(this.buttonCrearYContinuar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimpiar.Location = new System.Drawing.Point(188, 278);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(140, 30);
            this.buttonLimpiar.TabIndex = 2;
            this.buttonLimpiar.Text = "Limpiar Campos";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(334, 278);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 30);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CrearProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 318);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.buttonCrearYContinuar);
            this.Controls.Add(this.groupBox3);
            this.Name = "CrearProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Proyecto Nuevo";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTipoModelo;
        private System.Windows.Forms.Label labelNombreExperto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxObjetivoProyecto;
        private System.Windows.Forms.TextBox textBoxNombreProyecto;
        private System.Windows.Forms.Button buttonCrearYContinuar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkBoxClonacion;
        private System.Windows.Forms.ComboBox comboBoxProyectos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource proyectoBindingSource;
    }
}