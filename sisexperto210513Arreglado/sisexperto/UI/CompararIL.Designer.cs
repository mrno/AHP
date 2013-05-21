namespace sisexperto.UI
{
    partial class CompararIL
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
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.nombreAlternativa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 13;
            // 
            // nombreAlternativa
            // 
            this.nombreAlternativa.AutoSize = true;
            this.nombreAlternativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreAlternativa.Location = new System.Drawing.Point(106, 19);
            this.nombreAlternativa.Name = "nombreAlternativa";
            this.nombreAlternativa.Size = new System.Drawing.Size(430, 31);
            this.nombreAlternativa.TabIndex = 10;
            this.nombreAlternativa.Text = "aca-va-el-nombre-de-la-alternativa";
            // 
            // CompararIL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(604, 473);
            this.Controls.Add(this.nombreAlternativa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Name = "CompararIL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comparar";
            this.Load += new System.EventHandler(this.CompararIL_load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label nombreAlternativa;
    }
}