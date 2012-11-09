namespace sisExperto
{
    partial class ProyectosAsignados
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyectoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridCriterio = new System.Windows.Forms.DataGridView();
            this.consistente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.valoracionCriteriosPorExpertoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consistenciaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.expertoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expertoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criterioIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criterioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comparacionCriteriosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valoracionCriteriosPorExpertoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridAlternativa = new System.Windows.Forms.DataGridView();
            this.ComparacionAlternativasPorCriterio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consistenciaDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.valoracionAlternativasPorCriterioExpertoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valoracionCriteriosPorExpertoBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valoracionAlternativasPorCriterioExpertoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(25, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 190);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proyectos recientes sin valorar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView1.DataSource = this.proyectoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(463, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cargarMatrices);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Objetivo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Objetivo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // proyectoBindingSource
            // 
            this.proyectoBindingSource.DataSource = typeof(sisExperto.Entidades.Proyecto);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridCriterio);
            this.groupBox2.Location = new System.Drawing.Point(25, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Matriz de Criterios";
            // 
            // gridCriterio
            // 
            this.gridCriterio.AllowUserToDeleteRows = false;
            this.gridCriterio.AutoGenerateColumns = false;
            this.gridCriterio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCriterio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.consistente,
            this.Column1,
            this.valoracionCriteriosPorExpertoIdDataGridViewTextBoxColumn,
            this.consistenciaDataGridViewCheckBoxColumn,
            this.expertoIdDataGridViewTextBoxColumn,
            this.expertoDataGridViewTextBoxColumn,
            this.criterioIdDataGridViewTextBoxColumn,
            this.criterioDataGridViewTextBoxColumn,
            this.comparacionCriteriosDataGridViewTextBoxColumn});
            this.gridCriterio.DataSource = this.valoracionCriteriosPorExpertoBindingSource;
            this.gridCriterio.Location = new System.Drawing.Point(6, 19);
            this.gridCriterio.Name = "gridCriterio";
            this.gridCriterio.Size = new System.Drawing.Size(244, 66);
            this.gridCriterio.TabIndex = 4;
            this.gridCriterio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modificarCriterio);
            // 
            // consistente
            // 
            this.consistente.DataPropertyName = "consistente";
            this.consistente.HeaderText = "Consistente";
            this.consistente.Name = "consistente";
            this.consistente.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id_matrizCriterio";
            this.Column1.HeaderText = "Valorar";
            this.Column1.Name = "Column1";
            // 
            // valoracionCriteriosPorExpertoIdDataGridViewTextBoxColumn
            // 
            this.valoracionCriteriosPorExpertoIdDataGridViewTextBoxColumn.DataPropertyName = "ValoracionCriteriosPorExpertoId";
            this.valoracionCriteriosPorExpertoIdDataGridViewTextBoxColumn.HeaderText = "ValoracionCriteriosPorExpertoId";
            this.valoracionCriteriosPorExpertoIdDataGridViewTextBoxColumn.Name = "valoracionCriteriosPorExpertoIdDataGridViewTextBoxColumn";
            // 
            // consistenciaDataGridViewCheckBoxColumn
            // 
            this.consistenciaDataGridViewCheckBoxColumn.DataPropertyName = "Consistencia";
            this.consistenciaDataGridViewCheckBoxColumn.HeaderText = "Consistencia";
            this.consistenciaDataGridViewCheckBoxColumn.Name = "consistenciaDataGridViewCheckBoxColumn";
            // 
            // expertoIdDataGridViewTextBoxColumn
            // 
            this.expertoIdDataGridViewTextBoxColumn.DataPropertyName = "ExpertoId";
            this.expertoIdDataGridViewTextBoxColumn.HeaderText = "ExpertoId";
            this.expertoIdDataGridViewTextBoxColumn.Name = "expertoIdDataGridViewTextBoxColumn";
            // 
            // expertoDataGridViewTextBoxColumn
            // 
            this.expertoDataGridViewTextBoxColumn.DataPropertyName = "Experto";
            this.expertoDataGridViewTextBoxColumn.HeaderText = "Experto";
            this.expertoDataGridViewTextBoxColumn.Name = "expertoDataGridViewTextBoxColumn";
            // 
            // criterioIdDataGridViewTextBoxColumn
            // 
            this.criterioIdDataGridViewTextBoxColumn.DataPropertyName = "CriterioId";
            this.criterioIdDataGridViewTextBoxColumn.HeaderText = "CriterioId";
            this.criterioIdDataGridViewTextBoxColumn.Name = "criterioIdDataGridViewTextBoxColumn";
            // 
            // criterioDataGridViewTextBoxColumn
            // 
            this.criterioDataGridViewTextBoxColumn.DataPropertyName = "Criterio";
            this.criterioDataGridViewTextBoxColumn.HeaderText = "Criterio";
            this.criterioDataGridViewTextBoxColumn.Name = "criterioDataGridViewTextBoxColumn";
            // 
            // comparacionCriteriosDataGridViewTextBoxColumn
            // 
            this.comparacionCriteriosDataGridViewTextBoxColumn.DataPropertyName = "ComparacionCriterios";
            this.comparacionCriteriosDataGridViewTextBoxColumn.HeaderText = "ComparacionCriterios";
            this.comparacionCriteriosDataGridViewTextBoxColumn.Name = "comparacionCriteriosDataGridViewTextBoxColumn";
            // 
            // valoracionCriteriosPorExpertoBindingSource
            // 
            this.valoracionCriteriosPorExpertoBindingSource.DataSource = typeof(sisExperto.Entidades.ValoracionCriteriosPorExperto);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridAlternativa);
            this.groupBox3.Location = new System.Drawing.Point(25, 355);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 167);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Matrices de Alternativas";
            // 
            // gridAlternativa
            // 
            this.gridAlternativa.AllowUserToDeleteRows = false;
            this.gridAlternativa.AutoGenerateColumns = false;
            this.gridAlternativa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAlternativa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComparacionAlternativasPorCriterio,
            this.consistenciaDataGridViewCheckBoxColumn1,
            this.Column4});
            this.gridAlternativa.DataSource = this.valoracionAlternativasPorCriterioExpertoBindingSource;
            this.gridAlternativa.Location = new System.Drawing.Point(6, 19);
            this.gridAlternativa.Name = "gridAlternativa";
            this.gridAlternativa.Size = new System.Drawing.Size(452, 150);
            this.gridAlternativa.TabIndex = 5;
            this.gridAlternativa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modificarAlternativa);
            // 
            // ComparacionAlternativasPorCriterio
            // 
            this.ComparacionAlternativasPorCriterio.DataPropertyName = "ComparacionAlternativasPorCriterio";
            this.ComparacionAlternativasPorCriterio.HeaderText = "ComparacionAlternativasPorCriterio";
            this.ComparacionAlternativasPorCriterio.Name = "ComparacionAlternativasPorCriterio";
            // 
            // consistenciaDataGridViewCheckBoxColumn1
            // 
            this.consistenciaDataGridViewCheckBoxColumn1.DataPropertyName = "Consistencia";
            this.consistenciaDataGridViewCheckBoxColumn1.HeaderText = "Consistencia";
            this.consistenciaDataGridViewCheckBoxColumn1.Name = "consistenciaDataGridViewCheckBoxColumn1";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "id_matrizAlternativa";
            this.Column4.HeaderText = "Valorar";
            this.Column4.Name = "Column4";
            // 
            // valoracionAlternativasPorCriterioExpertoBindingSource
            // 
            this.valoracionAlternativasPorCriterioExpertoBindingSource.DataSource = typeof(sisExperto.Entidades.ValoracionAlternativasPorCriterioExperto);
            // 
            // ProyectosAsignados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 539);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "ProyectosAsignados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Proyectos asignados";
            this.Load += new System.EventHandler(this.ProyectosAsignados_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valoracionCriteriosPorExpertoBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valoracionAlternativasPorCriterioExpertoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objetivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridCriterio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridAlternativa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistente;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistenteDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmatrizCriterioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproyectoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idExpertoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn consistenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valoracionCriteriosPorExpertoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistenciaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expertoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expertoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn criterioIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn criterioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comparacionCriteriosDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource valoracionCriteriosPorExpertoBindingSource;
        private System.Windows.Forms.BindingSource valoracionAlternativasPorCriterioExpertoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparacionAlternativasPorCriterio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistenciaDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource proyectoBindingSource;
    }
}