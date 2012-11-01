namespace sisexperto
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
            this.proyectosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxProyectos = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonProyectoEdicion = new System.Windows.Forms.Button();
            this.buttonProyectoNuevo = new System.Windows.Forms.Button();
            this.dataGridProyectos = new System.Windows.Forms.DataGridView();
            this.filtroProyecto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxDetalleProyecto = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridCriterios = new System.Windows.Forms.DataGridView();
            this.dataGridAlternativas = new System.Windows.Forms.DataGridView();
            this.labelEstadoProyecto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridExpertosAsignados = new System.Windows.Forms.DataGridView();
            this.groupBoxProyectos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProyectos)).BeginInit();
            this.groupBoxDetalleProyecto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCriterios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlternativas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosAsignados)).BeginInit();
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
            this.groupBoxProyectos.Controls.Add(this.label2);
            this.groupBoxProyectos.Controls.Add(this.buttonProyectoEdicion);
            this.groupBoxProyectos.Controls.Add(this.buttonProyectoNuevo);
            this.groupBoxProyectos.Controls.Add(this.dataGridProyectos);
            this.groupBoxProyectos.Controls.Add(this.filtroProyecto);
            this.groupBoxProyectos.Controls.Add(this.label1);
            this.groupBoxProyectos.Controls.Add(this.button1);
            this.groupBoxProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProyectos.Location = new System.Drawing.Point(12, 30);
            this.groupBoxProyectos.Name = "groupBoxProyectos";
            this.groupBoxProyectos.Size = new System.Drawing.Size(482, 680);
            this.groupBoxProyectos.TabIndex = 1;
            this.groupBoxProyectos.TabStop = false;
            this.groupBoxProyectos.Text = "Proyectos de Usuario";
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
            this.buttonProyectoEdicion.Location = new System.Drawing.Point(156, 635);
            this.buttonProyectoEdicion.Name = "buttonProyectoEdicion";
            this.buttonProyectoEdicion.Size = new System.Drawing.Size(140, 30);
            this.buttonProyectoEdicion.TabIndex = 5;
            this.buttonProyectoEdicion.Text = "Editar";
            this.buttonProyectoEdicion.UseVisualStyleBackColor = true;
            this.buttonProyectoEdicion.Click += new System.EventHandler(this.buttonProyectoEdicion_Click);
            // 
            // buttonProyectoNuevo
            // 
            this.buttonProyectoNuevo.Location = new System.Drawing.Point(10, 635);
            this.buttonProyectoNuevo.Name = "buttonProyectoNuevo";
            this.buttonProyectoNuevo.Size = new System.Drawing.Size(140, 30);
            this.buttonProyectoNuevo.TabIndex = 4;
            this.buttonProyectoNuevo.Text = "Nuevo";
            this.buttonProyectoNuevo.UseVisualStyleBackColor = true;
            this.buttonProyectoNuevo.Click += new System.EventHandler(this.buttonProyectoNuevo_Click);
            // 
            // dataGridProyectos
            // 
            this.dataGridProyectos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProyectos.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProyectos.Location = new System.Drawing.Point(7, 114);
            this.dataGridProyectos.MultiSelect = false;
            this.dataGridProyectos.Name = "dataGridProyectos";
            this.dataGridProyectos.RowHeadersVisible = false;
            this.dataGridProyectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProyectos.Size = new System.Drawing.Size(469, 505);
            this.dataGridProyectos.TabIndex = 2;
            // 
            // filtroProyecto
            // 
            this.filtroProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtroProyecto.Location = new System.Drawing.Point(6, 53);
            this.filtroProyecto.Name = "filtroProyecto";
            this.filtroProyecto.Size = new System.Drawing.Size(470, 23);
            this.filtroProyecto.TabIndex = 0;
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
            // groupBoxDetalleProyecto
            // 
            this.groupBoxDetalleProyecto.Controls.Add(this.dataGridExpertosAsignados);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 6;
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
            this.dataGridCriterios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCriterios.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridCriterios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCriterios.Location = new System.Drawing.Point(246, 114);
            this.dataGridCriterios.Name = "dataGridCriterios";
            this.dataGridCriterios.RowHeadersVisible = false;
            this.dataGridCriterios.Size = new System.Drawing.Size(230, 320);
            this.dataGridCriterios.TabIndex = 1;
            // 
            // dataGridAlternativas
            // 
            this.dataGridAlternativas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAlternativas.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridAlternativas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAlternativas.Location = new System.Drawing.Point(10, 114);
            this.dataGridAlternativas.Name = "dataGridAlternativas";
            this.dataGridAlternativas.RowHeadersVisible = false;
            this.dataGridAlternativas.Size = new System.Drawing.Size(230, 320);
            this.dataGridAlternativas.TabIndex = 0;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 635);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Proyectos Asignados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sesionToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 450);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Expertos Asignados:";
            // 
            // dataGridExpertosAsignados
            // 
            this.dataGridExpertosAsignados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridExpertosAsignados.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridExpertosAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpertosAsignados.Location = new System.Drawing.Point(10, 473);
            this.dataGridExpertosAsignados.Name = "dataGridExpertosAsignados";
            this.dataGridExpertosAsignados.RowHeadersVisible = false;
            this.dataGridExpertosAsignados.Size = new System.Drawing.Size(466, 192);
            this.dataGridExpertosAsignados.TabIndex = 8;
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
            this.MinimumSize = new System.Drawing.Size(1024, 758);
            this.Name = "FrmPrincipal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.groupBoxProyectos.ResumeLayout(false);
            this.groupBoxProyectos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProyectos)).EndInit();
            this.groupBoxDetalleProyecto.ResumeLayout(false);
            this.groupBoxDetalleProyecto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCriterios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlternativas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosAsignados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem proyectosToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxProyectos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxDetalleProyecto;
        private System.Windows.Forms.Button buttonProyectoEdicion;
        private System.Windows.Forms.Button buttonProyectoNuevo;
        private System.Windows.Forms.DataGridView dataGridProyectos;
        private System.Windows.Forms.TextBox filtroProyecto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.DataGridView dataGridExpertosAsignados;



    }
}