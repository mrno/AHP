﻿namespace sisexperto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargarProyecto));
            this.gridAlternativas = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alternativaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridCriterios = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criterioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridExpertoProyecto = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.criterioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertoProyecto)).BeginInit();
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
            this.gridAlternativas.Location = new System.Drawing.Point(431, 39);
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
            // gridCriterios
            // 
            this.gridCriterios.AutoGenerateColumns = false;
            this.gridCriterios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCriterios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn1,
            this.descripcionDataGridViewTextBoxColumn1});
            this.gridCriterios.DataSource = this.criterioBindingSource;
            this.gridCriterios.Location = new System.Drawing.Point(431, 195);
            this.gridCriterios.Name = "gridCriterios";
            this.gridCriterios.Size = new System.Drawing.Size(435, 150);
            this.gridCriterios.TabIndex = 4;
            // 
            // nombreDataGridViewTextBoxColumn1
            // 
            this.nombreDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDataGridViewTextBoxColumn1.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn1.Name = "nombreDataGridViewTextBoxColumn1";
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
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(697, 509);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(169, 42);
            this.button5.TabIndex = 7;
            this.button5.Text = "Realizar asignaciones";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre:";
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(184, 129);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(100, 20);
            this.txt2.TabIndex = 9;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(184, 64);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(100, 20);
            this.txt1.TabIndex = 8;
            // 
            // txt4
            // 
            this.txt4.Location = new System.Drawing.Point(184, 278);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(100, 20);
            this.txt4.TabIndex = 15;
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(184, 229);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(100, 20);
            this.txt3.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nombre:";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(338, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 49);
            this.button2.TabIndex = 22;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(338, 236);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 49);
            this.button4.TabIndex = 23;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(143, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Alternativa:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(143, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Criterio:";
            // 
            // dataGridExpertoProyecto
            // 
            this.dataGridExpertoProyecto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpertoProyecto.Location = new System.Drawing.Point(431, 351);
            this.dataGridExpertoProyecto.MultiSelect = false;
            this.dataGridExpertoProyecto.Name = "dataGridExpertoProyecto";
            this.dataGridExpertoProyecto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridExpertoProyecto.Size = new System.Drawing.Size(435, 150);
            this.dataGridExpertoProyecto.TabIndex = 26;
            this.dataGridExpertoProyecto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridExpertoProyecto_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(143, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Ponderacion:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(184, 376);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 28;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Peso:";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(338, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 49);
            this.button1.TabIndex = 30;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CargarProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 565);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridExpertoProyecto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.gridCriterios);
            this.Controls.Add(this.gridAlternativas);
            this.Name = "CargarProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cargar datos";
            this.Load += new System.EventHandler(this.CargarProyecto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.criterioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertoProyecto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridAlternativas;
        private System.Windows.Forms.DataGridView gridCriterios;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource alternativaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource criterioBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridExpertoProyecto;
        private System.Windows.Forms.Label label7;
   
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}

