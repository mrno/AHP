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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridAlternativa = new System.Windows.Forms.DataGridView();
            this.alternativaMatrizBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxProyectos = new System.Windows.Forms.ComboBox();
            this.proyectoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.buttonValorarCriterio = new System.Windows.Forms.Button();
            this.buttonVerMatrizCriterio = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxConsistencia = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAHP = new System.Windows.Forms.TabPage();
            this.tabPageIL = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridCriterios = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alternativaILIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorCriteriosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alternativaILBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Criterio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consistenciaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.valorarAlt = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaMatrizBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageAHP.SuspendLayout();
            this.tabPageIL.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaILBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridAlternativa);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(7, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(500, 263);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Comparacion de Alternativas:";
            // 
            // gridAlternativa
            // 
            this.gridAlternativa.AllowUserToAddRows = false;
            this.gridAlternativa.AllowUserToDeleteRows = false;
            this.gridAlternativa.AutoGenerateColumns = false;
            this.gridAlternativa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAlternativa.BackgroundColor = System.Drawing.Color.LightGray;
            this.gridAlternativa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAlternativa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Criterio,
            this.consistenciaDataGridViewCheckBoxColumn,
            this.valorarAlt});
            this.gridAlternativa.DataSource = this.alternativaMatrizBindingSource;
            this.gridAlternativa.Location = new System.Drawing.Point(6, 25);
            this.gridAlternativa.Name = "gridAlternativa";
            this.gridAlternativa.ReadOnly = true;
            this.gridAlternativa.RowHeadersVisible = false;
            this.gridAlternativa.Size = new System.Drawing.Size(488, 232);
            this.gridAlternativa.TabIndex = 5;
            this.gridAlternativa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modificarAlternativa);
            // 
            // alternativaMatrizBindingSource
            // 
            this.alternativaMatrizBindingSource.DataSource = typeof(sisexperto.Entidades.AlternativaMatriz);
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
            this.comboBoxProyectos.Size = new System.Drawing.Size(436, 28);
            this.comboBoxProyectos.TabIndex = 32;
            // 
            // proyectoBindingSource
            // 
            this.proyectoBindingSource.DataSource = typeof(sisExperto.Entidades.Proyecto);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Proyecto:";
            // 
            // buttonValorarCriterio
            // 
            this.buttonValorarCriterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonValorarCriterio.Location = new System.Drawing.Point(204, 21);
            this.buttonValorarCriterio.Name = "buttonValorarCriterio";
            this.buttonValorarCriterio.Size = new System.Drawing.Size(140, 56);
            this.buttonValorarCriterio.TabIndex = 34;
            this.buttonValorarCriterio.Text = "Comparacion entre Criterios";
            this.buttonValorarCriterio.UseVisualStyleBackColor = true;
            this.buttonValorarCriterio.Click += new System.EventHandler(this.buttonValorarCriterio_Click);
            // 
            // buttonVerMatrizCriterio
            // 
            this.buttonVerMatrizCriterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVerMatrizCriterio.Location = new System.Drawing.Point(350, 21);
            this.buttonVerMatrizCriterio.Name = "buttonVerMatrizCriterio";
            this.buttonVerMatrizCriterio.Size = new System.Drawing.Size(140, 30);
            this.buttonVerMatrizCriterio.TabIndex = 35;
            this.buttonVerMatrizCriterio.Text = "Ver Matriz";
            this.buttonVerMatrizCriterio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxConsistencia);
            this.groupBox1.Controls.Add(this.buttonValorarCriterio);
            this.groupBox1.Controls.Add(this.buttonVerMatrizCriterio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 84);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comparacion de Criterios:";
            // 
            // checkBoxConsistencia
            // 
            this.checkBoxConsistencia.AutoCheck = false;
            this.checkBoxConsistencia.AutoSize = true;
            this.checkBoxConsistencia.Location = new System.Drawing.Point(6, 25);
            this.checkBoxConsistencia.Name = "checkBoxConsistencia";
            this.checkBoxConsistencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxConsistencia.Size = new System.Drawing.Size(183, 24);
            this.checkBoxConsistencia.TabIndex = 36;
            this.checkBoxConsistencia.Text = ":Valores Consistentes";
            this.checkBoxConsistencia.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAHP);
            this.tabControl1.Controls.Add(this.tabPageIL);
            this.tabControl1.Location = new System.Drawing.Point(5, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 401);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPageAHP
            // 
            this.tabPageAHP.Controls.Add(this.groupBox1);
            this.tabPageAHP.Controls.Add(this.groupBox3);
            this.tabPageAHP.Location = new System.Drawing.Point(4, 22);
            this.tabPageAHP.Name = "tabPageAHP";
            this.tabPageAHP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAHP.Size = new System.Drawing.Size(520, 375);
            this.tabPageAHP.TabIndex = 0;
            this.tabPageAHP.Text = "AHP";
            this.tabPageAHP.UseVisualStyleBackColor = true;
            // 
            // tabPageIL
            // 
            this.tabPageIL.Controls.Add(this.groupBox2);
            this.tabPageIL.Location = new System.Drawing.Point(4, 22);
            this.tabPageIL.Name = "tabPageIL";
            this.tabPageIL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIL.Size = new System.Drawing.Size(520, 375);
            this.tabPageIL.TabIndex = 1;
            this.tabPageIL.Text = "IL";
            this.tabPageIL.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridCriterios);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 349);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Valoraciones";
            // 
            // gridCriterios
            // 
            this.gridCriterios.AllowUserToDeleteRows = false;
            this.gridCriterios.AutoGenerateColumns = false;
            this.gridCriterios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCriterios.BackgroundColor = System.Drawing.Color.LightGray;
            this.gridCriterios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCriterios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn2,
            this.dataGridViewTextBoxColumn1,
            this.alternativaILIdDataGridViewTextBoxColumn,
            this.valorCriteriosDataGridViewTextBoxColumn});
            this.gridCriterios.DataSource = this.alternativaILBindingSource;
            this.gridCriterios.Location = new System.Drawing.Point(6, 25);
            this.gridCriterios.Name = "gridCriterios";
            this.gridCriterios.ReadOnly = true;
            this.gridCriterios.RowHeadersVisible = false;
            this.gridCriterios.Size = new System.Drawing.Size(488, 318);
            this.gridCriterios.TabIndex = 5;
            this.gridCriterios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modificarAlternativasIL);
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Valorar Criterios";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Alternativa";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // alternativaILIdDataGridViewTextBoxColumn
            // 
            this.alternativaILIdDataGridViewTextBoxColumn.DataPropertyName = "AlternativaILId";
            this.alternativaILIdDataGridViewTextBoxColumn.HeaderText = "AlternativaILId";
            this.alternativaILIdDataGridViewTextBoxColumn.Name = "alternativaILIdDataGridViewTextBoxColumn";
            this.alternativaILIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorCriteriosDataGridViewTextBoxColumn
            // 
            this.valorCriteriosDataGridViewTextBoxColumn.DataPropertyName = "ValorCriterios";
            this.valorCriteriosDataGridViewTextBoxColumn.HeaderText = "ValorCriterios";
            this.valorCriteriosDataGridViewTextBoxColumn.Name = "valorCriteriosDataGridViewTextBoxColumn";
            this.valorCriteriosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alternativaILBindingSource
            // 
            this.alternativaILBindingSource.DataSource = typeof(sisexperto.Entidades.AlternativaIL);
            // 
            // Criterio
            // 
            this.Criterio.HeaderText = "Según Criterio";
            this.Criterio.Name = "Criterio";
            this.Criterio.ReadOnly = true;
            // 
            // consistenciaDataGridViewCheckBoxColumn
            // 
            this.consistenciaDataGridViewCheckBoxColumn.DataPropertyName = "Consistencia";
            this.consistenciaDataGridViewCheckBoxColumn.HeaderText = "Consistencia";
            this.consistenciaDataGridViewCheckBoxColumn.Name = "consistenciaDataGridViewCheckBoxColumn";
            this.consistenciaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // valorarAlt
            // 
            this.valorarAlt.HeaderText = "Compararacion entre Alternativas";
            this.valorarAlt.Name = "valorarAlt";
            this.valorarAlt.ReadOnly = true;
            // 
            // ProyectosAsignados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 445);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comboBoxProyectos);
            this.Controls.Add(this.label2);
            this.Name = "ProyectosAsignados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Valorar Proyecto";
            this.Load += new System.EventHandler(this.ProyectosAsignados_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaMatrizBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageAHP.ResumeLayout(false);
            this.tabPageIL.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaILBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objetivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridAlternativa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistenteDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmatrizCriterioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproyectoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idExpertoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn consistenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valoracionCriteriosPorExpertoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expertoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expertoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comparacionCriteriosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistenciaDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.ComboBox comboBoxProyectos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonValorarCriterio;
        private System.Windows.Forms.Button buttonVerMatrizCriterio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxConsistencia;
        private System.Windows.Forms.BindingSource proyectoBindingSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAHP;
        private System.Windows.Forms.TabPage tabPageIL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridCriterios;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn alternativaILIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorCriteriosDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource alternativaILBindingSource;
        private System.Windows.Forms.BindingSource alternativaMatrizBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Criterio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistenciaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn valorarAlt;
    }
}