namespace sisexperto.UI
{
    partial class ExpertosDelSistema
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
            this.groupBoxListadoExpertos = new System.Windows.Forms.GroupBox();
            this.dataGridExpertos = new System.Windows.Forms.DataGridView();
            this.apellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.administradorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.expertoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonCrear = new System.Windows.Forms.Button();
            this.buttonEliminarValoraciones = new System.Windows.Forms.Button();
            this.buttonTranferir = new System.Windows.Forms.Button();
            this.groupBoxListadoExpertos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxListadoExpertos
            // 
            this.groupBoxListadoExpertos.Controls.Add(this.dataGridExpertos);
            this.groupBoxListadoExpertos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxListadoExpertos.Location = new System.Drawing.Point(12, 12);
            this.groupBoxListadoExpertos.Name = "groupBoxListadoExpertos";
            this.groupBoxListadoExpertos.Size = new System.Drawing.Size(724, 501);
            this.groupBoxListadoExpertos.TabIndex = 3;
            this.groupBoxListadoExpertos.TabStop = false;
            this.groupBoxListadoExpertos.Text = "Listado de Expertos";
            // 
            // dataGridExpertos
            // 
            this.dataGridExpertos.AllowUserToAddRows = false;
            this.dataGridExpertos.AllowUserToDeleteRows = false;
            this.dataGridExpertos.AllowUserToResizeRows = false;
            this.dataGridExpertos.AutoGenerateColumns = false;
            this.dataGridExpertos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridExpertos.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridExpertos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpertos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.apellidoDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.usuarioDataGridViewTextBoxColumn,
            this.administradorDataGridViewCheckBoxColumn});
            this.dataGridExpertos.DataSource = this.expertoBindingSource;
            this.dataGridExpertos.Location = new System.Drawing.Point(6, 25);
            this.dataGridExpertos.Name = "dataGridExpertos";
            this.dataGridExpertos.ReadOnly = true;
            this.dataGridExpertos.RowHeadersVisible = false;
            this.dataGridExpertos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridExpertos.Size = new System.Drawing.Size(712, 470);
            this.dataGridExpertos.TabIndex = 2;
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            this.apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            this.apellidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioDataGridViewTextBoxColumn
            // 
            this.usuarioDataGridViewTextBoxColumn.DataPropertyName = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
            this.usuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // administradorDataGridViewCheckBoxColumn
            // 
            this.administradorDataGridViewCheckBoxColumn.DataPropertyName = "Administrador";
            this.administradorDataGridViewCheckBoxColumn.HeaderText = "Administrador";
            this.administradorDataGridViewCheckBoxColumn.Name = "administradorDataGridViewCheckBoxColumn";
            this.administradorDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // expertoBindingSource
            // 
            this.expertoBindingSource.DataSource = typeof(sisExperto.Entidades.Experto);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.Location = new System.Drawing.Point(450, 519);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(140, 30);
            this.buttonEliminar.TabIndex = 5;
            this.buttonEliminar.Text = "Eliminar Experto";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(596, 519);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(140, 30);
            this.buttonCancelar.TabIndex = 6;
            this.buttonCancelar.Text = "Salir";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonCrear
            // 
            this.buttonCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCrear.Location = new System.Drawing.Point(12, 519);
            this.buttonCrear.Name = "buttonCrear";
            this.buttonCrear.Size = new System.Drawing.Size(140, 30);
            this.buttonCrear.TabIndex = 4;
            this.buttonCrear.Text = "Crear Experto";
            this.buttonCrear.UseVisualStyleBackColor = true;
            this.buttonCrear.Click += new System.EventHandler(this.buttonCrear_Click);
            // 
            // buttonEliminarValoraciones
            // 
            this.buttonEliminarValoraciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminarValoraciones.Location = new System.Drawing.Point(304, 519);
            this.buttonEliminarValoraciones.Name = "buttonEliminarValoraciones";
            this.buttonEliminarValoraciones.Size = new System.Drawing.Size(140, 30);
            this.buttonEliminarValoraciones.TabIndex = 7;
            this.buttonEliminarValoraciones.Text = "Descartar Valorac.";
            this.buttonEliminarValoraciones.UseVisualStyleBackColor = true;
            this.buttonEliminarValoraciones.Click += new System.EventHandler(this.buttonDesactivarValoraciones_Click);
            // 
            // buttonTranferir
            // 
            this.buttonTranferir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTranferir.Location = new System.Drawing.Point(158, 519);
            this.buttonTranferir.Name = "buttonTranferir";
            this.buttonTranferir.Size = new System.Drawing.Size(140, 30);
            this.buttonTranferir.TabIndex = 8;
            this.buttonTranferir.Text = "Transferir Proy.";
            this.buttonTranferir.UseVisualStyleBackColor = true;
            this.buttonTranferir.Click += new System.EventHandler(this.buttonTranferir_Click);
            // 
            // ExpertosDelSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 561);
            this.Controls.Add(this.buttonTranferir);
            this.Controls.Add(this.buttonEliminarValoraciones);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCrear);
            this.Controls.Add(this.groupBoxListadoExpertos);
            this.Name = "ExpertosDelSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expertos";
            this.Load += new System.EventHandler(this.ExpertosDelSistema_Load);
            this.groupBoxListadoExpertos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxListadoExpertos;
        private System.Windows.Forms.DataGridView dataGridExpertos;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonCrear;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn administradorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource expertoBindingSource;
        private System.Windows.Forms.Button buttonEliminarValoraciones;
        private System.Windows.Forms.Button buttonTranferir;
    }
}