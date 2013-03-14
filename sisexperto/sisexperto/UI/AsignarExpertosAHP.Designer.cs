namespace sisexperto.UI
{
    partial class AsignarExpertosAHP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignarExpertosAHP));
            this.groupBoxAsignados = new System.Windows.Forms.GroupBox();
            this.dataGridExpertosEnProyecto = new System.Windows.Forms.DataGridView();
            this.ApellidoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expertoEnProyectoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxDisponible = new System.Windows.Forms.GroupBox();
            this.dataGridExpertosDisponibles = new System.Windows.Forms.DataGridView();
            this.apellidoYNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expertoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.comboBoxProyectos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.expertoEnProyectoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.proyectoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expertoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ponderacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valoracionAHPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valoracionILDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creadorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.administradorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBoxAsignados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosEnProyecto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoEnProyectoBindingSource)).BeginInit();
            this.groupBoxDisponible.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAsignados
            // 
            this.groupBoxAsignados.Controls.Add(this.dataGridExpertosEnProyecto);
            this.groupBoxAsignados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAsignados.Location = new System.Drawing.Point(374, 40);
            this.groupBoxAsignados.Name = "groupBoxAsignados";
            this.groupBoxAsignados.Size = new System.Drawing.Size(300, 566);
            this.groupBoxAsignados.TabIndex = 14;
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
            this.expertoEnProyectoIdDataGridViewTextBoxColumn,
            this.activoDataGridViewCheckBoxColumn,
            this.proyectoDataGridViewTextBoxColumn,
            this.expertoDataGridViewTextBoxColumn,
            this.ponderacionDataGridViewTextBoxColumn,
            this.pesoDataGridViewTextBoxColumn,
            this.valoracionAHPDataGridViewTextBoxColumn,
            this.valoracionILDataGridViewTextBoxColumn,
            this.apellidoNombreDataGridViewTextBoxColumn,
            this.creadorDataGridViewCheckBoxColumn,
            this.administradorDataGridViewCheckBoxColumn});
            this.dataGridExpertosEnProyecto.DataSource = this.expertoEnProyectoBindingSource;
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
            this.ApellidoNombre.FillWeight = 149.2386F;
            this.ApellidoNombre.HeaderText = "ApellidoNombre";
            this.ApellidoNombre.Name = "ApellidoNombre";
            this.ApellidoNombre.ReadOnly = true;
            // 
            // expertoEnProyectoBindingSource
            // 
            this.expertoEnProyectoBindingSource.DataSource = typeof(sisExperto.Entidades.ExpertoEnProyecto);
            // 
            // groupBoxDisponible
            // 
            this.groupBoxDisponible.Controls.Add(this.dataGridExpertosDisponibles);
            this.groupBoxDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDisponible.Location = new System.Drawing.Point(12, 40);
            this.groupBoxDisponible.Name = "groupBoxDisponible";
            this.groupBoxDisponible.Size = new System.Drawing.Size(300, 566);
            this.groupBoxDisponible.TabIndex = 13;
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
            this.dataGridExpertosDisponibles.Size = new System.Drawing.Size(288, 535);
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
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(318, 65);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(50, 50);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.Location = new System.Drawing.Point(318, 177);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(50, 50);
            this.btnQuitar.TabIndex = 3;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(318, 121);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(50, 50);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardar.Location = new System.Drawing.Point(243, 619);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(140, 30);
            this.buttonGuardar.TabIndex = 15;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(535, 619);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 30);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(389, 619);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 30);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar y Salir";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.comboBoxProyectos.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Proyecto:";
            // 
            // expertoEnProyectoIdDataGridViewTextBoxColumn
            // 
            this.expertoEnProyectoIdDataGridViewTextBoxColumn.DataPropertyName = "ExpertoEnProyectoId";
            this.expertoEnProyectoIdDataGridViewTextBoxColumn.HeaderText = "ExpertoEnProyectoId";
            this.expertoEnProyectoIdDataGridViewTextBoxColumn.Name = "expertoEnProyectoIdDataGridViewTextBoxColumn";
            this.expertoEnProyectoIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activoDataGridViewCheckBoxColumn
            // 
            this.activoDataGridViewCheckBoxColumn.DataPropertyName = "Activo";
            this.activoDataGridViewCheckBoxColumn.HeaderText = "Activo";
            this.activoDataGridViewCheckBoxColumn.Name = "activoDataGridViewCheckBoxColumn";
            this.activoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // proyectoDataGridViewTextBoxColumn
            // 
            this.proyectoDataGridViewTextBoxColumn.DataPropertyName = "Proyecto";
            this.proyectoDataGridViewTextBoxColumn.HeaderText = "Proyecto";
            this.proyectoDataGridViewTextBoxColumn.Name = "proyectoDataGridViewTextBoxColumn";
            this.proyectoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expertoDataGridViewTextBoxColumn
            // 
            this.expertoDataGridViewTextBoxColumn.DataPropertyName = "Experto";
            this.expertoDataGridViewTextBoxColumn.HeaderText = "Experto";
            this.expertoDataGridViewTextBoxColumn.Name = "expertoDataGridViewTextBoxColumn";
            this.expertoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ponderacionDataGridViewTextBoxColumn
            // 
            this.ponderacionDataGridViewTextBoxColumn.DataPropertyName = "Ponderacion";
            this.ponderacionDataGridViewTextBoxColumn.HeaderText = "Ponderacion";
            this.ponderacionDataGridViewTextBoxColumn.Name = "ponderacionDataGridViewTextBoxColumn";
            this.ponderacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pesoDataGridViewTextBoxColumn
            // 
            this.pesoDataGridViewTextBoxColumn.DataPropertyName = "Peso";
            this.pesoDataGridViewTextBoxColumn.HeaderText = "Peso";
            this.pesoDataGridViewTextBoxColumn.Name = "pesoDataGridViewTextBoxColumn";
            this.pesoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valoracionAHPDataGridViewTextBoxColumn
            // 
            this.valoracionAHPDataGridViewTextBoxColumn.DataPropertyName = "ValoracionAHP";
            this.valoracionAHPDataGridViewTextBoxColumn.HeaderText = "ValoracionAHP";
            this.valoracionAHPDataGridViewTextBoxColumn.Name = "valoracionAHPDataGridViewTextBoxColumn";
            this.valoracionAHPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valoracionILDataGridViewTextBoxColumn
            // 
            this.valoracionILDataGridViewTextBoxColumn.DataPropertyName = "ValoracionIL";
            this.valoracionILDataGridViewTextBoxColumn.HeaderText = "ValoracionIL";
            this.valoracionILDataGridViewTextBoxColumn.Name = "valoracionILDataGridViewTextBoxColumn";
            this.valoracionILDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // apellidoNombreDataGridViewTextBoxColumn
            // 
            this.apellidoNombreDataGridViewTextBoxColumn.DataPropertyName = "ApellidoNombre";
            this.apellidoNombreDataGridViewTextBoxColumn.HeaderText = "ApellidoNombre";
            this.apellidoNombreDataGridViewTextBoxColumn.Name = "apellidoNombreDataGridViewTextBoxColumn";
            this.apellidoNombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // creadorDataGridViewCheckBoxColumn
            // 
            this.creadorDataGridViewCheckBoxColumn.DataPropertyName = "Creador";
            this.creadorDataGridViewCheckBoxColumn.HeaderText = "Creador";
            this.creadorDataGridViewCheckBoxColumn.Name = "creadorDataGridViewCheckBoxColumn";
            this.creadorDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // administradorDataGridViewCheckBoxColumn
            // 
            this.administradorDataGridViewCheckBoxColumn.DataPropertyName = "Administrador";
            this.administradorDataGridViewCheckBoxColumn.HeaderText = "Administrador";
            this.administradorDataGridViewCheckBoxColumn.Name = "administradorDataGridViewCheckBoxColumn";
            this.administradorDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // AsignarExpertosAHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 661);
            this.Controls.Add(this.comboBoxProyectos);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBoxAsignados);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.groupBoxDisponible);
            this.Controls.Add(this.btnAgregar);
            this.Name = "AsignarExpertosAHP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asignar Expertos - Proyectos: AHP";
            this.Load += new System.EventHandler(this.AsignarExpertosAHP_Load);
            this.groupBoxAsignados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosEnProyecto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoEnProyectoBindingSource)).EndInit();
            this.groupBoxDisponible.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAsignados;
        private System.Windows.Forms.GroupBox groupBoxDisponible;
        private System.Windows.Forms.DataGridView dataGridExpertosDisponibles;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox comboBoxProyectos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource expertoEnProyectoBindingSource;
        private System.Windows.Forms.BindingSource expertoBindingSource;
        private System.Windows.Forms.DataGridView dataGridExpertosEnProyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoYNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn expertoEnProyectoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proyectoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expertoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ponderacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valoracionAHPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valoracionILDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn creadorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn administradorDataGridViewCheckBoxColumn;
    }
}