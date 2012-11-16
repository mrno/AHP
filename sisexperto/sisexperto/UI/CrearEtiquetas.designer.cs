namespace sisExperto.UI
{
    partial class CrearEtiquetas
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearEtiquetas));
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonLimpiarAsignaciones = new System.Windows.Forms.Button();
            this.textBoxDescripcionEtiqueta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNombreEtiqueta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonAgregarCriterio = new System.Windows.Forms.Button();
            this.buttonQuitarEtiqueta = new System.Windows.Forms.Button();
            this.groupBoxCriterio = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNombreConjunto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDescripcionConjunto = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewEtiquetas = new System.Windows.Forms.DataGridView();
            this.groupBoxCriterio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEtiquetas)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardar.Location = new System.Drawing.Point(28, 498);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(140, 30);
            this.buttonGuardar.TabIndex = 7;
            this.buttonGuardar.Text = " Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(320, 498);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(136, 30);
            this.buttonCancelar.TabIndex = 28;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonLimpiarAsignaciones
            // 
            this.buttonLimpiarAsignaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimpiarAsignaciones.Location = new System.Drawing.Point(174, 498);
            this.buttonLimpiarAsignaciones.Name = "buttonLimpiarAsignaciones";
            this.buttonLimpiarAsignaciones.Size = new System.Drawing.Size(140, 30);
            this.buttonLimpiarAsignaciones.TabIndex = 31;
            this.buttonLimpiarAsignaciones.Text = "Limpiar";
            this.buttonLimpiarAsignaciones.UseVisualStyleBackColor = true;
            this.buttonLimpiarAsignaciones.Click += new System.EventHandler(this.buttonLimpiarAsignaciones_Click);
            // 
            // textBoxDescripcionEtiqueta
            // 
            this.textBoxDescripcionEtiqueta.Location = new System.Drawing.Point(108, 54);
            this.textBoxDescripcionEtiqueta.Name = "textBoxDescripcionEtiqueta";
            this.textBoxDescripcionEtiqueta.Size = new System.Drawing.Size(220, 26);
            this.textBoxDescripcionEtiqueta.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Descripción:";
            // 
            // textBoxNombreEtiqueta
            // 
            this.textBoxNombreEtiqueta.Location = new System.Drawing.Point(108, 22);
            this.textBoxNombreEtiqueta.Name = "textBoxNombreEtiqueta";
            this.textBoxNombreEtiqueta.Size = new System.Drawing.Size(220, 26);
            this.textBoxNombreEtiqueta.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Nombre:";
            // 
            // buttonAgregarCriterio
            // 
            this.buttonAgregarCriterio.Image = ((System.Drawing.Image)(resources.GetObject("buttonAgregarCriterio.Image")));
            this.buttonAgregarCriterio.Location = new System.Drawing.Point(334, 25);
            this.buttonAgregarCriterio.Name = "buttonAgregarCriterio";
            this.buttonAgregarCriterio.Size = new System.Drawing.Size(50, 50);
            this.buttonAgregarCriterio.TabIndex = 25;
            this.buttonAgregarCriterio.UseVisualStyleBackColor = true;
            this.buttonAgregarCriterio.Click += new System.EventHandler(this.buttonAgregarEtiqueta_Click);
            // 
            // buttonQuitarEtiqueta
            // 
            this.buttonQuitarEtiqueta.Image = ((System.Drawing.Image)(resources.GetObject("buttonQuitarEtiqueta.Image")));
            this.buttonQuitarEtiqueta.Location = new System.Drawing.Point(390, 25);
            this.buttonQuitarEtiqueta.Name = "buttonQuitarEtiqueta";
            this.buttonQuitarEtiqueta.Size = new System.Drawing.Size(50, 50);
            this.buttonQuitarEtiqueta.TabIndex = 26;
            this.buttonQuitarEtiqueta.UseVisualStyleBackColor = true;
            this.buttonQuitarEtiqueta.Click += new System.EventHandler(this.buttonQuitarEtiqueta_Click);
            // 
            // groupBoxCriterio
            // 
            this.groupBoxCriterio.Controls.Add(this.dataGridViewEtiquetas);
            this.groupBoxCriterio.Controls.Add(this.buttonQuitarEtiqueta);
            this.groupBoxCriterio.Controls.Add(this.buttonAgregarCriterio);
            this.groupBoxCriterio.Controls.Add(this.label7);
            this.groupBoxCriterio.Controls.Add(this.textBoxNombreEtiqueta);
            this.groupBoxCriterio.Controls.Add(this.label8);
            this.groupBoxCriterio.Controls.Add(this.textBoxDescripcionEtiqueta);
            this.groupBoxCriterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCriterio.Location = new System.Drawing.Point(10, 115);
            this.groupBoxCriterio.Name = "groupBoxCriterio";
            this.groupBoxCriterio.Size = new System.Drawing.Size(444, 359);
            this.groupBoxCriterio.TabIndex = 27;
            this.groupBoxCriterio.TabStop = false;
            this.groupBoxCriterio.Text = "Etiqueta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxNombreConjunto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDescripcionConjunto);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 90);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nombre del conjunto de etiquetas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre:";
            // 
            // textBoxNombreConjunto
            // 
            this.textBoxNombreConjunto.Location = new System.Drawing.Point(108, 22);
            this.textBoxNombreConjunto.Name = "textBoxNombreConjunto";
            this.textBoxNombreConjunto.Size = new System.Drawing.Size(330, 26);
            this.textBoxNombreConjunto.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Descripción:";
            // 
            // textBoxDescripcionConjunto
            // 
            this.textBoxDescripcionConjunto.Location = new System.Drawing.Point(108, 54);
            this.textBoxDescripcionConjunto.Name = "textBoxDescripcionConjunto";
            this.textBoxDescripcionConjunto.Size = new System.Drawing.Size(330, 26);
            this.textBoxDescripcionConjunto.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.groupBoxCriterio);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 480);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewEtiquetas
            // 
            this.dataGridViewEtiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEtiquetas.Location = new System.Drawing.Point(10, 86);
            this.dataGridViewEtiquetas.Name = "dataGridViewEtiquetas";
            this.dataGridViewEtiquetas.Size = new System.Drawing.Size(424, 267);
            this.dataGridViewEtiquetas.TabIndex = 27;
            // 
            // CrearEtiquetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 533);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonLimpiarAsignaciones);
            this.Controls.Add(this.buttonGuardar);
            this.Name = "CrearEtiquetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear el conjunto de Etiquetas Linguisticas";
            this.Load += new System.EventHandler(this.EditarProyecto_Load);
            this.groupBoxCriterio.ResumeLayout(false);
            this.groupBoxCriterio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEtiquetas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonLimpiarAsignaciones;
        private System.Windows.Forms.TextBox textBoxDescripcionEtiqueta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNombreEtiqueta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonAgregarCriterio;
        private System.Windows.Forms.Button buttonQuitarEtiqueta;
        private System.Windows.Forms.GroupBox groupBoxCriterio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNombreConjunto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDescripcionConjunto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewEtiquetas;
    }
}

