﻿namespace sisexperto
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
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objetivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyectoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridAlternativa = new System.Windows.Forms.DataGridView();
            this.gridCriterio = new System.Windows.Forms.DataGridView();
            this.matrizcriterioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.matrizalternativaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.consistente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consistenteDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrizcriterioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrizalternativaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(25, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(917, 190);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proyectos recientes sin valorar";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(79, 52);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "Valorar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.objetivoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.proyectoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(322, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(562, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cargarMatrices);
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.Width = 200;
            // 
            // objetivoDataGridViewTextBoxColumn
            // 
            this.objetivoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.objetivoDataGridViewTextBoxColumn.DataPropertyName = "objetivo";
            this.objetivoDataGridViewTextBoxColumn.HeaderText = "Objetivo";
            this.objetivoDataGridViewTextBoxColumn.Name = "objetivoDataGridViewTextBoxColumn";
            // 
            // proyectoBindingSource
            // 
            this.proyectoBindingSource.DataSource = typeof(sisexperto.proyecto);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridCriterio);
            this.groupBox2.Location = new System.Drawing.Point(25, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Matriz de Criterios";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridAlternativa);
            this.groupBox3.Location = new System.Drawing.Point(578, 249);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 167);
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
            this.Column5,
            this.consistenteDataGridViewTextBoxColumn1,
            this.Column4});
            this.gridAlternativa.DataSource = this.matrizalternativaBindingSource;
            this.gridAlternativa.Location = new System.Drawing.Point(6, 19);
            this.gridAlternativa.Name = "gridAlternativa";
            this.gridAlternativa.Size = new System.Drawing.Size(344, 150);
            this.gridAlternativa.TabIndex = 5;
            this.gridAlternativa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modificarAlternativa);
            // 
            // gridCriterio
            // 
            this.gridCriterio.AllowUserToDeleteRows = false;
            this.gridCriterio.AutoGenerateColumns = false;
            this.gridCriterio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCriterio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.consistente,
            this.Column1});
            this.gridCriterio.DataSource = this.matrizcriterioBindingSource;
            this.gridCriterio.Location = new System.Drawing.Point(48, 19);
            this.gridCriterio.Name = "gridCriterio";
            this.gridCriterio.Size = new System.Drawing.Size(243, 66);
            this.gridCriterio.TabIndex = 4;
            this.gridCriterio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modificarCriterio);
            // 
            // matrizcriterioBindingSource
            // 
            this.matrizcriterioBindingSource.DataSource = typeof(sisexperto.matriz_criterio);
            // 
            // matrizalternativaBindingSource
            // 
            this.matrizalternativaBindingSource.DataSource = typeof(sisexperto.matriz_alternativa);
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
            // Column5
            // 
            this.Column5.DataPropertyName = "id_matrizAlternativa";
            this.Column5.HeaderText = "Criterio";
            this.Column5.Name = "Column5";
            // 
            // consistenteDataGridViewTextBoxColumn1
            // 
            this.consistenteDataGridViewTextBoxColumn1.DataPropertyName = "consistente";
            this.consistenteDataGridViewTextBoxColumn1.HeaderText = "Consistente";
            this.consistenteDataGridViewTextBoxColumn1.Name = "consistenteDataGridViewTextBoxColumn1";
            this.consistenteDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.consistenteDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "id_matrizAlternativa";
            this.Column4.HeaderText = "Valorar";
            this.Column4.Name = "Column4";
            // 
            // ProyectosAsignados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 457);
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
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrizcriterioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrizalternativaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objetivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource proyectoBindingSource;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridCriterio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridAlternativa;
        private System.Windows.Forms.BindingSource matrizcriterioBindingSource;
        private System.Windows.Forms.BindingSource matrizalternativaBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistente;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistenteDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}