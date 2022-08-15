namespace Locadora.Apresentacao.WinForm.ModuloLocacao
{
    partial class TelaFiltroLocacaoForm
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
            this.groupBoxFiltro = new System.Windows.Forms.GroupBox();
            this.rBtnCanceladas = new System.Windows.Forms.RadioButton();
            this.rBtnFinalizada = new System.Windows.Forms.RadioButton();
            this.rBtnAbertas = new System.Windows.Forms.RadioButton();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFiltro
            // 
            this.groupBoxFiltro.Controls.Add(this.rBtnCanceladas);
            this.groupBoxFiltro.Controls.Add(this.rBtnFinalizada);
            this.groupBoxFiltro.Controls.Add(this.rBtnAbertas);
            this.groupBoxFiltro.Location = new System.Drawing.Point(115, 34);
            this.groupBoxFiltro.Name = "groupBoxFiltro";
            this.groupBoxFiltro.Size = new System.Drawing.Size(234, 181);
            this.groupBoxFiltro.TabIndex = 1;
            this.groupBoxFiltro.TabStop = false;
            this.groupBoxFiltro.Text = "Filtrar Locações";
            // 
            // rBtnCanceladas
            // 
            this.rBtnCanceladas.AutoSize = true;
            this.rBtnCanceladas.Location = new System.Drawing.Point(79, 110);
            this.rBtnCanceladas.Name = "rBtnCanceladas";
            this.rBtnCanceladas.Size = new System.Drawing.Size(85, 19);
            this.rBtnCanceladas.TabIndex = 3;
            this.rBtnCanceladas.TabStop = true;
            this.rBtnCanceladas.Text = "Canceladas";
            this.rBtnCanceladas.UseVisualStyleBackColor = true;
            // 
            // rBtnFinalizada
            // 
            this.rBtnFinalizada.AutoSize = true;
            this.rBtnFinalizada.Location = new System.Drawing.Point(79, 85);
            this.rBtnFinalizada.Name = "rBtnFinalizada";
            this.rBtnFinalizada.Size = new System.Drawing.Size(82, 19);
            this.rBtnFinalizada.TabIndex = 2;
            this.rBtnFinalizada.TabStop = true;
            this.rBtnFinalizada.Text = "Finalizadas";
            this.rBtnFinalizada.UseVisualStyleBackColor = true;
            // 
            // rBtnAbertas
            // 
            this.rBtnAbertas.AutoSize = true;
            this.rBtnAbertas.Location = new System.Drawing.Point(79, 60);
            this.rBtnAbertas.Name = "rBtnAbertas";
            this.rBtnAbertas.Size = new System.Drawing.Size(65, 19);
            this.rBtnAbertas.TabIndex = 1;
            this.rBtnAbertas.TabStop = true;
            this.rBtnAbertas.Text = "Abertas";
            this.rBtnAbertas.UseVisualStyleBackColor = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFiltrar.Location = new System.Drawing.Point(96, 243);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(90, 36);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(286, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 296);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.groupBoxFiltro);
            this.Name = "TelaFiltroLocacaoForm";
            this.Text = "Filtros de Locação";
            this.groupBoxFiltro.ResumeLayout(false);
            this.groupBoxFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFiltro;
        private System.Windows.Forms.RadioButton rBtnCanceladas;
        private System.Windows.Forms.RadioButton rBtnFinalizada;
        private System.Windows.Forms.RadioButton rBtnAbertas;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCancel;
    }
}