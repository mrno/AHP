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
            this.buttonConsistencia = new System.Windows.Forms.Button();
            this.labelComparacion = new System.Windows.Forms.Label();
            this.panelTrackBar = new System.Windows.Forms.Panel();
            this.labelComparacionTrack = new System.Windows.Forms.Label();
            this.trackBarComparacion = new System.Windows.Forms.TrackBar();
            this.panelMatriz = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxConsistencia = new System.Windows.Forms.CheckBox();
            this.buttonVerMatrizCriterio = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridAlternativa = new System.Windows.Forms.DataGridView();
            this.tabPageIL = new System.Windows.Forms.TabPage();
            this.groupBoxComparacionIL = new System.Windows.Forms.GroupBox();
            this.labelAlternativa = new System.Windows.Forms.Label();
            this.panelComparacionIL = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridAlternativasIL = new System.Windows.Forms.DataGridView();
            this.comboBoxProyectos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CriterioNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consistenciaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.completaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.alternativaMatrizBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valoradaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.alternativaILBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageAHP.SuspendLayout();
            this.groupBoxMatrizComparacion.SuspendLayout();
            this.panelTrackBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarComparacion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).BeginInit();
            this.tabPageIL.SuspendLayout();
            this.groupBoxComparacionIL.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativasIL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaMatrizBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaILBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAHP);
            this.tabControl1.Controls.Add(this.tabPageIL);
            this.tabControl1.Location = new System.Drawing.Point(5, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(967, 597);
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
            this.tabPageAHP.Size = new System.Drawing.Size(959, 571);
            this.tabPageAHP.TabIndex = 0;
            this.tabPageAHP.Text = "AHP";
            this.tabPageAHP.UseVisualStyleBackColor = true;
            // 
            // groupBoxMatrizComparacion
            // 
            this.groupBoxMatrizComparacion.Controls.Add(this.buttonConsistencia);
            this.groupBoxMatrizComparacion.Controls.Add(this.labelComparacion);
            this.groupBoxMatrizComparacion.Controls.Add(this.panelTrackBar);
            this.groupBoxMatrizComparacion.Controls.Add(this.panelMatriz);
            this.groupBoxMatrizComparacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMatrizComparacion.Location = new System.Drawing.Point(387, 6);
            this.groupBoxMatrizComparacion.Name = "groupBoxMatrizComparacion";
            this.groupBoxMatrizComparacion.Size = new System.Drawing.Size(566, 561);
            this.groupBoxMatrizComparacion.TabIndex = 37;
            this.groupBoxMatrizComparacion.TabStop = false;
            this.groupBoxMatrizComparacion.Text = "Matriz de Comparacion:";
            // 
            // buttonConsistencia
            // 
            this.buttonConsistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConsistencia.Location = new System.Drawing.Point(6, 21);
            this.buttonConsistencia.Name = "buttonConsistencia";
            this.buttonConsistencia.Size = new System.Drawing.Size(140, 30);
            this.buttonConsistencia.TabIndex = 37;
            this.buttonConsistencia.Text = "Ver Consistencia";
            this.buttonConsistencia.UseVisualStyleBackColor = true;
            this.buttonConsistencia.Click += new System.EventHandler(this.buttonConsistencia_Click);
            // 
            // labelComparacion
            // 
            this.labelComparacion.AutoSize = true;
            this.labelComparacion.Location = new System.Drawing.Point(169, 25);
            this.labelComparacion.Name = "labelComparacion";
            this.labelComparacion.Size = new System.Drawing.Size(251, 20);
            this.labelComparacion.TabIndex = 2;
            this.labelComparacion.Text = "- seleccione una celda de la matriz";
            // 
            // panelTrackBar
            // 
            this.panelTrackBar.BackColor = System.Drawing.Color.Transparent;
            this.panelTrackBar.Controls.Add(this.labelComparacionTrack);
            this.panelTrackBar.Controls.Add(this.trackBarComparacion);
            this.panelTrackBar.Location = new System.Drawing.Point(6, 475);
            this.panelTrackBar.Name = "panelTrackBar";
            this.panelTrackBar.Size = new System.Drawing.Size(554, 80);
            this.panelTrackBar.TabIndex = 1;
            // 
            // labelComparacionTrack
            // 
            this.labelComparacionTrack.Location = new System.Drawing.Point(3, 6);
            this.labelComparacionTrack.Name = "labelComparacionTrack";
            this.labelComparacionTrack.Size = new System.Drawing.Size(548, 20);
            this.labelComparacionTrack.TabIndex = 3;
            this.labelComparacionTrack.Text = "- seleccione una celda de la matriz";
            // 
            // trackBarComparacion
            // 
            this.trackBarComparacion.BackColor = System.Drawing.Color.White;
            this.trackBarComparacion.Enabled = false;
            this.trackBarComparacion.Location = new System.Drawing.Point(3, 32);
            this.trackBarComparacion.Maximum = 17;
            this.trackBarComparacion.Minimum = 1;
            this.trackBarComparacion.Name = "trackBarComparacion";
            this.trackBarComparacion.Size = new System.Drawing.Size(548, 45);
            this.trackBarComparacion.TabIndex = 0;
            this.trackBarComparacion.TabStop = false;
            this.trackBarComparacion.Value = 1;
            // 
            // panelMatriz
            // 
            this.panelMatriz.BackColor = System.Drawing.Color.Transparent;
            this.panelMatriz.Location = new System.Drawing.Point(6, 56);
            this.panelMatriz.Name = "panelMatriz";
            this.panelMatriz.Size = new System.Drawing.Size(554, 413);
            this.panelMatriz.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxConsistencia);
            this.groupBox1.Controls.Add(this.buttonVerMatrizCriterio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 57);
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
            this.buttonVerMatrizCriterio.Location = new System.Drawing.Point(227, 21);
            this.buttonVerMatrizCriterio.Name = "buttonVerMatrizCriterio";
            this.buttonVerMatrizCriterio.Size = new System.Drawing.Size(140, 30);
            this.buttonVerMatrizCriterio.TabIndex = 35;
            this.buttonVerMatrizCriterio.Text = "Ver Matriz";
            this.buttonVerMatrizCriterio.UseVisualStyleBackColor = true;
            this.buttonVerMatrizCriterio.Click += new System.EventHandler(this.buttonVerMatrizCriterio_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridAlternativa);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(374, 498);
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
            this.CriterioNombre,
            this.consistenciaDataGridViewCheckBoxColumn,
            this.completaDataGridViewCheckBoxColumn});
            this.gridAlternativa.DataSource = this.alternativaMatrizBindingSource;
            this.gridAlternativa.Location = new System.Drawing.Point(6, 25);
            this.gridAlternativa.Name = "gridAlternativa";
            this.gridAlternativa.ReadOnly = true;
            this.gridAlternativa.RowHeadersVisible = false;
            this.gridAlternativa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAlternativa.Size = new System.Drawing.Size(362, 467);
            this.gridAlternativa.TabIndex = 5;
            // 
            // tabPageIL
            // 
            this.tabPageIL.Controls.Add(this.groupBoxComparacionIL);
            this.tabPageIL.Controls.Add(this.groupBox2);
            this.tabPageIL.Location = new System.Drawing.Point(4, 22);
            this.tabPageIL.Name = "tabPageIL";
            this.tabPageIL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIL.Size = new System.Drawing.Size(959, 571);
            this.tabPageIL.TabIndex = 1;
            this.tabPageIL.Text = "IL";
            this.tabPageIL.UseVisualStyleBackColor = true;
            // 
            // groupBoxComparacionIL
            // 
            this.groupBoxComparacionIL.Controls.Add(this.labelAlternativa);
            this.groupBoxComparacionIL.Controls.Add(this.panelComparacionIL);
            this.groupBoxComparacionIL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxComparacionIL.Location = new System.Drawing.Point(390, 6);
            this.groupBoxComparacionIL.Name = "groupBoxComparacionIL";
            this.groupBoxComparacionIL.Size = new System.Drawing.Size(566, 559);
            this.groupBoxComparacionIL.TabIndex = 38;
            this.groupBoxComparacionIL.TabStop = false;
            this.groupBoxComparacionIL.Text = "Matriz de Comparacion:";
            // 
            // labelAlternativa
            // 
            this.labelAlternativa.AutoSize = true;
            this.labelAlternativa.Location = new System.Drawing.Point(169, 25);
            this.labelAlternativa.Name = "labelAlternativa";
            this.labelAlternativa.Size = new System.Drawing.Size(201, 20);
            this.labelAlternativa.TabIndex = 2;
            this.labelAlternativa.Text = "- seleccione una alternativa";
            // 
            // panelComparacionIL
            // 
            this.panelComparacionIL.BackColor = System.Drawing.Color.Transparent;
            this.panelComparacionIL.Location = new System.Drawing.Point(6, 56);
            this.panelComparacionIL.Name = "panelComparacionIL";
            this.panelComparacionIL.Size = new System.Drawing.Size(554, 497);
            this.panelComparacionIL.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridAlternativasIL);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 559);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Valoraciones";
            // 
            // gridAlternativasIL
            // 
            this.gridAlternativasIL.AllowUserToAddRows = false;
            this.gridAlternativasIL.AllowUserToDeleteRows = false;
            this.gridAlternativasIL.AutoGenerateColumns = false;
            this.gridAlternativasIL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAlternativasIL.BackgroundColor = System.Drawing.Color.LightGray;
            this.gridAlternativasIL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAlternativasIL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.valoradaDataGridViewCheckBoxColumn});
            this.gridAlternativasIL.DataSource = this.alternativaILBindingSource;
            this.gridAlternativasIL.Location = new System.Drawing.Point(6, 25);
            this.gridAlternativasIL.Name = "gridAlternativasIL";
            this.gridAlternativasIL.ReadOnly = true;
            this.gridAlternativasIL.RowHeadersVisible = false;
            this.gridAlternativasIL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAlternativasIL.Size = new System.Drawing.Size(366, 528);
            this.gridAlternativasIL.TabIndex = 5;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Criterio";
            this.dataGridViewTextBoxColumn1.FillWeight = 45F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Criterio";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 359;
            // 
            // CriterioNombre
            // 
            this.CriterioNombre.DataPropertyName = "CriterioNombre";
            this.CriterioNombre.HeaderText = "CriterioNombre";
            this.CriterioNombre.Name = "CriterioNombre";
            this.CriterioNombre.ReadOnly = true;
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
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valoradaDataGridViewCheckBoxColumn
            // 
            this.valoradaDataGridViewCheckBoxColumn.DataPropertyName = "Valorada";
            this.valoradaDataGridViewCheckBoxColumn.HeaderText = "Valorada";
            this.valoradaDataGridViewCheckBoxColumn.Name = "valoradaDataGridViewCheckBoxColumn";
            this.valoradaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // alternativaILBindingSource
            // 
            this.alternativaILBindingSource.DataSource = typeof(sisexperto.Entidades.AlternativaIL);
            // 
            // ValorarProyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 642);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comboBoxProyectos);
            this.Controls.Add(this.label2);
            this.Name = "ValorarProyectos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Valorar Proyectos";
            this.Load += new System.EventHandler(this.ValorarProyectos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageAHP.ResumeLayout(false);
            this.groupBoxMatrizComparacion.ResumeLayout(false);
            this.groupBoxMatrizComparacion.PerformLayout();
            this.panelTrackBar.ResumeLayout(false);
            this.panelTrackBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarComparacion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativa)).EndInit();
            this.tabPageIL.ResumeLayout(false);
            this.groupBoxComparacionIL.ResumeLayout(false);
            this.groupBoxComparacionIL.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlternativasIL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaMatrizBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternativaILBindingSource)).EndInit();
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
        private System.Windows.Forms.DataGridView gridAlternativasIL;
        private System.Windows.Forms.ComboBox comboBoxProyectos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxMatrizComparacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn criterioDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label labelComparacion;
        private System.Windows.Forms.Panel panelMatriz;
        private System.Windows.Forms.GroupBox groupBoxComparacionIL;
        private System.Windows.Forms.Label labelAlternativa;
        private System.Windows.Forms.Panel panelComparacionIL;
        private System.Windows.Forms.Button buttonConsistencia;
        private System.Windows.Forms.Panel panelTrackBar;
        private System.Windows.Forms.Label labelComparacionTrack;
        private System.Windows.Forms.TrackBar trackBarComparacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn valoradaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource alternativaILBindingSource;
        private System.Windows.Forms.BindingSource alternativaMatrizBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn CriterioNombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consistenciaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn completaDataGridViewCheckBoxColumn;
    }
}