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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelExperto1 = new System.Windows.Forms.Label();
            this.labelExperto2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.buttonContinuar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.dataGridProyectos = new System.Windows.Forms.DataGridView();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxProyectos = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProyectos)).BeginInit();
            this.groupBoxProyectos.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(196, 6);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(376, 28);
            this.comboBox1.TabIndex = 0;
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
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(196, 44);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(376, 28);
            this.comboBox2.TabIndex = 3;
            // 
            // buttonContinuar
            // 
            this.buttonContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContinuar.Location = new System.Drawing.Point(286, 469);
            this.buttonContinuar.Name = "buttonContinuar";
            this.buttonContinuar.Size = new System.Drawing.Size(140, 30);
            this.buttonContinuar.TabIndex = 7;
            this.buttonContinuar.Text = "Transferir";
            this.buttonContinuar.UseVisualStyleBackColor = true;
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
            // 
            // dataGridProyectos
            // 
            this.dataGridProyectos.AllowUserToAddRows = false;
            this.dataGridProyectos.AllowUserToDeleteRows = false;
            this.dataGridProyectos.AllowUserToResizeRows = false;
            this.dataGridProyectos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProyectos.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProyectos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo});
            this.dataGridProyectos.Location = new System.Drawing.Point(6, 25);
            this.dataGridProyectos.MultiSelect = false;
            this.dataGridProyectos.Name = "dataGridProyectos";
            this.dataGridProyectos.ReadOnly = true;
            this.dataGridProyectos.RowHeadersVisible = false;
            this.dataGridProyectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProyectos.Size = new System.Drawing.Size(548, 352);
            this.dataGridProyectos.TabIndex = 9;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
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
            // TransferirProyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.groupBoxProyectos);
            this.Controls.Add(this.buttonContinuar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.labelExperto2);
            this.Controls.Add(this.labelExperto1);
            this.Controls.Add(this.comboBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TransferirProyectos";
            this.Text = "Transferir Proyectos";
            this.Load += new System.EventHandler(this.TransferirProyectos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProyectos)).EndInit();
            this.groupBoxProyectos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelExperto1;
        private System.Windows.Forms.Label labelExperto2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button buttonContinuar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.DataGridView dataGridProyectos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.GroupBox groupBoxProyectos;
    }
}