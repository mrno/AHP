namespace sisexperto.UI
{
    partial class MostrarResultadoTuplas
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.alternativaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etiquetaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alphaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingTuplas = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingTuplas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alternativaDataGridViewTextBoxColumn,
            this.etiquetaDataGridViewTextBoxColumn,
            this.indiceDataGridViewTextBoxColumn,
            this.alphaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingTuplas;
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(506, 153);
            this.dataGridView1.TabIndex = 0;
            // 
            // alternativaDataGridViewTextBoxColumn
            // 
            this.alternativaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.alternativaDataGridViewTextBoxColumn.DataPropertyName = "Alternativa";
            this.alternativaDataGridViewTextBoxColumn.HeaderText = "Alternativa";
            this.alternativaDataGridViewTextBoxColumn.Name = "alternativaDataGridViewTextBoxColumn";
            this.alternativaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // etiquetaDataGridViewTextBoxColumn
            // 
            this.etiquetaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.etiquetaDataGridViewTextBoxColumn.DataPropertyName = "Etiqueta";
            this.etiquetaDataGridViewTextBoxColumn.HeaderText = "Etiqueta";
            this.etiquetaDataGridViewTextBoxColumn.Name = "etiquetaDataGridViewTextBoxColumn";
            this.etiquetaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indiceDataGridViewTextBoxColumn
            // 
            this.indiceDataGridViewTextBoxColumn.DataPropertyName = "Indice";
            this.indiceDataGridViewTextBoxColumn.HeaderText = "Indice";
            this.indiceDataGridViewTextBoxColumn.Name = "indiceDataGridViewTextBoxColumn";
            this.indiceDataGridViewTextBoxColumn.ReadOnly = true;
            this.indiceDataGridViewTextBoxColumn.Width = 80;
            // 
            // alphaDataGridViewTextBoxColumn
            // 
            this.alphaDataGridViewTextBoxColumn.DataPropertyName = "Alpha";
            this.alphaDataGridViewTextBoxColumn.HeaderText = "Alpha";
            this.alphaDataGridViewTextBoxColumn.Name = "alphaDataGridViewTextBoxColumn";
            this.alphaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingTuplas
            // 
            this.bindingTuplas.DataSource = typeof(sisexperto.UI.Clases.ResultadoPersonalTuplasViewModel);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 193);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Representación en dos tuplas:";
            // 
            // MostrarResultadoTuplas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 214);
            this.Controls.Add(this.groupBox1);
            this.Name = "MostrarResultadoTuplas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MostrarResultadoTuplas";
            this.Load += new System.EventHandler(this.MostrarResultadoTuplas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingTuplas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingTuplas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn alternativaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn etiquetaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alphaDataGridViewTextBoxColumn;
    }
}