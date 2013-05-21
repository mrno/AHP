namespace sisexperto.UI
{
    partial class Comparacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

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
            this.panelInferior = new System.Windows.Forms.Panel();
            this.panelSugerencia = new System.Windows.Forms.Panel();
            this.labelSugerencia = new System.Windows.Forms.Label();
            this.buttonAplicar = new System.Windows.Forms.Button();
            this.buttonDescartar = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.buttonListo = new System.Windows.Forms.Button();
            this.panelComparacion = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelInferior.SuspendLayout();
            this.panelSugerencia.SuspendLayout();
            this.panelComparacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInferior
            // 
            this.panelInferior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInferior.Controls.Add(this.panelSugerencia);
            this.panelInferior.Controls.Add(this.buttonCerrar);
            this.panelInferior.Controls.Add(this.buttonListo);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 535);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(627, 76);
            this.panelInferior.TabIndex = 24;
            // 
            // panelSugerencia
            // 
            this.panelSugerencia.BackColor = System.Drawing.Color.LightGray;
            this.panelSugerencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSugerencia.Controls.Add(this.labelSugerencia);
            this.panelSugerencia.Controls.Add(this.buttonAplicar);
            this.panelSugerencia.Controls.Add(this.buttonDescartar);
            this.panelSugerencia.Location = new System.Drawing.Point(152, 2);
            this.panelSugerencia.Name = "panelSugerencia";
            this.panelSugerencia.Size = new System.Drawing.Size(470, 70);
            this.panelSugerencia.TabIndex = 18;
            // 
            // labelSugerencia
            // 
            this.labelSugerencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSugerencia.Location = new System.Drawing.Point(3, 2);
            this.labelSugerencia.Name = "labelSugerencia";
            this.labelSugerencia.Padding = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.labelSugerencia.Size = new System.Drawing.Size(306, 65);
            this.labelSugerencia.TabIndex = 13;
            this.labelSugerencia.Text = "Sugerencia:";
            // 
            // buttonAplicar
            // 
            this.buttonAplicar.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAplicar.Enabled = false;
            this.buttonAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAplicar.Location = new System.Drawing.Point(325, 3);
            this.buttonAplicar.Name = "buttonAplicar";
            this.buttonAplicar.Size = new System.Drawing.Size(140, 30);
            this.buttonAplicar.TabIndex = 16;
            this.buttonAplicar.Text = "Aplicar";
            this.buttonAplicar.UseVisualStyleBackColor = false;
            this.buttonAplicar.Click += new System.EventHandler(this.buttonAplicar_Click);
            // 
            // buttonDescartar
            // 
            this.buttonDescartar.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDescartar.Enabled = false;
            this.buttonDescartar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDescartar.Location = new System.Drawing.Point(325, 35);
            this.buttonDescartar.Name = "buttonDescartar";
            this.buttonDescartar.Size = new System.Drawing.Size(140, 30);
            this.buttonDescartar.TabIndex = 15;
            this.buttonDescartar.Text = "Descartar";
            this.buttonDescartar.UseVisualStyleBackColor = false;
            this.buttonDescartar.Click += new System.EventHandler(this.buttonDescartar_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerrar.Location = new System.Drawing.Point(5, 39);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(140, 30);
            this.buttonCerrar.TabIndex = 17;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // buttonListo
            // 
            this.buttonListo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListo.Location = new System.Drawing.Point(5, 5);
            this.buttonListo.Name = "buttonListo";
            this.buttonListo.Size = new System.Drawing.Size(140, 30);
            this.buttonListo.TabIndex = 14;
            this.buttonListo.Text = "Listo";
            this.buttonListo.Click += new System.EventHandler(this.buttonConsistencia_Click);
            // 
            // panelComparacion
            // 
            this.panelComparacion.AutoScroll = true;
            this.panelComparacion.BackColor = System.Drawing.SystemColors.Control;
            this.panelComparacion.Controls.Add(this.label19);
            this.panelComparacion.Controls.Add(this.label5);
            this.panelComparacion.Controls.Add(this.label12);
            this.panelComparacion.Controls.Add(this.label4);
            this.panelComparacion.Controls.Add(this.label11);
            this.panelComparacion.Controls.Add(this.label3);
            this.panelComparacion.Controls.Add(this.label1);
            this.panelComparacion.Controls.Add(this.label2);
            this.panelComparacion.Controls.Add(this.label6);
            this.panelComparacion.Controls.Add(this.label8);
            this.panelComparacion.Location = new System.Drawing.Point(0, 0);
            this.panelComparacion.Name = "panelComparacion";
            this.panelComparacion.Size = new System.Drawing.Size(627, 529);
            this.panelComparacion.TabIndex = 23;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(29, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(544, 48);
            this.label19.TabIndex = 10;
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "7";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(193, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(288, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "9";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(383, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(479, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "9";
            // 
            // Comparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 611);
            this.Controls.Add(this.panelInferior);
            this.Controls.Add(this.panelComparacion);
            this.Name = "Comparacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparacion";
            this.Load += new System.EventHandler(this.OnLoad);
            this.panelInferior.ResumeLayout(false);
            this.panelSugerencia.ResumeLayout(false);
            this.panelComparacion.ResumeLayout(false);
            this.panelComparacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelInferior;
        protected System.Windows.Forms.Panel panelSugerencia;
        protected System.Windows.Forms.Label labelSugerencia;
        protected System.Windows.Forms.Button buttonAplicar;
        protected System.Windows.Forms.Button buttonDescartar;
        protected System.Windows.Forms.Button buttonCerrar;
        protected System.Windows.Forms.Button buttonListo;
        protected System.Windows.Forms.Panel panelComparacion;
        protected System.Windows.Forms.Label label19;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label8;
    }
}