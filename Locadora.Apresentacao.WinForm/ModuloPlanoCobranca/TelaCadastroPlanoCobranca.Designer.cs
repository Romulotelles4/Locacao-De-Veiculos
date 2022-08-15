namespace Locadora.Apresentacao.WinForm.ModuloPlanoCobranca
{
    partial class TelaCadastroPlanoCobranca
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
            this.comboBoxGrupoVeiculo = new System.Windows.Forms.ComboBox();
            this.groupBoxDiario = new System.Windows.Forms.GroupBox();
            this.txtBoxDiarioPorKm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxDiarioDiaria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxLivre = new System.Windows.Forms.GroupBox();
            this.txtBoxLivreDiaria = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxControlado = new System.Windows.Forms.GroupBox();
            this.txtBoxControladoLimteKm = new System.Windows.Forms.TextBox();
            this.txtBoxControladoPorKm = new System.Windows.Forms.TextBox();
            this.txtBoxControladoDiaria = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtBoxId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxDiario.SuspendLayout();
            this.groupBoxLivre.SuspendLayout();
            this.groupBoxControlado.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "*Grupo de veículo";
            // 
            // comboBoxGrupoVeiculo
            // 
            this.comboBoxGrupoVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrupoVeiculo.FormattingEnabled = true;
            this.comboBoxGrupoVeiculo.Location = new System.Drawing.Point(12, 71);
            this.comboBoxGrupoVeiculo.Name = "comboBoxGrupoVeiculo";
            this.comboBoxGrupoVeiculo.Size = new System.Drawing.Size(230, 23);
            this.comboBoxGrupoVeiculo.TabIndex = 1;
            // 
            // groupBoxDiario
            // 
            this.groupBoxDiario.Controls.Add(this.txtBoxDiarioPorKm);
            this.groupBoxDiario.Controls.Add(this.label3);
            this.groupBoxDiario.Controls.Add(this.txtBoxDiarioDiaria);
            this.groupBoxDiario.Controls.Add(this.label2);
            this.groupBoxDiario.Location = new System.Drawing.Point(139, 100);
            this.groupBoxDiario.Name = "groupBoxDiario";
            this.groupBoxDiario.Size = new System.Drawing.Size(105, 115);
            this.groupBoxDiario.TabIndex = 6;
            this.groupBoxDiario.TabStop = false;
            this.groupBoxDiario.Text = "Diário";
            // 
            // txtBoxDiarioPorKm
            // 
            this.txtBoxDiarioPorKm.Location = new System.Drawing.Point(6, 81);
            this.txtBoxDiarioPorKm.Name = "txtBoxDiarioPorKm";
            this.txtBoxDiarioPorKm.Size = new System.Drawing.Size(91, 23);
            this.txtBoxDiarioPorKm.TabIndex = 8;
            this.txtBoxDiarioPorKm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxDiarioPorKm_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Diária";
            // 
            // txtBoxDiarioDiaria
            // 
            this.txtBoxDiarioDiaria.Location = new System.Drawing.Point(6, 37);
            this.txtBoxDiarioDiaria.Name = "txtBoxDiarioDiaria";
            this.txtBoxDiarioDiaria.Size = new System.Drawing.Size(91, 23);
            this.txtBoxDiarioDiaria.TabIndex = 7;
            this.txtBoxDiarioDiaria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxDiarioDiaria_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Valor por KM";
            // 
            // groupBoxLivre
            // 
            this.groupBoxLivre.Controls.Add(this.txtBoxLivreDiaria);
            this.groupBoxLivre.Controls.Add(this.label4);
            this.groupBoxLivre.Location = new System.Drawing.Point(250, 100);
            this.groupBoxLivre.Name = "groupBoxLivre";
            this.groupBoxLivre.Size = new System.Drawing.Size(106, 71);
            this.groupBoxLivre.TabIndex = 9;
            this.groupBoxLivre.TabStop = false;
            this.groupBoxLivre.Text = "Livre";
            // 
            // txtBoxLivreDiaria
            // 
            this.txtBoxLivreDiaria.Location = new System.Drawing.Point(6, 37);
            this.txtBoxLivreDiaria.Name = "txtBoxLivreDiaria";
            this.txtBoxLivreDiaria.Size = new System.Drawing.Size(91, 23);
            this.txtBoxLivreDiaria.TabIndex = 10;
            this.txtBoxLivreDiaria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxLivreDiaria_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Diária";
            // 
            // groupBoxControlado
            // 
            this.groupBoxControlado.Controls.Add(this.txtBoxControladoLimteKm);
            this.groupBoxControlado.Controls.Add(this.txtBoxControladoPorKm);
            this.groupBoxControlado.Controls.Add(this.txtBoxControladoDiaria);
            this.groupBoxControlado.Controls.Add(this.label8);
            this.groupBoxControlado.Controls.Add(this.label7);
            this.groupBoxControlado.Controls.Add(this.label6);
            this.groupBoxControlado.Location = new System.Drawing.Point(12, 100);
            this.groupBoxControlado.Name = "groupBoxControlado";
            this.groupBoxControlado.Size = new System.Drawing.Size(121, 166);
            this.groupBoxControlado.TabIndex = 2;
            this.groupBoxControlado.TabStop = false;
            this.groupBoxControlado.Text = "Controlado";
            // 
            // txtBoxControladoLimteKm
            // 
            this.txtBoxControladoLimteKm.Location = new System.Drawing.Point(6, 125);
            this.txtBoxControladoLimteKm.Name = "txtBoxControladoLimteKm";
            this.txtBoxControladoLimteKm.Size = new System.Drawing.Size(91, 23);
            this.txtBoxControladoLimteKm.TabIndex = 5;
            this.txtBoxControladoLimteKm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxControladoLimteKm_KeyPress);
            // 
            // txtBoxControladoPorKm
            // 
            this.txtBoxControladoPorKm.Location = new System.Drawing.Point(6, 81);
            this.txtBoxControladoPorKm.Name = "txtBoxControladoPorKm";
            this.txtBoxControladoPorKm.Size = new System.Drawing.Size(91, 23);
            this.txtBoxControladoPorKm.TabIndex = 4;
            this.txtBoxControladoPorKm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxControladoPorKm_KeyPress);
            // 
            // txtBoxControladoDiaria
            // 
            this.txtBoxControladoDiaria.Location = new System.Drawing.Point(6, 37);
            this.txtBoxControladoDiaria.Name = "txtBoxControladoDiaria";
            this.txtBoxControladoDiaria.Size = new System.Drawing.Size(91, 23);
            this.txtBoxControladoDiaria.TabIndex = 3;
            this.txtBoxControladoDiaria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxControladoDiaria_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Limite de KM";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Valor por KM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Diária";
            // 
            // btnInserir
            // 
            this.btnInserir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnInserir.Location = new System.Drawing.Point(55, 285);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(90, 36);
            this.btnInserir.TabIndex = 11;
            this.btnInserir.Text = "[label]";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(231, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 36);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtBoxId
            // 
            this.txtBoxId.Enabled = false;
            this.txtBoxId.Location = new System.Drawing.Point(12, 27);
            this.txtBoxId.Name = "txtBoxId";
            this.txtBoxId.Size = new System.Drawing.Size(52, 23);
            this.txtBoxId.TabIndex = 11;
            this.txtBoxId.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "ID";
            // 
            // TelaCadastroPlanoCobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 332);
            this.Controls.Add(this.txtBoxId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.groupBoxControlado);
            this.Controls.Add(this.groupBoxLivre);
            this.Controls.Add(this.groupBoxDiario);
            this.Controls.Add(this.comboBoxGrupoVeiculo);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(384, 371);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(384, 371);
            this.Name = "TelaCadastroPlanoCobranca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plano de Cobrança";
            this.groupBoxDiario.ResumeLayout(false);
            this.groupBoxDiario.PerformLayout();
            this.groupBoxLivre.ResumeLayout(false);
            this.groupBoxLivre.PerformLayout();
            this.groupBoxControlado.ResumeLayout(false);
            this.groupBoxControlado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxGrupoVeiculo;
        private System.Windows.Forms.GroupBox groupBoxDiario;
        private System.Windows.Forms.GroupBox groupBoxLivre;
        private System.Windows.Forms.GroupBox groupBoxControlado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxDiarioPorKm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxDiarioDiaria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxLivreDiaria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxControladoLimteKm;
        private System.Windows.Forms.TextBox txtBoxControladoPorKm;
        private System.Windows.Forms.TextBox txtBoxControladoDiaria;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtBoxId;
        private System.Windows.Forms.Label label5;
    }
}