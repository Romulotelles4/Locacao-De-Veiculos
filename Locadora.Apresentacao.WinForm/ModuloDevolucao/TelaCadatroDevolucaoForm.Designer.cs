namespace Locadora.Apresentacao.WinForm.ModuloDevolucao
{
    partial class TelaCadatroDevolucaoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxValorTotal = new System.Windows.Forms.TextBox();
            this.dataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxLocacoes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor Total";
            // 
            // txtBoxValorTotal
            // 
            this.txtBoxValorTotal.Enabled = false;
            this.txtBoxValorTotal.Location = new System.Drawing.Point(12, 77);
            this.txtBoxValorTotal.Name = "txtBoxValorTotal";
            this.txtBoxValorTotal.Size = new System.Drawing.Size(75, 23);
            this.txtBoxValorTotal.TabIndex = 1;
            this.txtBoxValorTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxValorTotal_KeyPress);
            // 
            // dataDevolucao
            // 
            this.dataDevolucao.Location = new System.Drawing.Point(12, 121);
            this.dataDevolucao.Name = "dataDevolucao";
            this.dataDevolucao.Size = new System.Drawing.Size(243, 23);
            this.dataDevolucao.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data Devolução";
            // 
            // cBoxLocacoes
            // 
            this.cBoxLocacoes.FormattingEnabled = true;
            this.cBoxLocacoes.Location = new System.Drawing.Point(12, 33);
            this.cBoxLocacoes.Name = "cBoxLocacoes";
            this.cBoxLocacoes.Size = new System.Drawing.Size(301, 23);
            this.cBoxLocacoes.TabIndex = 4;
            this.cBoxLocacoes.SelectedIndexChanged += new System.EventHandler(this.cBoxLocacoes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Locação";
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(30, 198);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(91, 33);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "[label]";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(180, 198);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 33);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaCadatroDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 245);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cBoxLocacoes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataDevolucao);
            this.Controls.Add(this.txtBoxValorTotal);
            this.Controls.Add(this.label1);
            this.Name = "TelaCadatroDevolucaoForm";
            this.Text = "TelaCadatroDevolucaoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxValorTotal;
        private System.Windows.Forms.DateTimePicker dataDevolucao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBoxLocacoes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
    }
}