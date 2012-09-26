namespace sisexperto
{
    partial class ProyectosCreados
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.proyectoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objetivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.objetivoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.proyectoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(238, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(392, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cargar valores";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(63, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 209);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el proyecto para cargarlo:";
            // 
            // proyectoBindingSource
            // 
            this.proyectoBindingSource.DataSource = typeof(sisexperto.proyecto);
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // objetivoDataGridViewTextBoxColumn
            // 
            this.objetivoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.objetivoDataGridViewTextBoxColumn.DataPropertyName = "objetivo";
            this.objetivoDataGridViewTextBoxColumn.HeaderText = "Objetivo";
            this.objetivoDataGridViewTextBoxColumn.Name = "objetivoDataGridViewTextBoxColumn";
            // 
            // ProyectosCreados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 295);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProyectosCreados";
            this.Text = "ProyectosCreados";
            this.Load += new System.EventHandler(this.ProyectosCreados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.proyectoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objetivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource proyectoBindingSource;
    }
}