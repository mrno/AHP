namespace sisexperto
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
            this.matrizcriterioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridAlternativa = new System.Windows.Forms.DataGridView();
            this.matrizalternativaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.consistente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrizcriterioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrizalternativaBindingSource)).BeginInit();
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
            this.Column1});
            this.gridCriterio.DataSource = this.matrizcriterioBindingSource;
            this.gridCriterio.Location = new System.Drawing.Point(62, 59);
            this.gridCriterio.Name = "gridCriterio";
            this.gridCriterio.Size = new System.Drawing.Size(243, 46);
            this.gridCriterio.TabIndex = 2;
            this.gridCriterio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modificarCriterio);
            // 
            // matrizcriterioBindingSource
            // 
            this.matrizcriterioBindingSource.DataSource = typeof(sisexperto.matriz_criterio);
            // 
            // gridAlternativa
            // 
            this.gridAlternativa.AllowUserToDeleteRows = false;
            this.gridAlternativa.AutoGenerateColumns = false;
            this.gridAlternativa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAlternativa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column3,
            this.Column4});
            this.gridAlternativa.DataSource = this.matrizalternativaBindingSource;
            this.gridAlternativa.Location = new System.Drawing.Point(62, 131);
            this.gridAlternativa.Name = "gridAlternativa";
            this.gridAlternativa.Size = new System.Drawing.Size(344, 150);
            this.gridAlternativa.TabIndex = 3;
            this.gridAlternativa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modificarAlternativa);
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
            ((System.ComponentModel.ISupportInitialize)(this.matrizcriterioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrizalternativaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView gridCriterio;
        private System.Windows.Forms.BindingSource matrizcriterioBindingSource;
        private System.Windows.Forms.DataGridView gridAlternativa;
        private System.Windows.Forms.BindingSource matrizalternativaBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistente;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}