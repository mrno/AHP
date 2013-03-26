namespace sisexperto.UI
{
    partial class MostrarRankingPersonal
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridResultados = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSubtitulo = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.resultadoViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alternativaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultadoViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridResultados);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 381);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ranking de Alternativas:";
            // 
            // dataGridResultados
            // 
            this.dataGridResultados.AllowUserToAddRows = false;
            this.dataGridResultados.AllowUserToDeleteRows = false;
            this.dataGridResultados.AutoGenerateColumns = false;
            this.dataGridResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridResultados.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alternativaDataGridViewTextBoxColumn,
            this.porcentajeDataGridViewTextBoxColumn});
            this.dataGridResultados.DataSource = this.resultadoViewModelBindingSource;
            this.dataGridResultados.Location = new System.Drawing.Point(6, 25);
            this.dataGridResultados.Name = "dataGridResultados";
            this.dataGridResultados.ReadOnly = true;
            this.dataGridResultados.RowHeadersVisible = false;
            this.dataGridResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridResultados.Size = new System.Drawing.Size(448, 350);
            this.dataGridResultados.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Experto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Proyecto:";
            // 
            // labelSubtitulo
            // 
            this.labelSubtitulo.AutoSize = true;
            this.labelSubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitulo.Location = new System.Drawing.Point(93, 35);
            this.labelSubtitulo.Name = "labelSubtitulo";
            this.labelSubtitulo.Size = new System.Drawing.Size(65, 20);
            this.labelSubtitulo.TabIndex = 8;
            this.labelSubtitulo.Text = "Nombre";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(93, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(65, 20);
            this.labelTitulo.TabIndex = 7;
            this.labelTitulo.Text = "Nombre";
            // 
            // resultadoViewModelBindingSource
            // 
            this.resultadoViewModelBindingSource.DataSource = typeof(sisexperto.UI.Clases.ResultadoViewModel);
            // 
            // alternativaDataGridViewTextBoxColumn
            // 
            this.alternativaDataGridViewTextBoxColumn.DataPropertyName = "Alternativa";
            this.alternativaDataGridViewTextBoxColumn.HeaderText = "Alternativa";
            this.alternativaDataGridViewTextBoxColumn.Name = "alternativaDataGridViewTextBoxColumn";
            this.alternativaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // porcentajeDataGridViewTextBoxColumn
            // 
            this.porcentajeDataGridViewTextBoxColumn.DataPropertyName = "Porcentaje";
            this.porcentajeDataGridViewTextBoxColumn.HeaderText = "Porcentaje";
            this.porcentajeDataGridViewTextBoxColumn.Name = "porcentajeDataGridViewTextBoxColumn";
            this.porcentajeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MostrarRankingPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSubtitulo);
            this.Controls.Add(this.labelTitulo);
            this.Name = "MostrarRankingPersonal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MostrarRankingPersonal";
            this.Load += new System.EventHandler(this.MostrarRankingPersonal_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultadoViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridResultados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSubtitulo;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn alternativaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource resultadoViewModelBindingSource;

    }
}