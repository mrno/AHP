namespace sisexperto.UI
{
    partial class ValorarProyectos
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAHP = new System.Windows.Forms.TabPage();
            this.groupBoxMatrizComparacion = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxConsistencia = new System.Windows.Forms.CheckBox();
            this.buttonVerMatrizCriterio = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridAlternativa = new System.Windows.Forms.DataGridView();
            this.tabPageIL = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridCriterios = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxProyectos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.consistenciaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.completaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.alternativaMatrizBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageAHP.SuspendLayout();
            this.groupBoxMatrizComparacion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).BeginInit();
            this.tabPageIL.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaMatrizBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAHP);
            this.tabControl1.Controls.Add(this.tabPageIL);
            this.tabControl1.Location = new System.Drawing.Point(5, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(967, 609);
            this.tabControl1.TabIndex = 40;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPageAHP
            // 
            this.tabPageAHP.Controls.Add(this.groupBoxMatrizComparacion);
            this.tabPageAHP.Controls.Add(this.groupBox1);
            this.tabPageAHP.Controls.Add(this.groupBox3);
            this.tabPageAHP.Location = new System.Drawing.Point(4, 22);
            this.tabPageAHP.Name = "tabPageAHP";
            this.tabPageAHP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAHP.Size = new System.Drawing.Size(959, 583);
            this.tabPageAHP.TabIndex = 0;
            this.tabPageAHP.Text = "AHP";
            this.tabPageAHP.UseVisualStyleBackColor = true;
            // 
            // groupBoxMatrizComparacion
            // 
            this.groupBoxMatrizComparacion.Controls.Add(this.textBox1);
            this.groupBoxMatrizComparacion.Controls.Add(this.label1);
            this.groupBoxMatrizComparacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMatrizComparacion.Location = new System.Drawing.Point(387, 16);
            this.groupBoxMatrizComparacion.Name = "groupBoxMatrizComparacion";
            this.groupBoxMatrizComparacion.Size = new System.Drawing.Size(566, 561);
            this.groupBoxMatrizComparacion.TabIndex = 37;
            this.groupBoxMatrizComparacion.TabStop = false;
            this.groupBoxMatrizComparacion.Text = "Matriz de Comparacion:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(258, 200);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxConsistencia);
            this.groupBox1.Controls.Add(this.buttonVerMatrizCriterio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 84);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comparacion de Criterios:";
            // 
            // checkBoxConsistencia
            // 
            this.checkBoxConsistencia.AutoCheck = false;
            this.checkBoxConsistencia.AutoSize = true;
            this.checkBoxConsistencia.Location = new System.Drawing.Point(6, 25);
            this.checkBoxConsistencia.Name = "checkBoxConsistencia";
            this.checkBoxConsistencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxConsistencia.Size = new System.Drawing.Size(183, 24);
            this.checkBoxConsistencia.TabIndex = 36;
            this.checkBoxConsistencia.Text = ":Valores Consistentes";
            this.checkBoxConsistencia.UseVisualStyleBackColor = true;
            // 
            // buttonVerMatrizCriterio
            // 
            this.buttonVerMatrizCriterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVerMatrizCriterio.Location = new System.Drawing.Point(221, 21);
            this.buttonVerMatrizCriterio.Name = "buttonVerMatrizCriterio";
            this.buttonVerMatrizCriterio.Size = new System.Drawing.Size(140, 30);
            this.buttonVerMatrizCriterio.TabIndex = 35;
            this.buttonVerMatrizCriterio.Text = "Ver Matriz";
            this.buttonVerMatrizCriterio.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridAlternativa);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(7, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(374, 263);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Comparacion de Alternativas:";
            // 
            // gridAlternativa
            // 
            this.gridAlternativa.AllowUserToAddRows = false;
            this.gridAlternativa.AllowUserToDeleteRows = false;
            this.gridAlternativa.AllowUserToResizeRows = false;
            this.gridAlternativa.AutoGenerateColumns = false;
            this.gridAlternativa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAlternativa.BackgroundColor = System.Drawing.Color.LightGray;
            this.gridAlternativa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAlternativa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.consistenciaDataGridViewCheckBoxColumn,
            this.completaDataGridViewCheckBoxColumn});
            this.gridAlternativa.DataSource = this.alternativaMatrizBindingSource;
            this.gridAlternativa.Location = new System.Drawing.Point(6, 25);
            this.gridAlternativa.Name = "gridAlternativa";
            this.gridAlternativa.ReadOnly = true;
            this.gridAlternativa.RowHeadersVisible = false;
            this.gridAlternativa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAlternativa.Size = new System.Drawing.Size(362, 232);
            this.gridAlternativa.TabIndex = 5;
            // 
            // tabPageIL
            // 
            this.tabPageIL.Controls.Add(this.groupBox2);
            this.tabPageIL.Location = new System.Drawing.Point(4, 22);
            this.tabPageIL.Name = "tabPageIL";
            this.tabPageIL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIL.Size = new System.Drawing.Size(959, 583);
            this.tabPageIL.TabIndex = 1;
            this.tabPageIL.Text = "IL";
            this.tabPageIL.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridCriterios);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 349);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Valoraciones";
            // 
            // gridCriterios
            // 
            this.gridCriterios.AllowUserToDeleteRows = false;
            this.gridCriterios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCriterios.BackgroundColor = System.Drawing.Color.LightGray;
            this.gridCriterios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCriterios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn2,
            this.dataGridViewTextBoxColumn1});
            this.gridCriterios.Location = new System.Drawing.Point(6, 25);
            this.gridCriterios.Name = "gridCriterios";
            this.gridCriterios.ReadOnly = true;
            this.gridCriterios.RowHeadersVisible = false;
            this.gridCriterios.Size = new System.Drawing.Size(488, 318);
            this.gridCriterios.TabIndex = 5;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Valorar Criterios";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn1.HeaderText = "Alternativa";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // comboBoxProyectos
            // 
            this.comboBoxProyectos.DisplayMember = "Nombre";
            this.comboBoxProyectos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProyectos.FormattingEnabled = true;
            this.comboBoxProyectos.Location = new System.Drawing.Point(93, 6);
            this.comboBoxProyectos.Name = "comboBoxProyectos";
            this.comboBoxProyectos.Size = new System.Drawing.Size(436, 28);
            this.comboBoxProyectos.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "Proyecto:";
            // 
            // consistenciaDataGridViewCheckBoxColumn
            // 
            this.consistenciaDataGridViewCheckBoxColumn.DataPropertyName = "Consistencia";
            this.consistenciaDataGridViewCheckBoxColumn.HeaderText = "Consistencia";
            this.consistenciaDataGridViewCheckBoxColumn.Name = "consistenciaDataGridViewCheckBoxColumn";
            this.consistenciaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // completaDataGridViewCheckBoxColumn
            // 
            this.completaDataGridViewCheckBoxColumn.DataPropertyName = "Completa";
            this.completaDataGridViewCheckBoxColumn.HeaderText = "Completa";
            this.completaDataGridViewCheckBoxColumn.Name = "completaDataGridViewCheckBoxColumn";
            this.completaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // alternativaMatrizBindingSource
            // 
            this.alternativaMatrizBindingSource.DataSource = typeof(sisexperto.Entidades.AlternativaMatriz);
            // 
            // ValorarProyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comboBoxProyectos);
            this.Controls.Add(this.label2);
            this.Name = "ValorarProyectos";
            this.Text = "ValorarProyectos";
            this.Load += new System.EventHandler(this.ValorarProyectos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageAHP.ResumeLayout(false);
            this.groupBoxMatrizComparacion.ResumeLayout(false);
            this.groupBoxMatrizComparacion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).EndInit();
            this.tabPageIL.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCriterios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaMatrizBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAHP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxConsistencia;
        private System.Windows.Forms.Button buttonVerMatrizCriterio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridAlternativa;
        private System.Windows.Forms.TabPage tabPageIL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridCriterios;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ComboBox comboBoxProyectos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxMatrizComparacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn criterioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistenciaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn completaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource alternativaMatrizBindingSource;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}