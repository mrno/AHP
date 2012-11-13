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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearEtiquetas));
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.proyectoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonLimpiarAsignaciones = new System.Windows.Forms.Button();
            this.textBoxDescripcionEtiqueta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNombreEtiqueta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridEtiquetas = new System.Windows.Forms.DataGridView();
            this.buttonAgregarCriterio = new System.Windows.Forms.Button();
            this.buttonQuitarEtiqueta = new System.Windows.Forms.Button();
            this.groupBoxCriterio = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEtiquetas)).BeginInit();
            this.groupBoxCriterio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardar.Location = new System.Drawing.Point(18, 498);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(140, 30);
            this.buttonGuardar.TabIndex = 7;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(338, 498);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(140, 30);
            this.buttonCancelar.TabIndex = 28;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // proyectoBindingSource
            // 
            this.proyectoBindingSource.DataSource = typeof(sisExperto.Entidades.Proyecto);
            // 
            // buttonLimpiarAsignaciones
            // 
            this.buttonLimpiarAsignaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimpiarAsignaciones.Location = new System.Drawing.Point(178, 498);
            this.buttonLimpiarAsignaciones.Name = "buttonLimpiarAsignaciones";
            this.buttonLimpiarAsignaciones.Size = new System.Drawing.Size(140, 30);
            this.buttonLimpiarAsignaciones.TabIndex = 31;
            this.buttonLimpiarAsignaciones.Text = "Limpiar";
            this.buttonLimpiarAsignaciones.UseVisualStyleBackColor = true;
            this.buttonLimpiarAsignaciones.Click += new System.EventHandler(this.buttonLimpiarAsignaciones_Click);
            // 
            // textBoxDescripcionEtiqueta
            // 
            this.textBoxDescripcionEtiqueta.Location = new System.Drawing.Point(106, 52);
            this.textBoxDescripcionEtiqueta.Name = "textBoxDescripcionEtiqueta";
            this.textBoxDescripcionEtiqueta.Size = new System.Drawing.Size(176, 26);
            this.textBoxDescripcionEtiqueta.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Descripción:";
            // 
            // textBoxNombreEtiqueta
            // 
            this.textBoxNombreEtiqueta.Location = new System.Drawing.Point(106, 20);
            this.textBoxNombreEtiqueta.Name = "textBoxNombreEtiqueta";
            this.textBoxNombreEtiqueta.Size = new System.Drawing.Size(176, 26);
            this.textBoxNombreEtiqueta.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Nombre:";
            // 
            // dataGridEtiquetas
            // 
            this.dataGridEtiquetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEtiquetas.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridEtiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEtiquetas.Location = new System.Drawing.Point(6, 84);
            this.dataGridEtiquetas.Name = "dataGridEtiquetas";
            this.dataGridEtiquetas.RowHeadersVisible = false;
            this.dataGridEtiquetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEtiquetas.Size = new System.Drawing.Size(428, 209);
            this.dataGridEtiquetas.TabIndex = 0;
            // 
            // buttonAgregarCriterio
            // 
            this.buttonAgregarCriterio.Image = ((System.Drawing.Image)(resources.GetObject("buttonAgregarCriterio.Image")));
            this.buttonAgregarCriterio.Location = new System.Drawing.Point(332, 23);
            this.buttonAgregarCriterio.Name = "buttonAgregarCriterio";
            this.buttonAgregarCriterio.Size = new System.Drawing.Size(50, 50);
            this.buttonAgregarCriterio.TabIndex = 25;
            this.buttonAgregarCriterio.UseVisualStyleBackColor = true;
            this.buttonAgregarCriterio.Click += new System.EventHandler(this.buttonAgregarEtiqueta_Click);
            // 
            // buttonQuitarEtiqueta
            // 
            this.buttonQuitarEtiqueta.Image = ((System.Drawing.Image)(resources.GetObject("buttonQuitarEtiqueta.Image")));
            this.buttonQuitarEtiqueta.Location = new System.Drawing.Point(388, 23);
            this.buttonQuitarEtiqueta.Name = "buttonQuitarEtiqueta";
            this.buttonQuitarEtiqueta.Size = new System.Drawing.Size(50, 50);
            this.buttonQuitarEtiqueta.TabIndex = 26;
            this.buttonQuitarEtiqueta.UseVisualStyleBackColor = true;
            this.buttonQuitarEtiqueta.Click += new System.EventHandler(this.buttonQuitarEtiqueta_Click);
            // 
            // groupBoxCriterio
            // 
            this.groupBoxCriterio.Controls.Add(this.buttonQuitarEtiqueta);
            this.groupBoxCriterio.Controls.Add(this.buttonAgregarCriterio);
            this.groupBoxCriterio.Controls.Add(this.dataGridEtiquetas);
            this.groupBoxCriterio.Controls.Add(this.label7);
            this.groupBoxCriterio.Controls.Add(this.textBoxNombreEtiqueta);
            this.groupBoxCriterio.Controls.Add(this.label8);
            this.groupBoxCriterio.Controls.Add(this.textBoxDescripcionEtiqueta);
            this.groupBoxCriterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCriterio.Location = new System.Drawing.Point(10, 150);
            this.groupBoxCriterio.Name = "groupBoxCriterio";
            this.groupBoxCriterio.Size = new System.Drawing.Size(444, 298);
            this.groupBoxCriterio.TabIndex = 27;
            this.groupBoxCriterio.TabStop = false;
            this.groupBoxCriterio.Text = "Etiqueta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 54);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(330, 26);
            this.textBox1.TabIndex = 8;
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(108, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(330, 26);
            this.textBox2.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "9",
            "11",
            "13"});
            this.comboBox1.Location = new System.Drawing.Point(407, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(53, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.CargarComboEtiquetas);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(28, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Longitud de conjuntos de etiquetas a crear:";
           // this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "9",
            "11",
            "13"});
            this.comboBox2.Location = new System.Drawing.Point(395, 25);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(53, 21);
            this.comboBox2.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Configurar el conjunto de etiquetas S[i]:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.groupBoxCriterio);
            this.groupBox2.Location = new System.Drawing.Point(12, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 457);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // CrearEtiquetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 533);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonLimpiarAsignaciones);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Name = "CrearEtiquetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear el conjunto de Etiquetas Linguisticas";
            this.Load += new System.EventHandler(this.EditarProyecto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEtiquetas)).EndInit();
            this.groupBoxCriterio.ResumeLayout(false);
            this.groupBoxCriterio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonLimpiarAsignaciones;
        private System.Windows.Forms.BindingSource proyectoBindingSource;
        private System.Windows.Forms.TextBox textBoxDescripcionEtiqueta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNombreEtiqueta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridEtiquetas;
        private System.Windows.Forms.Button buttonAgregarCriterio;
        private System.Windows.Forms.Button buttonQuitarEtiqueta;
        private System.Windows.Forms.GroupBox groupBoxCriterio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

