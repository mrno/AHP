namespace sisexperto.UI
{
    partial class AsignarExpertosIL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignarExpertosIL));
            this.comboBoxProyectos = new System.Windows.Forms.ComboBox();
            this.btnNuevoExperto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBoxAsignados = new System.Windows.Forms.GroupBox();
            this.dataGridExpertosEnProyecto = new System.Windows.Forms.DataGridView();
            this.ApellidoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expertoEnProyectoViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnQuitar = new System.Windows.Forms.Button();
            this.groupBoxDisponible = new System.Windows.Forms.GroupBox();
            this.dataGridExpertosDisponibles = new System.Windows.Forms.DataGridView();
            this.apellidoYNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expertoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAgregar = new System.Windows.Forms.Button();
            this.groupBoxConjuntosEtiquetas = new System.Windows.Forms.GroupBox();
            this.dataGridConjuntoEtiquetas = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conjuntoEtiquetasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAgregarConjunto = new System.Windows.Forms.Button();
            this.btnNuevoConjuntoEtiquetas = new System.Windows.Forms.Button();
            this.groupBoxAsignados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosEnProyecto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoEnProyectoViewModelBindingSource)).BeginInit();
            this.groupBoxDisponible.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).BeginInit();
            this.groupBoxConjuntosEtiquetas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConjuntoEtiquetas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conjuntoEtiquetasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxProyectos
            // 
            this.comboBoxProyectos.DisplayMember = "Nombre";
            this.comboBoxProyectos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProyectos.FormattingEnabled = true;
            this.comboBoxProyectos.Location = new System.Drawing.Point(93, 6);
            this.comboBoxProyectos.Name = "comboBoxProyectos";
            this.comboBoxProyectos.Size = new System.Drawing.Size(582, 28);
            this.comboBoxProyectos.TabIndex = 40;
            // 
            // btnNuevoExperto
            // 
            this.btnNuevoExperto.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoExperto.Image")));
            this.btnNuevoExperto.Location = new System.Drawing.Point(318, 65);
            this.btnNuevoExperto.Name = "btnNuevoExperto";
            this.btnNuevoExperto.Size = new System.Drawing.Size(50, 50);
            this.btnNuevoExperto.TabIndex = 32;
            this.btnNuevoExperto.UseVisualStyleBackColor = true;
            this.btnNuevoExperto.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Proyecto:";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardar.Location = new System.Drawing.Point(243, 619);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(140, 30);
            this.buttonGuardar.TabIndex = 37;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(535, 619);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 30);
            this.btnCancelar.TabIndex = 39;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(389, 619);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 30);
            this.btnGuardar.TabIndex = 38;
            this.btnGuardar.Text = "Guardar y Salir";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // groupBoxAsignados
            // 
            this.groupBoxAsignados.Controls.Add(this.dataGridExpertosEnProyecto);
            this.groupBoxAsignados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAsignados.Location = new System.Drawing.Point(374, 40);
            this.groupBoxAsignados.Name = "groupBoxAsignados";
            this.groupBoxAsignados.Size = new System.Drawing.Size(300, 566);
            this.groupBoxAsignados.TabIndex = 36;
            this.groupBoxAsignados.TabStop = false;
            this.groupBoxAsignados.Text = "Expertos Asignados";
            // 
            // dataGridExpertosEnProyecto
            // 
            this.dataGridExpertosEnProyecto.AllowUserToAddRows = false;
            this.dataGridExpertosEnProyecto.AllowUserToDeleteRows = false;
            this.dataGridExpertosEnProyecto.AutoGenerateColumns = false;
            this.dataGridExpertosEnProyecto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridExpertosEnProyecto.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridExpertosEnProyecto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpertosEnProyecto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ApellidoNombre,
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn1});
            this.dataGridExpertosEnProyecto.DataSource = this.expertoEnProyectoViewModelBindingSource;
            this.dataGridExpertosEnProyecto.Location = new System.Drawing.Point(6, 25);
            this.dataGridExpertosEnProyecto.MultiSelect = false;
            this.dataGridExpertosEnProyecto.Name = "dataGridExpertosEnProyecto";
            this.dataGridExpertosEnProyecto.ReadOnly = true;
            this.dataGridExpertosEnProyecto.RowHeadersVisible = false;
            this.dataGridExpertosEnProyecto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridExpertosEnProyecto.Size = new System.Drawing.Size(288, 535);
            this.dataGridExpertosEnProyecto.TabIndex = 1;
            // 
            // ApellidoNombre
            // 
            this.ApellidoNombre.DataPropertyName = "ApellidoNombre";
            this.ApellidoNombre.HeaderText = "ApellidoNombre";
            this.ApellidoNombre.Name = "ApellidoNombre";
            this.ApellidoNombre.ReadOnly = true;
            // 
            // conjuntoEtiquetasNombreDataGridViewTextBoxColumn1
            // 
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn1.DataPropertyName = "ConjuntoEtiquetasNombre";
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn1.HeaderText = "ConjuntoEtiquetasNombre";
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn1.Name = "conjuntoEtiquetasNombreDataGridViewTextBoxColumn1";
            this.conjuntoEtiquetasNombreDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // expertoEnProyectoViewModelBindingSource
            // 
            this.expertoEnProyectoViewModelBindingSource.DataSource = typeof(sisexperto.UI.Clases.ExpertoEnProyectoViewModel);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.Location = new System.Drawing.Point(318, 177);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(50, 50);
            this.btnQuitar.TabIndex = 34;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // groupBoxDisponible
            // 
            this.groupBoxDisponible.Controls.Add(this.dataGridExpertosDisponibles);
            this.groupBoxDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDisponible.Location = new System.Drawing.Point(12, 40);
            this.groupBoxDisponible.Name = "groupBoxDisponible";
            this.groupBoxDisponible.Size = new System.Drawing.Size(300, 280);
            this.groupBoxDisponible.TabIndex = 35;
            this.groupBoxDisponible.TabStop = false;
            this.groupBoxDisponible.Text = "Expertos Disponibles";
            // 
            // dataGridExpertosDisponibles
            // 
            this.dataGridExpertosDisponibles.AllowUserToAddRows = false;
            this.dataGridExpertosDisponibles.AllowUserToDeleteRows = false;
            this.dataGridExpertosDisponibles.AutoGenerateColumns = false;
            this.dataGridExpertosDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridExpertosDisponibles.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridExpertosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpertosDisponibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.apellidoYNombreDataGridViewTextBoxColumn});
            this.dataGridExpertosDisponibles.DataSource = this.expertoBindingSource;
            this.dataGridExpertosDisponibles.Location = new System.Drawing.Point(6, 25);
            this.dataGridExpertosDisponibles.MultiSelect = false;
            this.dataGridExpertosDisponibles.Name = "dataGridExpertosDisponibles";
            this.dataGridExpertosDisponibles.ReadOnly = true;
            this.dataGridExpertosDisponibles.RowHeadersVisible = false;
            this.dataGridExpertosDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridExpertosDisponibles.Size = new System.Drawing.Size(288, 249);
            this.dataGridExpertosDisponibles.TabIndex = 0;
            // 
            // apellidoYNombreDataGridViewTextBoxColumn
            // 
            this.apellidoYNombreDataGridViewTextBoxColumn.DataPropertyName = "ApellidoYNombre";
            this.apellidoYNombreDataGridViewTextBoxColumn.HeaderText = "ApellidoYNombre";
            this.apellidoYNombreDataGridViewTextBoxColumn.Name = "apellidoYNombreDataGridViewTextBoxColumn";
            this.apellidoYNombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expertoBindingSource
            // 
            this.expertoBindingSource.DataSource = typeof(sisExperto.Entidades.Experto);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(318, 121);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(50, 50);
            this.btnAgregar.TabIndex = 33;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // groupBoxConjuntosEtiquetas
            // 
            this.groupBoxConjuntosEtiquetas.Controls.Add(this.dataGridConjuntoEtiquetas);
            this.groupBoxConjuntosEtiquetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxConjuntosEtiquetas.Location = new System.Drawing.Point(12, 326);
            this.groupBoxConjuntosEtiquetas.Name = "groupBoxConjuntosEtiquetas";
            this.groupBoxConjuntosEtiquetas.Size = new System.Drawing.Size(300, 280);
            this.groupBoxConjuntosEtiquetas.TabIndex = 36;
            this.groupBoxConjuntosEtiquetas.TabStop = false;
            this.groupBoxConjuntosEtiquetas.Text = "Conjuntos de Etiquetas";
            // 
            // dataGridConjuntoEtiquetas
            // 
            this.dataGridConjuntoEtiquetas.AllowUserToAddRows = false;
            this.dataGridConjuntoEtiquetas.AllowUserToDeleteRows = false;
            this.dataGridConjuntoEtiquetas.AutoGenerateColumns = false;
            this.dataGridConjuntoEtiquetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridConjuntoEtiquetas.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridConjuntoEtiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridConjuntoEtiquetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn1,
            this.cantidadDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn});
            this.dataGridConjuntoEtiquetas.DataSource = this.conjuntoEtiquetasBindingSource;
            this.dataGridConjuntoEtiquetas.Location = new System.Drawing.Point(6, 25);
            this.dataGridConjuntoEtiquetas.MultiSelect = false;
            this.dataGridConjuntoEtiquetas.Name = "dataGridConjuntoEtiquetas";
            this.dataGridConjuntoEtiquetas.ReadOnly = true;
            this.dataGridConjuntoEtiquetas.RowHeadersVisible = false;
            this.dataGridConjuntoEtiquetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridConjuntoEtiquetas.Size = new System.Drawing.Size(288, 249);
            this.dataGridConjuntoEtiquetas.TabIndex = 0;
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
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conjuntoEtiquetasBindingSource
            // 
            this.conjuntoEtiquetasBindingSource.DataSource = typeof(sisexperto.Entidades.ConjuntoEtiquetas);
            // 
            // btnAgregarConjunto
            // 
            this.btnAgregarConjunto.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarConjunto.Image")));
            this.btnAgregarConjunto.Location = new System.Drawing.Point(318, 407);
            this.btnAgregarConjunto.Name = "btnAgregarConjunto";
            this.btnAgregarConjunto.Size = new System.Drawing.Size(50, 50);
            this.btnAgregarConjunto.TabIndex = 42;
            this.btnAgregarConjunto.UseVisualStyleBackColor = true;
            this.btnAgregarConjunto.Click += new System.EventHandler(this.btnAgregarConjunto_Click);
            // 
            // btnNuevoConjuntoEtiquetas
            // 
            this.btnNuevoConjuntoEtiquetas.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoConjuntoEtiquetas.Image")));
            this.btnNuevoConjuntoEtiquetas.Location = new System.Drawing.Point(318, 351);
            this.btnNuevoConjuntoEtiquetas.Name = "btnNuevoConjuntoEtiquetas";
            this.btnNuevoConjuntoEtiquetas.Size = new System.Drawing.Size(50, 50);
            this.btnNuevoConjuntoEtiquetas.TabIndex = 43;
            this.btnNuevoConjuntoEtiquetas.UseVisualStyleBackColor = true;
            this.btnNuevoConjuntoEtiquetas.Click += new System.EventHandler(this.btnNuevoConjuntoEtiquetas_Click);
            // 
            // AsignarExpertosIL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 661);
            this.Controls.Add(this.btnNuevoConjuntoEtiquetas);
            this.Controls.Add(this.btnAgregarConjunto);
            this.Controls.Add(this.groupBoxConjuntosEtiquetas);
            this.Controls.Add(this.comboBoxProyectos);
            this.Controls.Add(this.btnNuevoExperto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBoxAsignados);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.groupBoxDisponible);
            this.Controls.Add(this.btnAgregar);
            this.Name = "AsignarExpertosIL";
            this.Text = "Asignar Expertos IL / AHP-IL";
            this.Load += new System.EventHandler(this.AsignarExpertosIL_Load);
            this.groupBoxAsignados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosEnProyecto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoEnProyectoViewModelBindingSource)).EndInit();
            this.groupBoxDisponible.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).EndInit();
            this.groupBoxConjuntosEtiquetas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConjuntoEtiquetas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conjuntoEtiquetasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxProyectos;
        private System.Windows.Forms.Button btnNuevoExperto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBoxAsignados;
        private System.Windows.Forms.DataGridView dataGridExpertosEnProyecto;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.GroupBox groupBoxDisponible;
        private System.Windows.Forms.DataGridView dataGridExpertosDisponibles;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.BindingSource expertoBindingSource;
        private System.Windows.Forms.GroupBox groupBoxConjuntosEtiquetas;
        private System.Windows.Forms.DataGridView dataGridConjuntoEtiquetas;
        private System.Windows.Forms.BindingSource expertoEnProyectoViewModelBindingSource;
        private System.Windows.Forms.BindingSource conjuntoEtiquetasBindingSource;
        private System.Windows.Forms.Button btnAgregarConjunto;
        private System.Windows.Forms.Button btnNuevoConjuntoEtiquetas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn conjuntoEtiquetasNombreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoYNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
    }
}