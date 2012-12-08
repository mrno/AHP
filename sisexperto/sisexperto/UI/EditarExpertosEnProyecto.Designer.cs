namespace sisexperto.UI
{
    partial class EditarExpertosEnProyecto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarExpertosEnProyecto));
            this.comboBoxProyectos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCrearEtiquetas = new System.Windows.Forms.Button();
            this.dataGridCombinada = new System.Windows.Forms.DataGridView();
            this.buttonAgregarConjunto = new System.Windows.Forms.Button();
            this.dataGridConjuntoEtiquetas = new System.Windows.Forms.DataGridView();
            this.dataGridExpertosDisponibles = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonCrearYContinuar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gestorNombre = new System.Windows.Forms.Label();
            this.expertoNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expertoApellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.combinadaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conjuntoEtiquetasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.apellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.administradorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.expertoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCombinada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConjuntoEtiquetas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combinadaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conjuntoEtiquetasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxProyectos
            // 
            this.comboBoxProyectos.DisplayMember = "Nombre";
            this.comboBoxProyectos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProyectos.FormattingEnabled = true;
            this.comboBoxProyectos.Location = new System.Drawing.Point(478, 12);
            this.comboBoxProyectos.Name = "comboBoxProyectos";
            this.comboBoxProyectos.Size = new System.Drawing.Size(419, 28);
            this.comboBoxProyectos.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(397, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Proyecto:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCrearEtiquetas);
            this.groupBox1.Controls.Add(this.dataGridCombinada);
            this.groupBox1.Controls.Add(this.buttonAgregarConjunto);
            this.groupBox1.Controls.Add(this.dataGridConjuntoEtiquetas);
            this.groupBox1.Controls.Add(this.dataGridExpertosDisponibles);
            this.groupBox1.Controls.Add(this.btnQuitar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 335);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asignar Expertos";
            // 
            // buttonCrearEtiquetas
            // 
            this.buttonCrearEtiquetas.Location = new System.Drawing.Point(740, 295);
            this.buttonCrearEtiquetas.Name = "buttonCrearEtiquetas";
            this.buttonCrearEtiquetas.Size = new System.Drawing.Size(140, 30);
            this.buttonCrearEtiquetas.TabIndex = 31;
            this.buttonCrearEtiquetas.Text = "Crear Etiquetas";
            this.buttonCrearEtiquetas.UseVisualStyleBackColor = true;
            // 
            // dataGridCombinada
            // 
            this.dataGridCombinada.AutoGenerateColumns = false;
            this.dataGridCombinada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCombinada.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridCombinada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCombinada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.expertoNombreDataGridViewTextBoxColumn,
            this.expertoApellidoDataGridViewTextBoxColumn,
            this.adminDataGridViewCheckBoxColumn,
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn});
            this.dataGridCombinada.DataSource = this.combinadaBindingSource;
            this.dataGridCombinada.Location = new System.Drawing.Point(318, 26);
            this.dataGridCombinada.Name = "dataGridCombinada";
            this.dataGridCombinada.ReadOnly = true;
            this.dataGridCombinada.RowHeadersVisible = false;
            this.dataGridCombinada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCombinada.Size = new System.Drawing.Size(250, 300);
            this.dataGridCombinada.TabIndex = 30;
            // 
            // buttonAgregarConjunto
            // 
            this.buttonAgregarConjunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarConjunto.Image = ((System.Drawing.Image)(resources.GetObject("buttonAgregarConjunto.Image")));
            this.buttonAgregarConjunto.Location = new System.Drawing.Point(574, 26);
            this.buttonAgregarConjunto.Name = "buttonAgregarConjunto";
            this.buttonAgregarConjunto.Size = new System.Drawing.Size(50, 50);
            this.buttonAgregarConjunto.TabIndex = 28;
            this.buttonAgregarConjunto.Text = "<<<<<<";
            this.buttonAgregarConjunto.UseVisualStyleBackColor = true;
            // 
            // dataGridConjuntoEtiquetas
            // 
            this.dataGridConjuntoEtiquetas.AllowUserToDeleteRows = false;
            this.dataGridConjuntoEtiquetas.AutoGenerateColumns = false;
            this.dataGridConjuntoEtiquetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridConjuntoEtiquetas.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridConjuntoEtiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridConjuntoEtiquetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn1,
            this.cantidadDataGridViewTextBoxColumn});
            this.dataGridConjuntoEtiquetas.DataSource = this.conjuntoEtiquetasBindingSource;
            this.dataGridConjuntoEtiquetas.Location = new System.Drawing.Point(630, 26);
            this.dataGridConjuntoEtiquetas.Name = "dataGridConjuntoEtiquetas";
            this.dataGridConjuntoEtiquetas.ReadOnly = true;
            this.dataGridConjuntoEtiquetas.RowHeadersVisible = false;
            this.dataGridConjuntoEtiquetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridConjuntoEtiquetas.Size = new System.Drawing.Size(250, 263);
            this.dataGridConjuntoEtiquetas.TabIndex = 26;
            // 
            // dataGridExpertosDisponibles
            // 
            this.dataGridExpertosDisponibles.AllowUserToDeleteRows = false;
            this.dataGridExpertosDisponibles.AutoGenerateColumns = false;
            this.dataGridExpertosDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridExpertosDisponibles.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridExpertosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpertosDisponibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.apellidoDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.administradorDataGridViewCheckBoxColumn});
            this.dataGridExpertosDisponibles.DataSource = this.expertoBindingSource;
            this.dataGridExpertosDisponibles.Location = new System.Drawing.Point(6, 25);
            this.dataGridExpertosDisponibles.MultiSelect = false;
            this.dataGridExpertosDisponibles.Name = "dataGridExpertosDisponibles";
            this.dataGridExpertosDisponibles.ReadOnly = true;
            this.dataGridExpertosDisponibles.RowHeadersVisible = false;
            this.dataGridExpertosDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridExpertosDisponibles.Size = new System.Drawing.Size(250, 300);
            this.dataGridExpertosDisponibles.TabIndex = 25;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.Location = new System.Drawing.Point(262, 137);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(50, 50);
            this.btnQuitar.TabIndex = 24;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(262, 81);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(50, 50);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(262, 25);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(50, 50);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimpiar.Location = new System.Drawing.Point(611, 381);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(140, 30);
            this.buttonLimpiar.TabIndex = 37;
            this.buttonLimpiar.Text = "Deshacer Todo";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonCrearYContinuar
            // 
            this.buttonCrearYContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCrearYContinuar.Location = new System.Drawing.Point(319, 381);
            this.buttonCrearYContinuar.Name = "buttonCrearYContinuar";
            this.buttonCrearYContinuar.Size = new System.Drawing.Size(140, 30);
            this.buttonCrearYContinuar.TabIndex = 36;
            this.buttonCrearYContinuar.Text = "Guardar y Seguir";
            this.buttonCrearYContinuar.UseVisualStyleBackColor = true;
            this.buttonCrearYContinuar.Click += new System.EventHandler(this.buttonCrearYContinuar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(757, 381);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 30);
            this.btnCancelar.TabIndex = 35;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(465, 381);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 30);
            this.btnGuardar.TabIndex = 34;
            this.btnGuardar.Text = "Guardar y Salir";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Gestor:";
            // 
            // gestorNombre
            // 
            this.gestorNombre.AutoSize = true;
            this.gestorNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gestorNombre.Location = new System.Drawing.Point(80, 15);
            this.gestorNombre.Name = "gestorNombre";
            this.gestorNombre.Size = new System.Drawing.Size(65, 20);
            this.gestorNombre.TabIndex = 39;
            this.gestorNombre.Text = "Nombre";
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
            // nombreDataGridViewTextBoxColumn1
            // 
            this.nombreDataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn1.Name = "nombreDataGridViewTextBoxColumn1";
            this.nombreDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conjuntoEtiquetasBindingSource
            // 
            this.conjuntoEtiquetasBindingSource.DataSource = typeof(sisexperto.Entidades.ConjuntoEtiquetas);
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            this.apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            this.apellidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // administradorDataGridViewCheckBoxColumn
            // 
            this.administradorDataGridViewCheckBoxColumn.DataPropertyName = "Administrador";
            this.administradorDataGridViewCheckBoxColumn.HeaderText = "Admin";
            this.administradorDataGridViewCheckBoxColumn.Name = "administradorDataGridViewCheckBoxColumn";
            this.administradorDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // expertoBindingSource
            // 
            this.expertoBindingSource.DataSource = typeof(sisExperto.Entidades.Experto);
            // 
            // EditarExpertosEnProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 421);
            this.Controls.Add(this.gestorNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonCrearYContinuar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxProyectos);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EditarExpertosEnProyecto";
            this.Text = "Editar Expertos En Proyecto";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCombinada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConjuntoEtiquetas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combinadaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conjuntoEtiquetasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxProyectos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridCombinada;
        private System.Windows.Forms.Button buttonAgregarConjunto;
        private System.Windows.Forms.DataGridView dataGridConjuntoEtiquetas;
        private System.Windows.Forms.DataGridView dataGridExpertosDisponibles;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button buttonCrearEtiquetas;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonCrearYContinuar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.BindingSource combinadaBindingSource;
        private System.Windows.Forms.BindingSource conjuntoEtiquetasBindingSource;
        private System.Windows.Forms.BindingSource expertoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn expertoNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expertoApellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn adminDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conjuntoEtiquetasNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn administradorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label gestorNombre;
    }
}