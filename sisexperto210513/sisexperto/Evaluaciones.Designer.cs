namespace sisExperto
{
    partial class Evaluaciones
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
            this.button1 = new System.Windows.Forms.Button();
            this.gridCriterio = new System.Windows.Forms.DataGridView();
            this.consistente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idmatrizCriterioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idproyectoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idExpertoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consistenteDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matrizCriterioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridAlternativa = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idmatrizAlternativaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idproyectoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idExpertoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCriterioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consistenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matrizAlternativaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrizCriterioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrizAlternativaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(494, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // gridCriterio
            // 
            this.gridCriterio.AllowUserToDeleteRows = false;
            this.gridCriterio.AutoGenerateColumns = false;
            this.gridCriterio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCriterio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.consistente,
            this.Column1,
            this.idmatrizCriterioDataGridViewTextBoxColumn,
            this.idproyectoDataGridViewTextBoxColumn1,
            this.idExpertoDataGridViewTextBoxColumn1,
            this.consistenteDataGridViewTextBoxColumn1});
            this.gridCriterio.DataSource = this.matrizCriterioBindingSource;
            this.gridCriterio.Location = new System.Drawing.Point(62, 59);
            this.gridCriterio.Name = "gridCriterio";
            this.gridCriterio.Size = new System.Drawing.Size(243, 66);
            this.gridCriterio.TabIndex = 2;
            this.gridCriterio.Click += new System.EventHandler(this.modificaCriterio);
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
            // idmatrizCriterioDataGridViewTextBoxColumn
            // 
            this.idmatrizCriterioDataGridViewTextBoxColumn.DataPropertyName = "id_matrizCriterio";
            this.idmatrizCriterioDataGridViewTextBoxColumn.HeaderText = "id_matrizCriterio";
            this.idmatrizCriterioDataGridViewTextBoxColumn.Name = "idmatrizCriterioDataGridViewTextBoxColumn";
            // 
            // idproyectoDataGridViewTextBoxColumn1
            // 
            this.idproyectoDataGridViewTextBoxColumn1.DataPropertyName = "id_proyecto";
            this.idproyectoDataGridViewTextBoxColumn1.HeaderText = "id_proyecto";
            this.idproyectoDataGridViewTextBoxColumn1.Name = "idproyectoDataGridViewTextBoxColumn1";
            // 
            // idExpertoDataGridViewTextBoxColumn1
            // 
            this.idExpertoDataGridViewTextBoxColumn1.DataPropertyName = "id_Experto";
            this.idExpertoDataGridViewTextBoxColumn1.HeaderText = "id_Experto";
            this.idExpertoDataGridViewTextBoxColumn1.Name = "idExpertoDataGridViewTextBoxColumn1";
            // 
            // consistenteDataGridViewTextBoxColumn1
            // 
            this.consistenteDataGridViewTextBoxColumn1.DataPropertyName = "consistente";
            this.consistenteDataGridViewTextBoxColumn1.HeaderText = "consistente";
            this.consistenteDataGridViewTextBoxColumn1.Name = "consistenteDataGridViewTextBoxColumn1";
            // 
            // matrizCriterioBindingSource
            // 
            this.matrizCriterioBindingSource.DataSource = typeof(sisExperto.matriz_Criterio);
            // 
            // gridAlternativa
            // 
            this.gridAlternativa.AllowUserToDeleteRows = false;
            this.gridAlternativa.AutoGenerateColumns = false;
            this.gridAlternativa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAlternativa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column3,
            this.Column4,
            this.idmatrizAlternativaDataGridViewTextBoxColumn,
            this.idproyectoDataGridViewTextBoxColumn,
            this.idExpertoDataGridViewTextBoxColumn,
            this.idCriterioDataGridViewTextBoxColumn,
            this.consistenteDataGridViewTextBoxColumn});
            this.gridAlternativa.DataSource = this.matrizAlternativaBindingSource;
            this.gridAlternativa.Location = new System.Drawing.Point(62, 131);
            this.gridAlternativa.Name = "gridAlternativa";
            this.gridAlternativa.Size = new System.Drawing.Size(344, 150);
            this.gridAlternativa.TabIndex = 3;
            this.gridAlternativa.Click += new System.EventHandler(this.modificaAlternativa);
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "id_matrizAlternativa";
            this.Column5.HeaderText = "Criterio";
            this.Column5.Name = "Column5";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "id_matrizAlternativa";
            this.Column3.HeaderText = "Consistencia";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "id_matrizAlternativa";
            this.Column4.HeaderText = "Valorar";
            this.Column4.Name = "Column4";
            // 
            // idmatrizAlternativaDataGridViewTextBoxColumn
            // 
            this.idmatrizAlternativaDataGridViewTextBoxColumn.DataPropertyName = "id_matrizAlternativa";
            this.idmatrizAlternativaDataGridViewTextBoxColumn.HeaderText = "id_matrizAlternativa";
            this.idmatrizAlternativaDataGridViewTextBoxColumn.Name = "idmatrizAlternativaDataGridViewTextBoxColumn";
            // 
            // idproyectoDataGridViewTextBoxColumn
            // 
            this.idproyectoDataGridViewTextBoxColumn.DataPropertyName = "id_proyecto";
            this.idproyectoDataGridViewTextBoxColumn.HeaderText = "id_proyecto";
            this.idproyectoDataGridViewTextBoxColumn.Name = "idproyectoDataGridViewTextBoxColumn";
            // 
            // idExpertoDataGridViewTextBoxColumn
            // 
            this.idExpertoDataGridViewTextBoxColumn.DataPropertyName = "id_Experto";
            this.idExpertoDataGridViewTextBoxColumn.HeaderText = "id_Experto";
            this.idExpertoDataGridViewTextBoxColumn.Name = "idExpertoDataGridViewTextBoxColumn";
            // 
            // idCriterioDataGridViewTextBoxColumn
            // 
            this.idCriterioDataGridViewTextBoxColumn.DataPropertyName = "id_Criterio";
            this.idCriterioDataGridViewTextBoxColumn.HeaderText = "id_Criterio";
            this.idCriterioDataGridViewTextBoxColumn.Name = "idCriterioDataGridViewTextBoxColumn";
            // 
            // consistenteDataGridViewTextBoxColumn
            // 
            this.consistenteDataGridViewTextBoxColumn.DataPropertyName = "consistente";
            this.consistenteDataGridViewTextBoxColumn.HeaderText = "consistente";
            this.consistenteDataGridViewTextBoxColumn.Name = "consistenteDataGridViewTextBoxColumn";
            // 
            // matrizAlternativaBindingSource
            // 
            this.matrizAlternativaBindingSource.DataSource = typeof(sisExperto.matriz_Alternativa);
            // 
            // Evaluaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 443);
            this.Controls.Add(this.gridAlternativa);
            this.Controls.Add(this.gridCriterio);
            this.Controls.Add(this.button1);
            this.Name = "Evaluaciones";
            this.Text = "Evaluaciones";
            this.Load += new System.EventHandler(this.Evaluaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrizCriterioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrizAlternativaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView gridCriterio;
        private System.Windows.Forms.BindingSource matrizCriterioBindingSource;
        private System.Windows.Forms.DataGridView gridAlternativa;
        private System.Windows.Forms.BindingSource matrizAlternativaBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistente;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmatrizCriterioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproyectoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idExpertoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn consistenteDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmatrizAlternativaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproyectoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idExpertoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCriterioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn consistenteDataGridViewTextBoxColumn;
    }
}