namespace sisexperto.UI
{
    partial class Sugerencias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridSugerencias = new System.Windows.Forms.DataGridView();
            this.buttonAplicar = new System.Windows.Forms.Button();
            this.buttonOtraSugerencia = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sugerenciaViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSugerencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sugerenciaViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridSugerencias
            // 
            this.dataGridSugerencias.AllowUserToAddRows = false;
            this.dataGridSugerencias.AllowUserToDeleteRows = false;
            this.dataGridSugerencias.AutoGenerateColumns = false;
            this.dataGridSugerencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridSugerencias.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridSugerencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSugerencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descripcionDataGridViewTextBoxColumn});
            this.dataGridSugerencias.DataSource = this.sugerenciaViewModelBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridSugerencias.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridSugerencias.Location = new System.Drawing.Point(13, 18);
            this.dataGridSugerencias.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridSugerencias.MultiSelect = false;
            this.dataGridSugerencias.Name = "dataGridSugerencias";
            this.dataGridSugerencias.ReadOnly = true;
            this.dataGridSugerencias.RowHeadersVisible = false;
            this.dataGridSugerencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSugerencias.Size = new System.Drawing.Size(435, 400);
            this.dataGridSugerencias.TabIndex = 1;
            // 
            // buttonAplicar
            // 
            this.buttonAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAplicar.Location = new System.Drawing.Point(13, 428);
            this.buttonAplicar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAplicar.Name = "buttonAplicar";
            this.buttonAplicar.Size = new System.Drawing.Size(140, 30);
            this.buttonAplicar.TabIndex = 38;
            this.buttonAplicar.Text = "Aplicar Sugerencia";
            this.buttonAplicar.UseVisualStyleBackColor = true;
            this.buttonAplicar.Click += new System.EventHandler(this.buttonAplicar_Click);
            // 
            // buttonOtraSugerencia
            // 
            this.buttonOtraSugerencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOtraSugerencia.Location = new System.Drawing.Point(161, 428);
            this.buttonOtraSugerencia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOtraSugerencia.Name = "buttonOtraSugerencia";
            this.buttonOtraSugerencia.Size = new System.Drawing.Size(140, 30);
            this.buttonOtraSugerencia.TabIndex = 39;
            this.buttonOtraSugerencia.Text = "Solicitar Otra(s)";
            this.buttonOtraSugerencia.UseVisualStyleBackColor = true;
            this.buttonOtraSugerencia.Click += new System.EventHandler(this.buttonOtraSugerencia_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalir.Location = new System.Drawing.Point(309, 428);
            this.buttonSalir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(140, 30);
            this.buttonSalir.TabIndex = 40;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descripcionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // sugerenciaViewModelBindingSource
            // 
            this.sugerenciaViewModelBindingSource.DataSource = typeof(sisexperto.UI.Clases.SugerenciaViewModel);
            // 
            // Sugerencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 464);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonOtraSugerencia);
            this.Controls.Add(this.buttonAplicar);
            this.Controls.Add(this.dataGridSugerencias);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Sugerencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sugerencias";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSugerencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sugerenciaViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridSugerencias;
        private System.Windows.Forms.Button buttonAplicar;
        private System.Windows.Forms.Button buttonOtraSugerencia;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.BindingSource sugerenciaViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;

    }
}