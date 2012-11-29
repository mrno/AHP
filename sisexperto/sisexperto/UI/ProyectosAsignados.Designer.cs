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
            this.Criterio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.valorarAlt = new System.Windows.Forms.DataGridViewButtonColumn();
            this.alternativaMatrizBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxProyectos = new System.Windows.Forms.ComboBox();
            this.proyectoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.buttonValorarCriterio = new System.Windows.Forms.Button();
            this.buttonVerMatrizCriterio = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxConsistencia = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaMatrizBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridAlternativa);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 113);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(500, 336);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Valoración de Alternativas:";
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
            this.dataGridViewCheckBoxColumn2,
            this.valorarAlt});
            this.gridAlternativa.DataSource = this.alternativaMatrizBindingSource;
            this.gridAlternativa.Location = new System.Drawing.Point(6, 25);
            this.gridAlternativa.Name = "gridAlternativa";
            this.gridAlternativa.ReadOnly = true;
            this.gridAlternativa.RowHeadersVisible = false;
            this.gridAlternativa.Size = new System.Drawing.Size(488, 305);
            this.gridAlternativa.TabIndex = 5;
            this.gridAlternativa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modificarAlternativa);
            // 
            // Criterio
            // 
            this.Criterio.HeaderText = "Criterio";
            this.Criterio.Name = "Criterio";
            this.Criterio.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "Consistencia";
            this.dataGridViewCheckBoxColumn2.HeaderText = "Consistente";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            // 
            // valorarAlt
            // 
            this.valorarAlt.HeaderText = "Valorar Alternativa";
            this.valorarAlt.Name = "valorarAlt";
            this.valorarAlt.ReadOnly = true;
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
            this.comboBoxProyectos.Size = new System.Drawing.Size(419, 28);
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
            this.buttonValorarCriterio.Size = new System.Drawing.Size(140, 30);
            this.buttonValorarCriterio.TabIndex = 34;
            this.buttonValorarCriterio.Text = "Valorar Criterios";
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
            this.buttonVerMatrizCriterio.Click += new System.EventHandler(this.buttonVerMatrizCriterio_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxConsistencia);
            this.groupBox1.Controls.Add(this.buttonValorarCriterio);
            this.groupBox1.Controls.Add(this.buttonVerMatrizCriterio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 62);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valoración de Criterios:";
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
            // ProyectosAsignados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 461);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxProyectos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistenciaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expertoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expertoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn criterioIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn criterioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comparacionCriteriosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistenciaDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.BindingSource alternativaMatrizBindingSource;
        private System.Windows.Forms.ComboBox comboBoxProyectos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonValorarCriterio;
        private System.Windows.Forms.Button buttonVerMatrizCriterio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxConsistencia;
        private System.Windows.Forms.BindingSource proyectoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Criterio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn valorarAlt;
    }
}