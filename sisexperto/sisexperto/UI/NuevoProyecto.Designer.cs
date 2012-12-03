namespace sisExperto
{
    partial class NuevoProyecto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoProyecto));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNombreProyecto = new System.Windows.Forms.TextBox();
            this.textBoxObjetivoProyecto = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridCombinada = new System.Windows.Forms.DataGridView();
            this.buttonAgregarConjunto = new System.Windows.Forms.Button();
            this.dataGridConjuntoEtiquetas = new System.Windows.Forms.DataGridView();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridExpertosDisponibles = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonCrearEtiquetas = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTipoModelo = new System.Windows.Forms.ComboBox();
            this.labelNombreExperto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCrearYContinuar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.expertoNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expertoApellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.combinadaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conjuntoEtiquetasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.administradorDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.expertoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCombinada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConjuntoEtiquetas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosDisponibles)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combinadaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conjuntoEtiquetasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Objetivo:";
            // 
            // textBoxNombreProyecto
            // 
            this.textBoxNombreProyecto.Location = new System.Drawing.Point(76, 22);
            this.textBoxNombreProyecto.Name = "textBoxNombreProyecto";
            this.textBoxNombreProyecto.Size = new System.Drawing.Size(304, 23);
            this.textBoxNombreProyecto.TabIndex = 3;
            // 
            // textBoxObjetivoProyecto
            // 
            this.textBoxObjetivoProyecto.Location = new System.Drawing.Point(471, 19);
            this.textBoxObjetivoProyecto.Multiline = true;
            this.textBoxObjetivoProyecto.Name = "textBoxObjetivoProyecto";
            this.textBoxObjetivoProyecto.Size = new System.Drawing.Size(399, 76);
            this.textBoxObjetivoProyecto.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(578, 484);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 30);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Crear y Salir";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnCrearYSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(870, 484);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 30);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGridCombinada);
            this.groupBox1.Controls.Add(this.buttonAgregarConjunto);
            this.groupBox1.Controls.Add(this.dataGridConjuntoEtiquetas);
            this.groupBox1.Controls.Add(this.dataGridExpertosDisponibles);
            this.groupBox1.Controls.Add(this.btnQuitar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1003, 344);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asignar Expertos";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(853, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 30);
            this.button1.TabIndex = 31;
            this.button1.Text = "Ver todos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridCombinada
            // 
            this.dataGridCombinada.AutoGenerateColumns = false;
            this.dataGridCombinada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCombinada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCombinada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.expertoNombreDataGridViewTextBoxColumn,
            this.expertoApellidoDataGridViewTextBoxColumn,
            this.adminDataGridViewCheckBoxColumn,
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn});
            this.dataGridCombinada.DataSource = this.combinadaBindingSource;
            this.dataGridCombinada.Location = new System.Drawing.Point(316, 22);
            this.dataGridCombinada.Name = "dataGridCombinada";
            this.dataGridCombinada.ReadOnly = true;
            this.dataGridCombinada.RowHeadersVisible = false;
            this.dataGridCombinada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCombinada.Size = new System.Drawing.Size(348, 316);
            this.dataGridCombinada.TabIndex = 30;
            // 
            // buttonAgregarConjunto
            // 
            this.buttonAgregarConjunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarConjunto.Image = ((System.Drawing.Image)(resources.GetObject("buttonAgregarConjunto.Image")));
            this.buttonAgregarConjunto.Location = new System.Drawing.Point(670, 78);
            this.buttonAgregarConjunto.Name = "buttonAgregarConjunto";
            this.buttonAgregarConjunto.Size = new System.Drawing.Size(50, 50);
            this.buttonAgregarConjunto.TabIndex = 28;
            this.buttonAgregarConjunto.Text = "<<<<<<";
            this.buttonAgregarConjunto.UseVisualStyleBackColor = true;
            this.buttonAgregarConjunto.Click += new System.EventHandler(this.buttonAgregarConjunto_Click);
            // 
            // dataGridConjuntoEtiquetas
            // 
            this.dataGridConjuntoEtiquetas.AllowUserToDeleteRows = false;
            this.dataGridConjuntoEtiquetas.AutoGenerateColumns = false;
            this.dataGridConjuntoEtiquetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridConjuntoEtiquetas.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridConjuntoEtiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridConjuntoEtiquetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.Cantidad});
            this.dataGridConjuntoEtiquetas.DataSource = this.conjuntoEtiquetasBindingSource;
            this.dataGridConjuntoEtiquetas.Location = new System.Drawing.Point(726, 22);
            this.dataGridConjuntoEtiquetas.Name = "dataGridConjuntoEtiquetas";
            this.dataGridConjuntoEtiquetas.ReadOnly = true;
            this.dataGridConjuntoEtiquetas.RowHeadersVisible = false;
            this.dataGridConjuntoEtiquetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridConjuntoEtiquetas.Size = new System.Drawing.Size(271, 279);
            this.dataGridConjuntoEtiquetas.TabIndex = 26;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // dataGridExpertosDisponibles
            // 
            this.dataGridExpertosDisponibles.AllowUserToDeleteRows = false;
            this.dataGridExpertosDisponibles.AutoGenerateColumns = false;
            this.dataGridExpertosDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridExpertosDisponibles.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridExpertosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpertosDisponibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.administradorDataGridViewCheckBoxColumn1});
            this.dataGridExpertosDisponibles.DataSource = this.expertoBindingSource;
            this.dataGridExpertosDisponibles.Location = new System.Drawing.Point(10, 21);
            this.dataGridExpertosDisponibles.MultiSelect = false;
            this.dataGridExpertosDisponibles.Name = "dataGridExpertosDisponibles";
            this.dataGridExpertosDisponibles.ReadOnly = true;
            this.dataGridExpertosDisponibles.RowHeadersVisible = false;
            this.dataGridExpertosDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridExpertosDisponibles.Size = new System.Drawing.Size(245, 316);
            this.dataGridExpertosDisponibles.TabIndex = 25;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.Location = new System.Drawing.Point(260, 134);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(50, 50);
            this.btnQuitar.TabIndex = 24;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(260, 78);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(50, 50);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(260, 22);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(50, 50);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonCrearEtiquetas);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBoxTipoModelo);
            this.groupBox3.Controls.Add(this.labelNombreExperto);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxObjetivoProyecto);
            this.groupBox3.Controls.Add(this.textBoxNombreProyecto);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1004, 111);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos de proyecto";
            // 
            // buttonCrearEtiquetas
            // 
            this.buttonCrearEtiquetas.Location = new System.Drawing.Point(261, 78);
            this.buttonCrearEtiquetas.Name = "buttonCrearEtiquetas";
            this.buttonCrearEtiquetas.Size = new System.Drawing.Size(119, 23);
            this.buttonCrearEtiquetas.TabIndex = 9;
            this.buttonCrearEtiquetas.Text = "Crear Etiquetas";
            this.buttonCrearEtiquetas.UseVisualStyleBackColor = true;
            this.buttonCrearEtiquetas.Click += new System.EventHandler(this.buttonCrearEtiquetas_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ejecuta modelo/s:";
            // 
            // comboBoxTipoModelo
            // 
            this.comboBoxTipoModelo.FormattingEnabled = true;
            this.comboBoxTipoModelo.Items.AddRange(new object[] {
            "1: AHP",
            "2: IL",
            "3: Ambos"});
            this.comboBoxTipoModelo.Location = new System.Drawing.Point(134, 78);
            this.comboBoxTipoModelo.Name = "comboBoxTipoModelo";
            this.comboBoxTipoModelo.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTipoModelo.TabIndex = 7;
            this.comboBoxTipoModelo.SelectedIndexChanged += new System.EventHandler(this.SetearBotonCrearEtiquetas);
            // 
            // labelNombreExperto
            // 
            this.labelNombreExperto.AutoSize = true;
            this.labelNombreExperto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreExperto.Location = new System.Drawing.Point(73, 54);
            this.labelNombreExperto.Name = "labelNombreExperto";
            this.labelNombreExperto.Size = new System.Drawing.Size(52, 17);
            this.labelNombreExperto.TabIndex = 6;
            this.labelNombreExperto.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Creador:";
            // 
            // buttonCrearYContinuar
            // 
            this.buttonCrearYContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCrearYContinuar.Location = new System.Drawing.Point(432, 484);
            this.buttonCrearYContinuar.Name = "buttonCrearYContinuar";
            this.buttonCrearYContinuar.Size = new System.Drawing.Size(140, 30);
            this.buttonCrearYContinuar.TabIndex = 9;
            this.buttonCrearYContinuar.Text = "Crear y Continuar";
            this.buttonCrearYContinuar.UseVisualStyleBackColor = true;
            this.buttonCrearYContinuar.Click += new System.EventHandler(this.buttonCrearYContinuar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimpiar.Location = new System.Drawing.Point(724, 484);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(140, 30);
            this.buttonLimpiar.TabIndex = 10;
            this.buttonLimpiar.Text = "Limpiar Campos";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // expertoNombreDataGridViewTextBoxColumn
            // 
            this.expertoNombreDataGridViewTextBoxColumn.DataPropertyName = "ExpertoNombre";
            this.expertoNombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.expertoNombreDataGridViewTextBoxColumn.Name = "expertoNombreDataGridViewTextBoxColumn";
            this.expertoNombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expertoApellidoDataGridViewTextBoxColumn
            // 
            this.expertoApellidoDataGridViewTextBoxColumn.DataPropertyName = "ExpertoApellido";
            this.expertoApellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            this.expertoApellidoDataGridViewTextBoxColumn.Name = "expertoApellidoDataGridViewTextBoxColumn";
            this.expertoApellidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // adminDataGridViewCheckBoxColumn
            // 
            this.adminDataGridViewCheckBoxColumn.DataPropertyName = "Admin";
            this.adminDataGridViewCheckBoxColumn.HeaderText = "Admin";
            this.adminDataGridViewCheckBoxColumn.Name = "adminDataGridViewCheckBoxColumn";
            this.adminDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // conjuntoEtiquetasNombreDataGridViewTextBoxColumn
            // 
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn.DataPropertyName = "ConjuntoEtiquetasNombre";
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn.HeaderText = "Etiquetas";
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn.Name = "conjuntoEtiquetasNombreDataGridViewTextBoxColumn";
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // combinadaBindingSource
            // 
            this.combinadaBindingSource.DataSource = typeof(sisexperto.Entidades.Combinada);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn4.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // conjuntoEtiquetasBindingSource
            // 
            this.conjuntoEtiquetasBindingSource.DataSource = typeof(sisexperto.Entidades.ConjuntoEtiquetas);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Apellido";
            this.dataGridViewTextBoxColumn5.HeaderText = "Apellido";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn6.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // administradorDataGridViewCheckBoxColumn1
            // 
            this.administradorDataGridViewCheckBoxColumn1.DataPropertyName = "Administrador";
            this.administradorDataGridViewCheckBoxColumn1.FillWeight = 50F;
            this.administradorDataGridViewCheckBoxColumn1.HeaderText = "Administrador";
            this.administradorDataGridViewCheckBoxColumn1.Name = "administradorDataGridViewCheckBoxColumn1";
            this.administradorDataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // expertoBindingSource
            // 
            this.expertoBindingSource.DataSource = typeof(sisExperto.Entidades.Experto);
            // 
            // NuevoProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 526);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonCrearYContinuar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "NuevoProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo Proyecto";

            this.Load += new System.EventHandler(this.NuevoProyecto_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCombinada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConjuntoEtiquetas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosDisponibles)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combinadaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conjuntoEtiquetasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNombreProyecto;
        private System.Windows.Forms.TextBox textBoxObjetivoProyecto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridExpertosDisponibles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button buttonCrearYContinuar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNombreExperto;
        private System.Windows.Forms.BindingSource expertoBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTipoModelo;
        private System.Windows.Forms.Button buttonCrearEtiquetas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn administradorDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.Button buttonAgregarConjunto;
        private System.Windows.Forms.DataGridView dataGridConjuntoEtiquetas;
        private System.Windows.Forms.BindingSource conjuntoEtiquetasBindingSource;
        private System.Windows.Forms.BindingSource combinadaBindingSource;
        private System.Windows.Forms.DataGridView dataGridCombinada;
        private System.Windows.Forms.DataGridViewTextBoxColumn expertoNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expertoApellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn adminDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conjuntoEtiquetasNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
    }
}