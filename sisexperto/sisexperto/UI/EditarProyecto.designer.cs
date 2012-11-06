namespace sisExperto.UI
{
    partial class EditarProyecto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarProyecto));
            this.dataGridAlternativas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alternativaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.criterioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDescripcionAlternativa = new System.Windows.Forms.TextBox();
            this.textBoxNombreAlternativa = new System.Windows.Forms.TextBox();
            this.groupBoxAlternativa = new System.Windows.Forms.GroupBox();
            this.buttonQuitarAlternativa = new System.Windows.Forms.Button();
            this.buttonAgregarAlternativa = new System.Windows.Forms.Button();
            this.groupBoxCriterio = new System.Windows.Forms.GroupBox();
            this.buttonQuitarCriterio = new System.Windows.Forms.Button();
            this.buttonAgregarCriterio = new System.Windows.Forms.Button();
            this.dataGridCriterios = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNombreCriterio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDescripcionCriterio = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxProyectos = new System.Windows.Forms.ComboBox();
            this.proyectoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonLimpiarAsignaciones = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlternativas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.criterioBindingSource)).BeginInit();
            this.groupBoxAlternativa.SuspendLayout();
            this.groupBoxCriterio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCriterios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridAlternativas
            // 
            this.dataGridAlternativas.AutoGenerateColumns = false;
            this.dataGridAlternativas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAlternativas.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridAlternativas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAlternativas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridAlternativas.DataSource = this.alternativaBindingSource;
            this.dataGridAlternativas.Location = new System.Drawing.Point(6, 94);
            this.dataGridAlternativas.Name = "dataGridAlternativas";
            this.dataGridAlternativas.RowHeadersVisible = false;
            this.dataGridAlternativas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAlternativas.Size = new System.Drawing.Size(488, 125);
            this.dataGridAlternativas.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // alternativaBindingSource
            // 
            this.alternativaBindingSource.DataSource = typeof(sisExperto.Entidades.Alternativa);
            // 
            // criterioBindingSource
            // 
            this.criterioBindingSource.DataSource = typeof(sisExperto.Entidades.Criterio);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardar.Location = new System.Drawing.Point(30, 499);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(140, 30);
            this.buttonGuardar.TabIndex = 7;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre:";
            // 
            // textBoxDescripcionAlternativa
            // 
            this.textBoxDescripcionAlternativa.Location = new System.Drawing.Point(108, 54);
            this.textBoxDescripcionAlternativa.Name = "textBoxDescripcionAlternativa";
            this.textBoxDescripcionAlternativa.Size = new System.Drawing.Size(274, 26);
            this.textBoxDescripcionAlternativa.TabIndex = 9;
            // 
            // textBoxNombreAlternativa
            // 
            this.textBoxNombreAlternativa.Location = new System.Drawing.Point(108, 22);
            this.textBoxNombreAlternativa.Name = "textBoxNombreAlternativa";
            this.textBoxNombreAlternativa.Size = new System.Drawing.Size(274, 26);
            this.textBoxNombreAlternativa.TabIndex = 8;
            // 
            // groupBoxAlternativa
            // 
            this.groupBoxAlternativa.Controls.Add(this.buttonQuitarAlternativa);
            this.groupBoxAlternativa.Controls.Add(this.buttonAgregarAlternativa);
            this.groupBoxAlternativa.Controls.Add(this.dataGridAlternativas);
            this.groupBoxAlternativa.Controls.Add(this.label2);
            this.groupBoxAlternativa.Controls.Add(this.textBoxNombreAlternativa);
            this.groupBoxAlternativa.Controls.Add(this.label3);
            this.groupBoxAlternativa.Controls.Add(this.textBoxDescripcionAlternativa);
            this.groupBoxAlternativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAlternativa.Location = new System.Drawing.Point(12, 37);
            this.groupBoxAlternativa.Name = "groupBoxAlternativa";
            this.groupBoxAlternativa.Size = new System.Drawing.Size(500, 225);
            this.groupBoxAlternativa.TabIndex = 26;
            this.groupBoxAlternativa.TabStop = false;
            this.groupBoxAlternativa.Text = "Alternativas";
            // 
            // buttonQuitarAlternativa
            // 
            this.buttonQuitarAlternativa.Image = ((System.Drawing.Image)(resources.GetObject("buttonQuitarAlternativa.Image")));
            this.buttonQuitarAlternativa.Location = new System.Drawing.Point(444, 26);
            this.buttonQuitarAlternativa.Name = "buttonQuitarAlternativa";
            this.buttonQuitarAlternativa.Size = new System.Drawing.Size(50, 50);
            this.buttonQuitarAlternativa.TabIndex = 26;
            this.buttonQuitarAlternativa.UseVisualStyleBackColor = true;
            this.buttonQuitarAlternativa.Click += new System.EventHandler(this.buttonQuitarAlternativa_Click);
            // 
            // buttonAgregarAlternativa
            // 
            this.buttonAgregarAlternativa.Image = ((System.Drawing.Image)(resources.GetObject("buttonAgregarAlternativa.Image")));
            this.buttonAgregarAlternativa.Location = new System.Drawing.Point(388, 26);
            this.buttonAgregarAlternativa.Name = "buttonAgregarAlternativa";
            this.buttonAgregarAlternativa.Size = new System.Drawing.Size(50, 50);
            this.buttonAgregarAlternativa.TabIndex = 25;
            this.buttonAgregarAlternativa.UseVisualStyleBackColor = true;
            this.buttonAgregarAlternativa.Click += new System.EventHandler(this.buttonAgregarAlternativa_Click);
            // 
            // groupBoxCriterio
            // 
            this.groupBoxCriterio.Controls.Add(this.buttonQuitarCriterio);
            this.groupBoxCriterio.Controls.Add(this.buttonAgregarCriterio);
            this.groupBoxCriterio.Controls.Add(this.dataGridCriterios);
            this.groupBoxCriterio.Controls.Add(this.label7);
            this.groupBoxCriterio.Controls.Add(this.textBoxNombreCriterio);
            this.groupBoxCriterio.Controls.Add(this.label8);
            this.groupBoxCriterio.Controls.Add(this.textBoxDescripcionCriterio);
            this.groupBoxCriterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCriterio.Location = new System.Drawing.Point(12, 268);
            this.groupBoxCriterio.Name = "groupBoxCriterio";
            this.groupBoxCriterio.Size = new System.Drawing.Size(500, 225);
            this.groupBoxCriterio.TabIndex = 27;
            this.groupBoxCriterio.TabStop = false;
            this.groupBoxCriterio.Text = "Criterios";
            // 
            // buttonQuitarCriterio
            // 
            this.buttonQuitarCriterio.Image = ((System.Drawing.Image)(resources.GetObject("buttonQuitarCriterio.Image")));
            this.buttonQuitarCriterio.Location = new System.Drawing.Point(444, 26);
            this.buttonQuitarCriterio.Name = "buttonQuitarCriterio";
            this.buttonQuitarCriterio.Size = new System.Drawing.Size(50, 50);
            this.buttonQuitarCriterio.TabIndex = 26;
            this.buttonQuitarCriterio.UseVisualStyleBackColor = true;
            this.buttonQuitarCriterio.Click += new System.EventHandler(this.buttonQuitarCriterio_Click);
            // 
            // buttonAgregarCriterio
            // 
            this.buttonAgregarCriterio.Image = ((System.Drawing.Image)(resources.GetObject("buttonAgregarCriterio.Image")));
            this.buttonAgregarCriterio.Location = new System.Drawing.Point(388, 26);
            this.buttonAgregarCriterio.Name = "buttonAgregarCriterio";
            this.buttonAgregarCriterio.Size = new System.Drawing.Size(50, 50);
            this.buttonAgregarCriterio.TabIndex = 25;
            this.buttonAgregarCriterio.UseVisualStyleBackColor = true;
            this.buttonAgregarCriterio.Click += new System.EventHandler(this.buttonAgregarCriterio_Click);
            // 
            // dataGridCriterios
            // 
            this.dataGridCriterios.AutoGenerateColumns = false;
            this.dataGridCriterios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCriterios.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridCriterios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCriterios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridCriterios.DataSource = this.criterioBindingSource;
            this.dataGridCriterios.Location = new System.Drawing.Point(6, 94);
            this.dataGridCriterios.Name = "dataGridCriterios";
            this.dataGridCriterios.RowHeadersVisible = false;
            this.dataGridCriterios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCriterios.Size = new System.Drawing.Size(488, 125);
            this.dataGridCriterios.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn5.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn6.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
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
            // textBoxNombreCriterio
            // 
            this.textBoxNombreCriterio.Location = new System.Drawing.Point(108, 22);
            this.textBoxNombreCriterio.Name = "textBoxNombreCriterio";
            this.textBoxNombreCriterio.Size = new System.Drawing.Size(274, 26);
            this.textBoxNombreCriterio.TabIndex = 8;
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
            // textBoxDescripcionCriterio
            // 
            this.textBoxDescripcionCriterio.Location = new System.Drawing.Point(108, 54);
            this.textBoxDescripcionCriterio.Name = "textBoxDescripcionCriterio";
            this.textBoxDescripcionCriterio.Size = new System.Drawing.Size(274, 26);
            this.textBoxDescripcionCriterio.TabIndex = 9;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(350, 499);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(140, 30);
            this.buttonCancelar.TabIndex = 28;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Proyecto:";
            // 
            // comboBoxProyectos
            // 
            this.comboBoxProyectos.DataSource = this.proyectoBindingSource;
            this.comboBoxProyectos.DisplayMember = "Nombre";
            this.comboBoxProyectos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProyectos.FormattingEnabled = true;
            this.comboBoxProyectos.Location = new System.Drawing.Point(93, 6);
            this.comboBoxProyectos.Name = "comboBoxProyectos";
            this.comboBoxProyectos.Size = new System.Drawing.Size(419, 28);
            this.comboBoxProyectos.TabIndex = 30;
            this.comboBoxProyectos.SelectedIndexChanged += new System.EventHandler(this.comboBoxProyectos_SelectedIndexChanged);
            this.comboBoxProyectos.Leave += new System.EventHandler(this.comboBoxProyectos_Leave);
            // 
            // proyectoBindingSource
            // 
            this.proyectoBindingSource.DataSource = typeof(sisExperto.Entidades.Proyecto);
            // 
            // buttonLimpiarAsignaciones
            // 
            this.buttonLimpiarAsignaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimpiarAsignaciones.Location = new System.Drawing.Point(190, 499);
            this.buttonLimpiarAsignaciones.Name = "buttonLimpiarAsignaciones";
            this.buttonLimpiarAsignaciones.Size = new System.Drawing.Size(140, 30);
            this.buttonLimpiarAsignaciones.TabIndex = 31;
            this.buttonLimpiarAsignaciones.Text = "Limpiar";
            this.buttonLimpiarAsignaciones.UseVisualStyleBackColor = true;
            this.buttonLimpiarAsignaciones.Click += new System.EventHandler(this.buttonLimpiarAsignaciones_Click);
            // 
            // EditarProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 536);
            this.Controls.Add(this.buttonLimpiarAsignaciones);
            this.Controls.Add(this.comboBoxProyectos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.groupBoxCriterio);
            this.Controls.Add(this.groupBoxAlternativa);
            this.Controls.Add(this.buttonGuardar);
            this.Name = "EditarProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cargar Datos de Proyectos";
            this.Load += new System.EventHandler(this.EditarProyecto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlternativas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.criterioBindingSource)).EndInit();
            this.groupBoxAlternativa.ResumeLayout(false);
            this.groupBoxAlternativa.PerformLayout();
            this.groupBoxCriterio.ResumeLayout(false);
            this.groupBoxCriterio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCriterios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridAlternativas;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDescripcionAlternativa;
        private System.Windows.Forms.TextBox textBoxNombreAlternativa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource alternativaBindingSource;
        private System.Windows.Forms.BindingSource criterioBindingSource;
        private System.Windows.Forms.GroupBox groupBoxAlternativa;
        private System.Windows.Forms.Button buttonQuitarAlternativa;
        private System.Windows.Forms.Button buttonAgregarAlternativa;
        private System.Windows.Forms.GroupBox groupBoxCriterio;
        private System.Windows.Forms.Button buttonQuitarCriterio;
        private System.Windows.Forms.Button buttonAgregarCriterio;
        private System.Windows.Forms.DataGridView dataGridCriterios;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxNombreCriterio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDescripcionCriterio;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxProyectos;
        private System.Windows.Forms.Button buttonLimpiarAsignaciones;
        private System.Windows.Forms.BindingSource proyectoBindingSource;
    }
}

