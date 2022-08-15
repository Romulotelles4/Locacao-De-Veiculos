namespace Locadora.Apresentacao.WinForm.ModuloCliente
{
    partial class TelaCadastroCliente
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
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelNome = new System.Windows.Forms.Label();
            this.textNome = new System.Windows.Forms.TextBox();
            this.labelCpf = new System.Windows.Forms.Label();
            this.labelCNPJ = new System.Windows.Forms.Label();
            this.labelEndereco = new System.Windows.Forms.Label();
            this.labelCNH = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textTelefone = new System.Windows.Forms.TextBox();
            this.labelTelefone = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.textId = new System.Windows.Forms.TextBox();
            this.groupBoxTipoCadastro = new System.Windows.Forms.GroupBox();
            this.radioPessoaJuridica = new System.Windows.Forms.RadioButton();
            this.radioPessoaFisica = new System.Windows.Forms.RadioButton();
            this.textCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.textCPF = new System.Windows.Forms.MaskedTextBox();
            this.textEndereco = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textCNH = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxTipoCadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInserir
            // 
            this.btnInserir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnInserir.Location = new System.Drawing.Point(71, 412);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(91, 33);
            this.btnInserir.TabIndex = 11;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(191, 412);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 33);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(12, 95);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(40, 15);
            this.labelNome.TabIndex = 2;
            this.labelNome.Text = "Nome";
            // 
            // textNome
            // 
            this.textNome.Location = new System.Drawing.Point(12, 113);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(324, 23);
            this.textNome.TabIndex = 4;
            // 
            // labelCpf
            // 
            this.labelCpf.AutoSize = true;
            this.labelCpf.Location = new System.Drawing.Point(12, 139);
            this.labelCpf.Name = "labelCpf";
            this.labelCpf.Size = new System.Drawing.Size(36, 15);
            this.labelCpf.TabIndex = 4;
            this.labelCpf.Text = "CPF *";
            // 
            // labelCNPJ
            // 
            this.labelCNPJ.AutoSize = true;
            this.labelCNPJ.Location = new System.Drawing.Point(12, 183);
            this.labelCNPJ.Name = "labelCNPJ";
            this.labelCNPJ.Size = new System.Drawing.Size(42, 15);
            this.labelCNPJ.TabIndex = 6;
            this.labelCNPJ.Text = "CNPJ *";
            // 
            // labelEndereco
            // 
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.Location = new System.Drawing.Point(12, 271);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelEndereco.Size = new System.Drawing.Size(56, 15);
            this.labelEndereco.TabIndex = 8;
            this.labelEndereco.Text = "Endereço";
            // 
            // labelCNH
            // 
            this.labelCNH.AutoSize = true;
            this.labelCNH.Location = new System.Drawing.Point(12, 227);
            this.labelCNH.Name = "labelCNH";
            this.labelCNH.Size = new System.Drawing.Size(33, 15);
            this.labelCNH.TabIndex = 10;
            this.labelCNH.Text = "CNH";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(12, 315);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(36, 15);
            this.labelEmail.TabIndex = 12;
            this.labelEmail.Text = "Email";
            // 
            // textTelefone
            // 
            this.textTelefone.Location = new System.Drawing.Point(12, 377);
            this.textTelefone.Name = "textTelefone";
            this.textTelefone.PlaceholderText = "(00) 0 0000-0000";
            this.textTelefone.Size = new System.Drawing.Size(92, 23);
            this.textTelefone.TabIndex = 10;
            this.textTelefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTelefone_KeyPress);
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Location = new System.Drawing.Point(12, 359);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(51, 15);
            this.labelTelefone.TabIndex = 14;
            this.labelTelefone.Text = "Telefone";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(12, 9);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(17, 15);
            this.labelId.TabIndex = 18;
            this.labelId.Text = "Id";
            // 
            // textId
            // 
            this.textId.Enabled = false;
            this.textId.Location = new System.Drawing.Point(12, 27);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(46, 23);
            this.textId.TabIndex = 19;
            this.textId.Text = "0";
            // 
            // groupBoxTipoCadastro
            // 
            this.groupBoxTipoCadastro.Controls.Add(this.radioPessoaJuridica);
            this.groupBoxTipoCadastro.Controls.Add(this.radioPessoaFisica);
            this.groupBoxTipoCadastro.Location = new System.Drawing.Point(12, 54);
            this.groupBoxTipoCadastro.Name = "groupBoxTipoCadastro";
            this.groupBoxTipoCadastro.Size = new System.Drawing.Size(237, 42);
            this.groupBoxTipoCadastro.TabIndex = 1;
            this.groupBoxTipoCadastro.TabStop = false;
            this.groupBoxTipoCadastro.Text = "Tipo Cadastro";
            // 
            // radioPessoaJuridica
            // 
            this.radioPessoaJuridica.AutoSize = true;
            this.radioPessoaJuridica.Location = new System.Drawing.Point(127, 19);
            this.radioPessoaJuridica.Name = "radioPessoaJuridica";
            this.radioPessoaJuridica.Size = new System.Drawing.Size(104, 19);
            this.radioPessoaJuridica.TabIndex = 3;
            this.radioPessoaJuridica.TabStop = true;
            this.radioPessoaJuridica.Text = "Pessoa Jurídica";
            this.radioPessoaJuridica.UseVisualStyleBackColor = true;
            this.radioPessoaJuridica.CheckedChanged += new System.EventHandler(this.radioPessoaJuridica_CheckedChanged);
            // 
            // radioPessoaFisica
            // 
            this.radioPessoaFisica.AutoSize = true;
            this.radioPessoaFisica.Location = new System.Drawing.Point(6, 19);
            this.radioPessoaFisica.Name = "radioPessoaFisica";
            this.radioPessoaFisica.Size = new System.Drawing.Size(93, 19);
            this.radioPessoaFisica.TabIndex = 2;
            this.radioPessoaFisica.TabStop = true;
            this.radioPessoaFisica.Text = "Pessoa Física";
            this.radioPessoaFisica.UseVisualStyleBackColor = true;
            this.radioPessoaFisica.CheckedChanged += new System.EventHandler(this.radioPessoaFisica_CheckedChanged);
            // 
            // textCNPJ
            // 
            this.textCNPJ.Enabled = false;
            this.textCNPJ.Location = new System.Drawing.Point(12, 201);
            this.textCNPJ.Mask = "00,000,000/0000-00";
            this.textCNPJ.Name = "textCNPJ";
            this.textCNPJ.Size = new System.Drawing.Size(111, 23);
            this.textCNPJ.TabIndex = 6;
            // 
            // textCPF
            // 
            this.textCPF.Enabled = false;
            this.textCPF.Location = new System.Drawing.Point(12, 157);
            this.textCPF.Mask = "000,000,000-00";
            this.textCPF.Name = "textCPF";
            this.textCPF.Size = new System.Drawing.Size(92, 23);
            this.textCPF.TabIndex = 5;
            // 
            // textEndereco
            // 
            this.textEndereco.Location = new System.Drawing.Point(12, 289);
            this.textEndereco.Name = "textEndereco";
            this.textEndereco.Size = new System.Drawing.Size(324, 23);
            this.textEndereco.TabIndex = 8;
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(12, 333);
            this.textEmail.Name = "textEmail";
            this.textEmail.PlaceholderText = "email@dominio.com";
            this.textEmail.Size = new System.Drawing.Size(324, 23);
            this.textEmail.TabIndex = 9;
            // 
            // textCNH
            // 
            this.textCNH.Location = new System.Drawing.Point(12, 245);
            this.textCNH.Mask = "00000000000";
            this.textCNH.Name = "textCNH";
            this.textCNH.Size = new System.Drawing.Size(76, 23);
            this.textCNH.TabIndex = 7;
            // 
            // TelaCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 454);
            this.Controls.Add(this.textCNH);
            this.Controls.Add(this.textCPF);
            this.Controls.Add(this.textCNPJ);
            this.Controls.Add(this.groupBoxTipoCadastro);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.textTelefone);
            this.Controls.Add(this.labelTelefone);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelCNH);
            this.Controls.Add(this.textEndereco);
            this.Controls.Add(this.labelEndereco);
            this.Controls.Add(this.labelCNPJ);
            this.Controls.Add(this.labelCpf);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnInserir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(368, 493);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(368, 493);
            this.Name = "TelaCadastroCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCadastroCliente";
            this.groupBoxTipoCadastro.ResumeLayout(false);
            this.groupBoxTipoCadastro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.Label labelCpf;
        private System.Windows.Forms.Label labelCNPJ;
        private System.Windows.Forms.Label labelEndereco;
        private System.Windows.Forms.Label labelCNH;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textTelefone;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.GroupBox groupBoxTipoCadastro;
        private System.Windows.Forms.RadioButton radioPessoaJuridica;
        private System.Windows.Forms.RadioButton radioPessoaFisica;
        private System.Windows.Forms.MaskedTextBox textCNPJ;
        private System.Windows.Forms.MaskedTextBox textCPF;
        private System.Windows.Forms.TextBox textEndereco;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.MaskedTextBox textCNH;
    }
}