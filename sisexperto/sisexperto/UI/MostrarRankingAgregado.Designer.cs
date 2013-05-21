namespace sisExperto
{
    partial class MostrarRankingAgregado
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelSubtitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridResultados = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridExpertos = new System.Windows.Forms.DataGridView();
            this.ApellidoYNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridRankingPersonal = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.alternativaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultadoViewModelBindingSourceIndividual = new System.Windows.Forms.BindingSource(this.components);
            this.administradorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.expertoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alternativaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultadoViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResultados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertos)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRankingPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultadoViewModelBindingSourceIndividual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultadoViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(93, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(65, 20);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Nombre";
            // 
            // labelSubtitulo
            // 
            this.labelSubtitulo.AutoSize = true;
            this.labelSubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitulo.Location = new System.Drawing.Point(112, 35);
            this.labelSubtitulo.Name = "labelSubtitulo";
            this.labelSubtitulo.Size = new System.Drawing.Size(39, 20);
            this.labelSubtitulo.TabIndex = 2;
            this.labelSubtitulo.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Proyecto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Agregación:";
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
            this.dataGridResultados.Size = new System.Drawing.Size(288, 159);
            this.dataGridResultados.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridResultados);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 198);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ranking de Alternativas Agregado:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridExpertos);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(318, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 198);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Expertos en la Agregación:";
            // 
            // dataGridExpertos
            // 
            this.dataGridExpertos.AllowUserToAddRows = false;
            this.dataGridExpertos.AllowUserToDeleteRows = false;
            this.dataGridExpertos.AutoGenerateColumns = false;
            this.dataGridExpertos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridExpertos.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridExpertos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpertos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ApellidoYNombre,
            this.administradorDataGridViewCheckBoxColumn});
            this.dataGridExpertos.DataSource = this.expertoBindingSource;
            this.dataGridExpertos.Location = new System.Drawing.Point(6, 25);
            this.dataGridExpertos.Name = "dataGridExpertos";
            this.dataGridExpertos.ReadOnly = true;
            this.dataGridExpertos.RowHeadersVisible = false;
            this.dataGridExpertos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridExpertos.Size = new System.Drawing.Size(338, 159);
            this.dataGridExpertos.TabIndex = 5;
            this.dataGridExpertos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mostrarRankingPersonal);
            // 
            // ApellidoYNombre
            // 
            this.ApellidoYNombre.DataPropertyName = "ApellidoYNombre";
            this.ApellidoYNombre.FillWeight = 65F;
            this.ApellidoYNombre.HeaderText = "Apellido y Nombre";
            this.ApellidoYNombre.Name = "ApellidoYNombre";
            this.ApellidoYNombre.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridRankingPersonal);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(674, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 198);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ranking Personal:";
            // 
            // dataGridRankingPersonal
            // 
            this.dataGridRankingPersonal.AllowUserToAddRows = false;
            this.dataGridRankingPersonal.AllowUserToDeleteRows = false;
            this.dataGridRankingPersonal.AutoGenerateColumns = false;
            this.dataGridRankingPersonal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridRankingPersonal.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridRankingPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRankingPersonal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alternativaDataGridViewTextBoxColumn1,
            this.porcentajeDataGridViewTextBoxColumn1});
            this.dataGridRankingPersonal.DataSource = this.resultadoViewModelBindingSourceIndividual;
            this.dataGridRankingPersonal.Location = new System.Drawing.Point(6, 25);
            this.dataGridRankingPersonal.Name = "dataGridRankingPersonal";
            this.dataGridRankingPersonal.ReadOnly = true;
            this.dataGridRankingPersonal.RowHeadersVisible = false;
            this.dataGridRankingPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRankingPersonal.Size = new System.Drawing.Size(288, 159);
            this.dataGridRankingPersonal.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(828, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Resultado en 2 tuplas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // alternativaDataGridViewTextBoxColumn1
            // 
            this.alternativaDataGridViewTextBoxColumn1.DataPropertyName = "Alternativa";
            this.alternativaDataGridViewTextBoxColumn1.FillWeight = 65F;
            this.alternativaDataGridViewTextBoxColumn1.HeaderText = "Alternativa";
            this.alternativaDataGridViewTextBoxColumn1.Name = "alternativaDataGridViewTextBoxColumn1";
            this.alternativaDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // porcentajeDataGridViewTextBoxColumn1
            // 
            this.porcentajeDataGridViewTextBoxColumn1.DataPropertyName = "Porcentaje";
            this.porcentajeDataGridViewTextBoxColumn1.FillWeight = 35F;
            this.porcentajeDataGridViewTextBoxColumn1.HeaderText = "Porcentaje";
            this.porcentajeDataGridViewTextBoxColumn1.Name = "porcentajeDataGridViewTextBoxColumn1";
            this.porcentajeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // resultadoViewModelBindingSourceIndividual
            // 
            this.resultadoViewModelBindingSourceIndividual.DataSource = typeof(sisexperto.UI.Clases.ResultadoViewModel);
            // 
            // administradorDataGridViewCheckBoxColumn
            // 
            this.administradorDataGridViewCheckBoxColumn.DataPropertyName = "Administrador";
            this.administradorDataGridViewCheckBoxColumn.FillWeight = 35F;
            this.administradorDataGridViewCheckBoxColumn.HeaderText = "Administrador";
            this.administradorDataGridViewCheckBoxColumn.Name = "administradorDataGridViewCheckBoxColumn";
            this.administradorDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // expertoBindingSource
            // 
            this.expertoBindingSource.DataSource = typeof(sisExperto.Entidades.Experto);
            // 
            // alternativaDataGridViewTextBoxColumn
            // 
            this.alternativaDataGridViewTextBoxColumn.DataPropertyName = "Alternativa";
            this.alternativaDataGridViewTextBoxColumn.FillWeight = 65F;
            this.alternativaDataGridViewTextBoxColumn.HeaderText = "Alternativa";
            this.alternativaDataGridViewTextBoxColumn.Name = "alternativaDataGridViewTextBoxColumn";
            this.alternativaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // porcentajeDataGridViewTextBoxColumn
            // 
            this.porcentajeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.porcentajeDataGridViewTextBoxColumn.DataPropertyName = "Porcentaje";
            this.porcentajeDataGridViewTextBoxColumn.FillWeight = 35F;
            this.porcentajeDataGridViewTextBoxColumn.HeaderText = "Porcentaje";
            this.porcentajeDataGridViewTextBoxColumn.Name = "porcentajeDataGridViewTextBoxColumn";
            this.porcentajeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // resultadoViewModelBindingSource
            // 
            this.resultadoViewModelBindingSource.DataSource = typeof(sisexperto.UI.Clases.ResultadoViewModel);
            // 
            // MostrarRankingAgregado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 328);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSubtitulo);
            this.Controls.Add(this.labelTitulo);
            this.Name = "MostrarRankingAgregado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CalcularAgregacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResultados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRankingPersonal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultadoViewModelBindingSourceIndividual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultadoViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelSubtitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridResultados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridExpertos;
        private System.Windows.Forms.BindingSource expertoBindingSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridRankingPersonal;
        private System.Windows.Forms.BindingSource resultadoViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn alternativaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource resultadoViewModelBindingSourceIndividual;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoYNombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn administradorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alternativaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}