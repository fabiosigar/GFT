namespace GFT.TestTecnicoEntrada
{
    partial class FormTecnico
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tboxEntrada = new System.Windows.Forms.TextBox();
            this.labelEntrada = new System.Windows.Forms.Label();
            this.bntEnviarEntrada = new System.Windows.Forms.Button();
            this.labelSaida = new System.Windows.Forms.Label();
            this.tboxSaida = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tboxEntrada
            // 
            this.tboxEntrada.Location = new System.Drawing.Point(84, 12);
            this.tboxEntrada.Multiline = true;
            this.tboxEntrada.Name = "tboxEntrada";
            this.tboxEntrada.Size = new System.Drawing.Size(611, 175);
            this.tboxEntrada.TabIndex = 0;
            // 
            // labelEntrada
            // 
            this.labelEntrada.AutoSize = true;
            this.labelEntrada.Location = new System.Drawing.Point(13, 13);
            this.labelEntrada.Name = "labelEntrada";
            this.labelEntrada.Size = new System.Drawing.Size(47, 13);
            this.labelEntrada.TabIndex = 1;
            this.labelEntrada.Text = "Entrada:";
            // 
            // bntEnviarEntrada
            // 
            this.bntEnviarEntrada.Location = new System.Drawing.Point(713, 44);
            this.bntEnviarEntrada.Name = "bntEnviarEntrada";
            this.bntEnviarEntrada.Size = new System.Drawing.Size(75, 23);
            this.bntEnviarEntrada.TabIndex = 2;
            this.bntEnviarEntrada.Text = "Enviar";
            this.bntEnviarEntrada.UseVisualStyleBackColor = true;
            this.bntEnviarEntrada.Click += new System.EventHandler(this.bntEnviarEntrada_Click);
            // 
            // labelSaida
            // 
            this.labelSaida.AutoSize = true;
            this.labelSaida.Location = new System.Drawing.Point(16, 226);
            this.labelSaida.Name = "labelSaida";
            this.labelSaida.Size = new System.Drawing.Size(34, 13);
            this.labelSaida.TabIndex = 3;
            this.labelSaida.Text = "Saida";
            // 
            // tboxSaida
            // 
            this.tboxSaida.Location = new System.Drawing.Point(84, 226);
            this.tboxSaida.Multiline = true;
            this.tboxSaida.Name = "tboxSaida";
            this.tboxSaida.ReadOnly = true;
            this.tboxSaida.Size = new System.Drawing.Size(611, 189);
            this.tboxSaida.TabIndex = 4;
            // 
            // FormTecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tboxSaida);
            this.Controls.Add(this.labelSaida);
            this.Controls.Add(this.bntEnviarEntrada);
            this.Controls.Add(this.labelEntrada);
            this.Controls.Add(this.tboxEntrada);
            this.Name = "FormTecnico";
            this.Text = "TesteTecnico";
            this.Load += new System.EventHandler(this.FormTecnico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxEntrada;
        private System.Windows.Forms.Label labelEntrada;
        private System.Windows.Forms.Button bntEnviarEntrada;
        private System.Windows.Forms.Label labelSaida;
        private System.Windows.Forms.TextBox tboxSaida;
    }
}

