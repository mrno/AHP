namespace sisexperto
{
    partial class CargarProyecto
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridAlternativas = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alternativaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.gridExpertos = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomusuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expertoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.gridCriterios = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criterioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExpertos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.criterioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAlternativas
            // 
            this.gridAlternativas.AutoGenerateColumns = false;
            this.gridAlternativas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAlternativas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn});
            this.gridAlternativas.DataSource = this.alternativaBindingSource;
            this.gridAlternativas.Location = new System.Drawing.Point(342, 72);
            this.gridAlternativas.Name = "gridAlternativas";
            this.gridAlternativas.Size = new System.Drawing.Size(435, 150);
            this.gridAlternativas.TabIndex = 0;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // alternativaBindingSource
            // 
            this.alternativaBindingSource.DataSource = typeof(sisexperto.alternativa);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Nueva Alternativa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridExpertos
            // 
            this.gridExpertos.AutoGenerateColumns = false;
            this.gridExpertos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridExpertos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn1,
            this.apellidoDataGridViewTextBoxColumn,
            this.nomusuarioDataGridViewTextBoxColumn});
            this.gridExpertos.DataSource = this.expertoBindingSource;
            this.gridExpertos.Location = new System.Drawing.Point(342, 283);
            this.gridExpertos.Name = "gridExpertos";
            this.gridExpertos.Size = new System.Drawing.Size(435, 150);
            this.gridExpertos.TabIndex = 2;
            // 
            // nombreDataGridViewTextBoxColumn1
            // 
            this.nombreDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDataGridViewTextBoxColumn1.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn1.Name = "nombreDataGridViewTextBoxColumn1";
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            this.apellidoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.apellidoDataGridViewTextBoxColumn.DataPropertyName = "apellido";
            this.apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            // 
            // nomusuarioDataGridViewTextBoxColumn
            // 
            this.nomusuarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomusuarioDataGridViewTextBoxColumn.DataPropertyName = "nom_usuario";
            this.nomusuarioDataGridViewTextBoxColumn.HeaderText = "Nombre de usuario";
            this.nomusuarioDataGridViewTextBoxColumn.Name = "nomusuarioDataGridViewTextBoxColumn";
            // 
            // expertoBindingSource
            // 
            this.expertoBindingSource.DataSource = typeof(sisexperto.experto);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(53, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Nuevo Experto";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gridCriterios
            // 
            this.gridCriterios.AutoGenerateColumns = false;
            this.gridCriterios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCriterios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn2,
            this.descripcionDataGridViewTextBoxColumn1});
            this.gridCriterios.DataSource = this.criterioBindingSource;
            this.gridCriterios.Location = new System.Drawing.Point(342, 488);
            this.gridCriterios.Name = "gridCriterios";
            this.gridCriterios.Size = new System.Drawing.Size(435, 150);
            this.gridCriterios.TabIndex = 4;
            // 
            // nombreDataGridViewTextBoxColumn2
            // 
            this.nombreDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDataGridViewTextBoxColumn2.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn2.Name = "nombreDataGridViewTextBoxColumn2";
            // 
            // descripcionDataGridViewTextBoxColumn1
            // 
            this.descripcionDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcionDataGridViewTextBoxColumn1.DataPropertyName = "descripcion";
            this.descripcionDataGridViewTextBoxColumn1.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn1.Name = "descripcionDataGridViewTextBoxColumn1";
            // 
            // criterioBindingSource
            // 
            this.criterioBindingSource.DataSource = typeof(sisexperto.criterio);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(53, 488);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Nuevo Criterio";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(53, 331);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Experto existente";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(880, 283);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(169, 42);
            this.button5.TabIndex = 7;
            this.button5.Text = "Realizar asignaciones";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // CargarProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 750);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.gridCriterios);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gridExpertos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridAlternativas);
            this.Name = "CargarProyecto";
            this.Text = "Cargar datos";
            this.Load += new System.EventHandler(this.CargarProyecto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExpertos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.criterioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridAlternativas;
        private System.Windows.Forms.BindingSource alternativaBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView gridExpertos;
        private System.Windows.Forms.BindingSource expertoBindingSource;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView gridCriterios;
        private System.Windows.Forms.BindingSource criterioBindingSource;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomusuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

