namespace sisExperto
{
    partial class FrmPrincipal
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
            this.proyectosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxProyectos = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonProyectoEdicion = new System.Windows.Forms.Button();
            this.dataGridProyectos = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objetivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyectoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filtroProyecto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPublicar = new System.Windows.Forms.Button();
            this.groupBoxDetalleProyecto = new System.Windows.Forms.GroupBox();
            this.dataGridExpertosAsignados = new System.Windows.Forms.DataGridView();
            this.apellidoNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.creadorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.expertoEnProyectoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridCriterios = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criterioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridAlternativas = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alternativaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelEstadoProyecto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.proyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alternativasYCriteriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conjuntosDeEtiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.expertosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ponderarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aHPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ahp_ponderadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ahp_mediaGeométricaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ahp_individualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.il_ponderadoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.il_mediaGeométricaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.il_ponderadoAHPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxProyectos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProyectos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).BeginInit();
            this.groupBoxDetalleProyecto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosAsignados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoEnProyectoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCriterios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.criterioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlternativas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // proyectosToolStripMenuItem
            // 
            this.proyectosToolStripMenuItem.Name = "proyectosToolStripMenuItem";
            this.proyectosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.proyectosToolStripMenuItem.Text = "Proyectos";
            // 
            // groupBoxProyectos
            // 
            this.groupBoxProyectos.Controls.Add(this.button1);
            this.groupBoxProyectos.Controls.Add(this.label2);
            this.groupBoxProyectos.Controls.Add(this.buttonProyectoEdicion);
            this.groupBoxProyectos.Controls.Add(this.dataGridProyectos);
            this.groupBoxProyectos.Controls.Add(this.filtroProyecto);
            this.groupBoxProyectos.Controls.Add(this.label1);
            this.groupBoxProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProyectos.Location = new System.Drawing.Point(12, 30);
            this.groupBoxProyectos.Name = "groupBoxProyectos";
            this.groupBoxProyectos.Size = new System.Drawing.Size(482, 680);
            this.groupBoxProyectos.TabIndex = 1;
            this.groupBoxProyectos.TabStop = false;
            this.groupBoxProyectos.Text = "Proyectos de Usuario";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 643);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Listado de Proyectos:";
            // 
            // buttonProyectoEdicion
            // 
            this.buttonProyectoEdicion.Location = new System.Drawing.Point(336, 643);
            this.buttonProyectoEdicion.Name = "buttonProyectoEdicion";
            this.buttonProyectoEdicion.Size = new System.Drawing.Size(140, 30);
            this.buttonProyectoEdicion.TabIndex = 4;
            this.buttonProyectoEdicion.Text = "Valorar Proyecto";
            this.buttonProyectoEdicion.UseVisualStyleBackColor = true;
            this.buttonProyectoEdicion.Click += new System.EventHandler(this.buttonProyectoEdicionExpertos_Click);
            // 
            // dataGridProyectos
            // 
            this.dataGridProyectos.AllowUserToAddRows = false;
            this.dataGridProyectos.AllowUserToDeleteRows = false;
            this.dataGridProyectos.AllowUserToResizeRows = false;
            this.dataGridProyectos.AutoGenerateColumns = false;
            this.dataGridProyectos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProyectos.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProyectos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.Tipo,
            this.objetivoDataGridViewTextBoxColumn});
            this.dataGridProyectos.DataSource = this.proyectoBindingSource;
            this.dataGridProyectos.Location = new System.Drawing.Point(7, 114);
            this.dataGridProyectos.MultiSelect = false;
            this.dataGridProyectos.Name = "dataGridProyectos";
            this.dataGridProyectos.ReadOnly = true;
            this.dataGridProyectos.RowHeadersVisible = false;
            this.dataGridProyectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProyectos.Size = new System.Drawing.Size(469, 523);
            this.dataGridProyectos.TabIndex = 2;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // objetivoDataGridViewTextBoxColumn
            // 
            this.objetivoDataGridViewTextBoxColumn.DataPropertyName = "Objetivo";
            this.objetivoDataGridViewTextBoxColumn.HeaderText = "Objetivo";
            this.objetivoDataGridViewTextBoxColumn.Name = "objetivoDataGridViewTextBoxColumn";
            this.objetivoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // proyectoBindingSource
            // 
            this.proyectoBindingSource.DataSource = typeof(sisExperto.Entidades.Proyecto);
            // 
            // filtroProyecto
            // 
            this.filtroProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtroProyecto.Location = new System.Drawing.Point(6, 53);
            this.filtroProyecto.Name = "filtroProyecto";
            this.filtroProyecto.Size = new System.Drawing.Size(470, 23);
            this.filtroProyecto.TabIndex = 1;
            this.filtroProyecto.Text = "Ingrese los filtros de búsqueda aquí";
            this.filtroProyecto.Enter += new System.EventHandler(this.filtroProyecto_Enter);
            this.filtroProyecto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filtroProyecto_KeyDown);
            this.filtroProyecto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filtroProyecto_KeyUp);
            this.filtroProyecto.Leave += new System.EventHandler(this.filtroProyecto_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Proyectos:";
            // 
            // buttonPublicar
            // 
            this.buttonPublicar.Enabled = false;
            this.buttonPublicar.Location = new System.Drawing.Point(336, 45);
            this.buttonPublicar.Name = "buttonPublicar";
            this.buttonPublicar.Size = new System.Drawing.Size(140, 30);
            this.buttonPublicar.TabIndex = 6;
            this.buttonPublicar.Text = "Publicar";
            this.buttonPublicar.UseVisualStyleBackColor = true;
            this.buttonPublicar.Click += new System.EventHandler(this.buttonPublicar_Click);
            // 
            // groupBoxDetalleProyecto
            // 
            this.groupBoxDetalleProyecto.Controls.Add(this.dataGridExpertosAsignados);
            this.groupBoxDetalleProyecto.Controls.Add(this.buttonPublicar);
            this.groupBoxDetalleProyecto.Controls.Add(this.label6);
            this.groupBoxDetalleProyecto.Controls.Add(this.label4);
            this.groupBoxDetalleProyecto.Controls.Add(this.label5);
            this.groupBoxDetalleProyecto.Controls.Add(this.dataGridCriterios);
            this.groupBoxDetalleProyecto.Controls.Add(this.dataGridAlternativas);
            this.groupBoxDetalleProyecto.Controls.Add(this.labelEstadoProyecto);
            this.groupBoxDetalleProyecto.Controls.Add(this.label3);
            this.groupBoxDetalleProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDetalleProyecto.Location = new System.Drawing.Point(514, 30);
            this.groupBoxDetalleProyecto.Name = "groupBoxDetalleProyecto";
            this.groupBoxDetalleProyecto.Size = new System.Drawing.Size(482, 680);
            this.groupBoxDetalleProyecto.TabIndex = 2;
            this.groupBoxDetalleProyecto.TabStop = false;
            this.groupBoxDetalleProyecto.Text = "Detalle del Proyecto";
            // 
            // dataGridExpertosAsignados
            // 
            this.dataGridExpertosAsignados.AllowUserToAddRows = false;
            this.dataGridExpertosAsignados.AllowUserToDeleteRows = false;
            this.dataGridExpertosAsignados.AllowUserToResizeRows = false;
            this.dataGridExpertosAsignados.AutoGenerateColumns = false;
            this.dataGridExpertosAsignados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridExpertosAsignados.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridExpertosAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpertosAsignados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.apellidoNombreDataGridViewTextBoxColumn,
            this.Activo,
            this.creadorDataGridViewCheckBoxColumn});
            this.dataGridExpertosAsignados.DataSource = this.expertoEnProyectoBindingSource;
            this.dataGridExpertosAsignados.Location = new System.Drawing.Point(10, 473);
            this.dataGridExpertosAsignados.Name = "dataGridExpertosAsignados";
            this.dataGridExpertosAsignados.ReadOnly = true;
            this.dataGridExpertosAsignados.RowHeadersVisible = false;
            this.dataGridExpertosAsignados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridExpertosAsignados.Size = new System.Drawing.Size(466, 200);
            this.dataGridExpertosAsignados.TabIndex = 7;
            // 
            // apellidoNombreDataGridViewTextBoxColumn
            // 
            this.apellidoNombreDataGridViewTextBoxColumn.DataPropertyName = "ApellidoNombre";
            this.apellidoNombreDataGridViewTextBoxColumn.FillWeight = 65F;
            this.apellidoNombreDataGridViewTextBoxColumn.HeaderText = "Apellido y Nombre";
            this.apellidoNombreDataGridViewTextBoxColumn.Name = "apellidoNombreDataGridViewTextBoxColumn";
            this.apellidoNombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Activo
            // 
            this.Activo.DataPropertyName = "Activo";
            this.Activo.FillWeight = 15F;
            this.Activo.HeaderText = "Activo";
            this.Activo.Name = "Activo";
            this.Activo.ReadOnly = true;
            // 
            // creadorDataGridViewCheckBoxColumn
            // 
            this.creadorDataGridViewCheckBoxColumn.DataPropertyName = "Creador";
            this.creadorDataGridViewCheckBoxColumn.FillWeight = 20F;
            this.creadorDataGridViewCheckBoxColumn.HeaderText = "Creador";
            this.creadorDataGridViewCheckBoxColumn.Name = "creadorDataGridViewCheckBoxColumn";
            this.creadorDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // expertoEnProyectoBindingSource
            // 
            this.expertoEnProyectoBindingSource.DataSource = typeof(sisExperto.Entidades.ExpertoEnProyecto);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 450);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Expertos Asignados:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Criterios:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Alternativas:";
            // 
            // dataGridCriterios
            // 
            this.dataGridCriterios.AllowUserToAddRows = false;
            this.dataGridCriterios.AllowUserToDeleteRows = false;
            this.dataGridCriterios.AllowUserToResizeRows = false;
            this.dataGridCriterios.AutoGenerateColumns = false;
            this.dataGridCriterios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCriterios.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridCriterios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCriterios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn2,
            this.descripcionDataGridViewTextBoxColumn1});
            this.dataGridCriterios.DataSource = this.criterioBindingSource;
            this.dataGridCriterios.Location = new System.Drawing.Point(246, 114);
            this.dataGridCriterios.Name = "dataGridCriterios";
            this.dataGridCriterios.ReadOnly = true;
            this.dataGridCriterios.RowHeadersVisible = false;
            this.dataGridCriterios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCriterios.Size = new System.Drawing.Size(230, 320);
            this.dataGridCriterios.TabIndex = 4;
            // 
            // nombreDataGridViewTextBoxColumn2
            // 
            this.nombreDataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn2.Name = "nombreDataGridViewTextBoxColumn2";
            this.nombreDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn1
            // 
            this.descripcionDataGridViewTextBoxColumn1.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn1.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn1.Name = "descripcionDataGridViewTextBoxColumn1";
            this.descripcionDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // criterioBindingSource
            // 
            this.criterioBindingSource.DataSource = typeof(sisExperto.Entidades.Criterio);
            // 
            // dataGridAlternativas
            // 
            this.dataGridAlternativas.AllowUserToAddRows = false;
            this.dataGridAlternativas.AllowUserToDeleteRows = false;
            this.dataGridAlternativas.AllowUserToResizeRows = false;
            this.dataGridAlternativas.AutoGenerateColumns = false;
            this.dataGridAlternativas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAlternativas.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridAlternativas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAlternativas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn1,
            this.descripcionDataGridViewTextBoxColumn});
            this.dataGridAlternativas.DataSource = this.alternativaBindingSource;
            this.dataGridAlternativas.Location = new System.Drawing.Point(10, 114);
            this.dataGridAlternativas.Name = "dataGridAlternativas";
            this.dataGridAlternativas.ReadOnly = true;
            this.dataGridAlternativas.RowHeadersVisible = false;
            this.dataGridAlternativas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAlternativas.Size = new System.Drawing.Size(230, 320);
            this.dataGridAlternativas.TabIndex = 2;
            // 
            // nombreDataGridViewTextBoxColumn1
            // 
            this.nombreDataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn1.Name = "nombreDataGridViewTextBoxColumn1";
            this.nombreDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alternativaBindingSource
            // 
            this.alternativaBindingSource.DataSource = typeof(sisExperto.Entidades.Alternativa);
            // 
            // labelEstadoProyecto
            // 
            this.labelEstadoProyecto.AutoSize = true;
            this.labelEstadoProyecto.Location = new System.Drawing.Point(50, 50);
            this.labelEstadoProyecto.Name = "labelEstadoProyecto";
            this.labelEstadoProyecto.Size = new System.Drawing.Size(237, 20);
            this.labelEstadoProyecto.TabIndex = 2;
            this.labelEstadoProyecto.Text = "- ningun proyecto seleccionado -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Estado del Proyecto:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proyectoToolStripMenuItem,
            this.expertosToolStripMenuItem,
            this.sesionToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // proyectoToolStripMenuItem
            // 
            this.proyectoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.alternativasYCriteriosToolStripMenuItem,
            this.conjuntosDeEtiquetasToolStripMenuItem,
            this.expertosToolStripMenuItem1,
            this.ejecutarToolStripMenuItem1});
            this.proyectoToolStripMenuItem.Name = "proyectoToolStripMenuItem";
            this.proyectoToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.proyectoToolStripMenuItem.Text = "Proyecto";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // alternativasYCriteriosToolStripMenuItem
            // 
            this.alternativasYCriteriosToolStripMenuItem.Enabled = false;
            this.alternativasYCriteriosToolStripMenuItem.Name = "alternativasYCriteriosToolStripMenuItem";
            this.alternativasYCriteriosToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.alternativasYCriteriosToolStripMenuItem.Text = "Alternativas y criterios";
            this.alternativasYCriteriosToolStripMenuItem.Click += new System.EventHandler(this.alternativasYCriteriosToolStripMenuItem_Click);
            // 
            // conjuntosDeEtiquetasToolStripMenuItem
            // 
            this.conjuntosDeEtiquetasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearToolStripMenuItem1});
            this.conjuntosDeEtiquetasToolStripMenuItem.Enabled = false;
            this.conjuntosDeEtiquetasToolStripMenuItem.Name = "conjuntosDeEtiquetasToolStripMenuItem";
            this.conjuntosDeEtiquetasToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.conjuntosDeEtiquetasToolStripMenuItem.Text = "Conjuntos de etiquetas";
            // 
            // crearToolStripMenuItem1
            // 
            this.crearToolStripMenuItem1.Name = "crearToolStripMenuItem1";
            this.crearToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.crearToolStripMenuItem1.Text = "Crear";
            this.crearToolStripMenuItem1.Click += new System.EventHandler(this.crearToolStripMenuItem1_Click);
            // 
            // expertosToolStripMenuItem1
            // 
            this.expertosToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem1,
            this.ponderarToolStripMenuItem});
            this.expertosToolStripMenuItem1.Enabled = false;
            this.expertosToolStripMenuItem1.Name = "expertosToolStripMenuItem1";
            this.expertosToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.expertosToolStripMenuItem1.Text = "Expertos";
            // 
            // editarToolStripMenuItem1
            // 
            this.editarToolStripMenuItem1.Name = "editarToolStripMenuItem1";
            this.editarToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.editarToolStripMenuItem1.Text = "Editar";
            this.editarToolStripMenuItem1.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // ponderarToolStripMenuItem
            // 
            this.ponderarToolStripMenuItem.Name = "ponderarToolStripMenuItem";
            this.ponderarToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.ponderarToolStripMenuItem.Text = "Ponderar";
            this.ponderarToolStripMenuItem.Click += new System.EventHandler(this.ponderarToolStripMenuItem_Click);
            // 
            // ejecutarToolStripMenuItem1
            // 
            this.ejecutarToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aHPToolStripMenuItem,
            this.iLToolStripMenuItem1});
            this.ejecutarToolStripMenuItem1.Enabled = false;
            this.ejecutarToolStripMenuItem1.Name = "ejecutarToolStripMenuItem1";
            this.ejecutarToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.ejecutarToolStripMenuItem1.Text = "Ejecutar";
            // 
            // aHPToolStripMenuItem
            // 
            this.aHPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ahp_ponderadoToolStripMenuItem,
            this.ahp_mediaGeométricaToolStripMenuItem,
            this.ahp_individualToolStripMenuItem});
            this.aHPToolStripMenuItem.Name = "aHPToolStripMenuItem";
            this.aHPToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aHPToolStripMenuItem.Text = "AHP";
            // 
            // ahp_ponderadoToolStripMenuItem
            // 
            this.ahp_ponderadoToolStripMenuItem.Name = "ahp_ponderadoToolStripMenuItem";
            this.ahp_ponderadoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.ahp_ponderadoToolStripMenuItem.Text = "Ponderado";
            this.ahp_ponderadoToolStripMenuItem.Click += new System.EventHandler(this.ahp_ponderadoToolStripMenuItem_Click);
            // 
            // ahp_mediaGeométricaToolStripMenuItem
            // 
            this.ahp_mediaGeométricaToolStripMenuItem.Name = "ahp_mediaGeométricaToolStripMenuItem";
            this.ahp_mediaGeométricaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.ahp_mediaGeométricaToolStripMenuItem.Text = "Media geométrica";
            this.ahp_mediaGeométricaToolStripMenuItem.Click += new System.EventHandler(this.ahp_mediaGeométricaToolStripMenuItem_Click);
            // 
            // ahp_individualToolStripMenuItem
            // 
            this.ahp_individualToolStripMenuItem.Name = "ahp_individualToolStripMenuItem";
            this.ahp_individualToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.ahp_individualToolStripMenuItem.Text = "Individual";
            this.ahp_individualToolStripMenuItem.Click += new System.EventHandler(this.ahp_individualToolStripMenuItem_Click);
            // 
            // iLToolStripMenuItem1
            // 
            this.iLToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.il_ponderadoToolStripMenuItem1,
            this.il_mediaGeométricaToolStripMenuItem1,
            this.il_ponderadoAHPToolStripMenuItem});
            this.iLToolStripMenuItem1.Name = "iLToolStripMenuItem1";
            this.iLToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.iLToolStripMenuItem1.Text = "IL";
            // 
            // il_ponderadoToolStripMenuItem1
            // 
            this.il_ponderadoToolStripMenuItem1.Name = "il_ponderadoToolStripMenuItem1";
            this.il_ponderadoToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.il_ponderadoToolStripMenuItem1.Text = "Ponderado";
            this.il_ponderadoToolStripMenuItem1.Click += new System.EventHandler(this.il_ponderadoToolStripMenuItem1_Click);
            // 
            // il_mediaGeométricaToolStripMenuItem1
            // 
            this.il_mediaGeométricaToolStripMenuItem1.Name = "il_mediaGeométricaToolStripMenuItem1";
            this.il_mediaGeométricaToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.il_mediaGeométricaToolStripMenuItem1.Text = "Media geométrica";
            this.il_mediaGeométricaToolStripMenuItem1.Click += new System.EventHandler(this.il_mediaGeométricaToolStripMenuItem1_Click);
            // 
            // il_ponderadoAHPToolStripMenuItem
            // 
            this.il_ponderadoAHPToolStripMenuItem.Name = "il_ponderadoAHPToolStripMenuItem";
            this.il_ponderadoAHPToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.il_ponderadoAHPToolStripMenuItem.Text = "Ponderado AHP";
            this.il_ponderadoAHPToolStripMenuItem.Click += new System.EventHandler(this.il_ponderadoAHPToolStripMenuItem_Click);
            // 
            // expertosToolStripMenuItem
            // 
            this.expertosToolStripMenuItem.Name = "expertosToolStripMenuItem";
            this.expertosToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.expertosToolStripMenuItem.Text = "Expertos";
            this.expertosToolStripMenuItem.Click += new System.EventHandler(this.expertosToolStripMenuItem_Click);
            // 
            // sesionToolStripMenuItem
            // 
            this.sesionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarSesionToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.sesionToolStripMenuItem.Name = "sesionToolStripMenuItem";
            this.sesionToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.sesionToolStripMenuItem.Text = "Sesion";
            // 
            // iniciarSesionToolStripMenuItem
            // 
            this.iniciarSesionToolStripMenuItem.Name = "iniciarSesionToolStripMenuItem";
            this.iniciarSesionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.iniciarSesionToolStripMenuItem.Text = "Iniciar Sesion";
            this.iniciarSesionToolStripMenuItem.Click += new System.EventHandler(this.iniciarSesionToolStripMenuItem_Click_1);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Enabled = false;
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Experto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Experto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 154;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Experto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Experto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 463;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 719);
            this.Controls.Add(this.groupBoxDetalleProyecto);
            this.Controls.Add(this.groupBoxProyectos);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1022, 726);
            this.Name = "FrmPrincipal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SisExperto";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.groupBoxProyectos.ResumeLayout(false);
            this.groupBoxProyectos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProyectos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).EndInit();
            this.groupBoxDetalleProyecto.ResumeLayout(false);
            this.groupBoxDetalleProyecto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosAsignados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoEnProyectoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCriterios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.criterioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlternativas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem proyectosToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxProyectos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxDetalleProyecto;
        private System.Windows.Forms.Button buttonProyectoEdicion;
        private System.Windows.Forms.DataGridView dataGridProyectos;
        private System.Windows.Forms.TextBox filtroProyecto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridCriterios;
        private System.Windows.Forms.DataGridView dataGridAlternativas;
        private System.Windows.Forms.Label labelEstadoProyecto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource proyectoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource criterioBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource alternativaBindingSource;
        private System.Windows.Forms.ToolStripMenuItem expertosToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn objetivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem proyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ponderarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alternativasYCriteriosToolStripMenuItem;
        private System.Windows.Forms.Button buttonPublicar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource expertoEnProyectoBindingSource;
        private System.Windows.Forms.DataGridView dataGridExpertosAsignados;
        private System.Windows.Forms.ToolStripMenuItem conjuntosDeEtiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aHPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ahp_ponderadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ahp_mediaGeométricaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ahp_individualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iLToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem il_ponderadoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem il_mediaGeométricaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem crearToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn creadorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem il_ponderadoAHPToolStripMenuItem;



    }
}