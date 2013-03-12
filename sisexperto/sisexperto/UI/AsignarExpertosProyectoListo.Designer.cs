namespace sisexperto.UI
{
    partial class AsignarExpertosProyectoListo
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
            this.dataGridExpertosAsignados = new System.Windows.Forms.DataGridView();
            this.expertoEnProyectoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxProyectos = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosAsignados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoEnProyectoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridExpertosAsignados
            // 
            this.dataGridExpertosAsignados.AutoGenerateColumns = false;
            this.dataGridExpertosAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpertosAsignados.DataSource = this.expertoEnProyectoBindingSource;
            this.dataGridExpertosAsignados.Location = new System.Drawing.Point(95, 110);
            this.dataGridExpertosAsignados.Name = "dataGridExpertosAsignados";
            this.dataGridExpertosAsignados.Size = new System.Drawing.Size(240, 150);
            this.dataGridExpertosAsignados.TabIndex = 0;
            // 
            // comboBoxProyectos
            // 
            this.comboBoxProyectos.DisplayMember = "Nombre";
            this.comboBoxProyectos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProyectos.FormattingEnabled = true;
            this.comboBoxProyectos.Location = new System.Drawing.Point(32, 38);
            this.comboBoxProyectos.Name = "comboBoxProyectos";
            this.comboBoxProyectos.Size = new System.Drawing.Size(380, 28);
            this.comboBoxProyectos.TabIndex = 41;
            // 
            // AsignarExpertosProyectoListo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 360);
            this.Controls.Add(this.comboBoxProyectos);
            this.Controls.Add(this.dataGridExpertosAsignados);
            this.Name = "AsignarExpertosProyectoListo";
            this.Text = "AsignarExpertosProyectoListo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpertosAsignados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertoEnProyectoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridExpertosAsignados;
        private System.Windows.Forms.BindingSource expertoEnProyectoBindingSource;
        private System.Windows.Forms.ComboBox comboBoxProyectos;
    }
}