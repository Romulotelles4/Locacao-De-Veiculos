namespace Locadora.Apresentacao.WinForm.ModuloGrupoDeVeiculos
{
    partial class TelaCadastroGrupoDeVeiculos
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gravarBtn = new System.Windows.Forms.Button();
            this.TextNomeDoGrupo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(186, 210);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 27);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // gravarBtn
            // 
            this.gravarBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.gravarBtn.Location = new System.Drawing.Point(106, 210);
            this.gravarBtn.Name = "gravarBtn";
            this.gravarBtn.Size = new System.Drawing.Size(74, 27);
            this.gravarBtn.TabIndex = 2;
            this.gravarBtn.Text = "Gravar";
            this.gravarBtn.UseVisualStyleBackColor = true;
            this.gravarBtn.Click += new System.EventHandler(this.gravarBtn_Click);
            // 
            // TextNomeDoGrupo
            // 
            this.TextNomeDoGrupo.Location = new System.Drawing.Point(12, 107);
            this.TextNomeDoGrupo.Name = "TextNomeDoGrupo";
            this.TextNomeDoGrupo.Size = new System.Drawing.Size(248, 23);
            this.TextNomeDoGrupo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome Do Grupo *";
            // 
            // txtBoxId
            // 
            this.txtBoxId.Enabled = false;
            this.txtBoxId.Location = new System.Drawing.Point(12, 43);
            this.txtBoxId.Name = "txtBoxId";
            this.txtBoxId.Size = new System.Drawing.Size(56, 23);
            this.txtBoxId.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "ID";
            // 
            // TelaCadastroGrupoDeVeiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 249);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextNomeDoGrupo);
            this.Controls.Add(this.gravarBtn);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(288, 288);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(288, 288);
            this.Name = "TelaCadastroGrupoDeVeiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Grupo De Veiculos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button gravarBtn;
        private System.Windows.Forms.TextBox TextNomeDoGrupo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxId;
        private System.Windows.Forms.Label label2;
    }
}