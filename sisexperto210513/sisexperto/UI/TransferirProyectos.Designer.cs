namespace sisexperto.UI
{
    partial class TransferirProyectos
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
            this.comboBoxOrigen = new System.Windows.Forms.ComboBox();
            this.labelExperto1 = new System.Windows.Forms.Label();
            this.labelExperto2 = new System.Windows.Forms.Label();
            this.comboBoxDestino = new System.Windows.Forms.ComboBox();
            this.buttonContinuar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.dataGridProyectos = new System.Windows.Forms.DataGridView();
            this.groupBoxProyectos = new System.Windows.Forms.GroupBox();
            this.nombreProyectoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objetivoProyectoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccionadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.proyectoTransferibleViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonTranferirYSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProyectos)).BeginInit();
            this.groupBoxProyectos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoTransferibleViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxOrigen
            // 
            this.comboBoxOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrigen.FormattingEnabled = true;
            this.comboBoxOrigen.Location = new System.Drawing.Point(196, 6);
            this.comboBoxOrigen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxOrigen.Name = "comboBoxOrigen";
            this.comboBoxOrigen.Size = new System.Drawing.Size(376, 28);
            this.comboBoxOrigen.TabIndex = 0;
            // 
            // labelExperto1
            // 
            this.labelExperto1.AutoSize = true;
            this.labelExperto1.Location = new System.Drawing.Point(13, 9);
            this.labelExperto1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExperto1.Name = "labelExperto1";
            this.labelExperto1.Size = new System.Drawing.Size(175, 20);
            this.labelExperto1.TabIndex = 1;
            this.labelExperto1.Text = "Transferir proyectos de:";
            // 
            // labelExperto2
            // 
            this.labelExperto2.AutoSize = true;
            this.labelExperto2.Location = new System.Drawing.Point(29, 47);
            this.labelExperto2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExperto2.Name = "labelExperto2";
            this.labelExperto2.Size = new System.Drawing.Size(159, 20);
            this.labelExperto2.TabIndex = 2;
            this.labelExperto2.Text = "a responsabilidad de:";
            // 
            // comboBoxDestino
            // 
            this.comboBoxDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDestino.FormattingEnabled = true;
            this.comboBoxDestino.Location = new System.Drawing.Point(196, 44);
            this.comboBoxDestino.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxDestino.Name = "comboBoxDestino";
            this.comboBoxDestino.Size = new System.Drawing.Size(376, 28);
            this.comboBoxDestino.TabIndex = 3;
            // 
            // buttonContinuar
            // 
            this.buttonContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContinuar.Location = new System.Drawing.Point(140, 469);
            this.buttonContinuar.Name = "buttonContinuar";
            this.buttonContinuar.Size = new System.Drawing.Size(140, 30);
            this.buttonContinuar.TabIndex = 7;
            this.buttonContinuar.Text = "Transferir";
            this.buttonContinuar.UseVisualStyleBackColor = true;
            this.buttonContinuar.Click += new System.EventHandler(this.buttonContinuar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(432, 469);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(140, 30);
            this.buttonCancelar.TabIndex = 8;
            this.buttonCancelar.Text = "Salir";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // dataGridProyectos
            // 
            this.dataGridProyectos.AllowUserToAddRows = false;
            this.dataGridProyectos.AllowUserToDeleteRows = false;
            this.dataGridProyectos.AllowUserToResizeRows = false;
            this.dataGridProyectos.AutoGenerateColumns = false;
            this.dataGridProyectos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProyectos.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProyectos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreProyectoDataGridViewTextBoxColumn,
            this.objetivoProyectoDataGridViewTextBoxColumn,
            this.seleccionadoDataGridViewCheckBoxColumn});
            this.dataGridProyectos.DataSource = this.proyectoTransferibleViewModelBindingSource;
            this.dataGridProyectos.Location = new System.Drawing.Point(6, 25);
            this.dataGridProyectos.MultiSelect = false;
            this.dataGridProyectos.Name = "dataGridProyectos";
            this.dataGridProyectos.RowHeadersVisible = false;
            this.dataGridProyectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProyectos.Size = new System.Drawing.Size(548, 352);
            this.dataGridProyectos.TabIndex = 9;
            // 
            // groupBoxProyectos
            // 
            this.groupBoxProyectos.Controls.Add(this.dataGridProyectos);
            this.groupBoxProyectos.Location = new System.Drawing.Point(12, 80);
            this.groupBoxProyectos.Name = "groupBoxProyectos";
            this.groupBoxProyectos.Size = new System.Drawing.Size(560, 383);
            this.groupBoxProyectos.TabIndex = 10;
            this.groupBoxProyectos.TabStop = false;
            this.groupBoxProyectos.Text = "Proyectos a transferir";
            // 
            // nombreProyectoDataGridViewTextBoxColumn
            // 
            this.nombreProyectoDataGridViewTextBoxColumn.DataPropertyName = "NombreProyecto";
            this.nombreProyectoDataGridViewTextBoxColumn.FillWeight = 40F;
            this.nombreProyectoDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreProyectoDataGridViewTextBoxColumn.Name = "nombreProyectoDataGridViewTextBoxColumn";
            this.nombreProyectoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // objetivoProyectoDataGridViewTextBoxColumn
            // 
            this.objetivoProyectoDataGridViewTextBoxColumn.DataPropertyName = "ObjetivoProyecto";
            this.objetivoProyectoDataGridViewTextBoxColumn.FillWeight = 40F;
            this.objetivoProyectoDataGridViewTextBoxColumn.HeaderText = "Objetivo";
            this.objetivoProyectoDataGridViewTextBoxColumn.Name = "objetivoProyectoDataGridViewTextBoxColumn";
            this.objetivoProyectoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // seleccionadoDataGridViewCheckBoxColumn
            // 
            this.seleccionadoDataGridViewCheckBoxColumn.DataPropertyName = "Seleccionado";
            this.seleccionadoDataGridViewCheckBoxColumn.FillWeight = 20F;
            this.seleccionadoDataGridViewCheckBoxColumn.HeaderText = "Tranferir";
            this.seleccionadoDataGridViewCheckBoxColumn.Name = "seleccionadoDataGridViewCheckBoxColumn";
            // 
            // proyectoTransferibleViewModelBindingSource
            // 
            this.proyectoTransferibleViewModelBindingSource.DataSource = typeof(sisexperto.UI.Clases.ProyectoTransferibleViewModel);
            // 
            // buttonTranferirYSalir
            // 
            this.buttonTranferirYSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTranferirYSalir.Location = new System.Drawing.Point(286, 469);
            this.buttonTranferirYSalir.Name = "buttonTranferirYSalir";
            this.buttonTranferirYSalir.Size = new System.Drawing.Size(140, 30);
            this.buttonTranferirYSalir.TabIndex = 11;
            this.buttonTranferirYSalir.Text = "Transferir y Salir";
            this.buttonTranferirYSalir.UseVisualStyleBackColor = true;
            this.buttonTranferirYSalir.Click += new System.EventHandler(this.buttonTranferirYSalir_Click);
            // 
            // TransferirProyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.buttonTranferirYSalir);
            this.Controls.Add(this.groupBoxProyectos);
            this.Controls.Add(this.buttonContinuar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.comboBoxDestino);
            this.Controls.Add(this.labelExperto2);
            this.Controls.Add(this.labelExperto1);
            this.Controls.Add(this.comboBoxOrigen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TransferirProyectos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferir Proyectos";
            this.Load += new System.EventHandler(this.TransferirProyectos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProyectos)).EndInit();
            this.groupBoxProyectos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.proyectoTransferibleViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxOrigen;
        private System.Windows.Forms.Label labelExperto1;
        private System.Windows.Forms.Label labelExperto2;
        private System.Windows.Forms.ComboBox comboBoxDestino;
        private System.Windows.Forms.Button buttonContinuar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.DataGridView dataGridProyectos;
        private System.Windows.Forms.GroupBox groupBoxProyectos;
        private System.Windows.Forms.BindingSource proyectoTransferibleViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProyectoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objetivoProyectoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccionadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button buttonTranferirYSalir;
    }
}