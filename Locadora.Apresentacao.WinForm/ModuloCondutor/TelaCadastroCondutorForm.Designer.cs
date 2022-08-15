namespace Locadora.Apresentacao.WinForm.ModuloCondutor
{
    partial class TelaCadastroCondutorForm
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
            this.txtBoxId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxEndereco = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cBoxCliente = new System.Windows.Forms.ComboBox();
            this.checkBoxCliente = new System.Windows.Forms.CheckBox();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtBoxEmail = new System.Windows.Forms.TextBox();
            this.txtBoxTelefone = new System.Windows.Forms.TextBox();
            this.maskedTxtBoxCpf = new System.Windows.Forms.MaskedTextBox();
            this.maskedTxtBoxCnh = new System.Windows.Forms.MaskedTextBox();
            this.limparCamposLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtBoxId
            // 
            this.txtBoxId.Enabled = false;
            this.txtBoxId.Location = new System.Drawing.Point(12, 27);
            this.txtBoxId.Name = "txtBoxId";
            this.txtBoxId.Size = new System.Drawing.Size(44, 23);
            this.txtBoxId.TabIndex = 1;
            this.txtBoxId.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente";
            // 
            // txtBoxNome
            // 
            this.txtBoxNome.Location = new System.Drawing.Point(12, 143);
            this.txtBoxNome.Name = "txtBoxNome";
            this.txtBoxNome.Size = new System.Drawing.Size(292, 23);
            this.txtBoxNome.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "CPF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "CNH";
            // 
            // txtBoxEndereco
            // 
            this.txtBoxEndereco.Location = new System.Drawing.Point(12, 276);
            this.txtBoxEndereco.Name = "txtBoxEndereco";
            this.txtBoxEndereco.Size = new System.Drawing.Size(292, 23);
            this.txtBoxEndereco.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Endereço";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 346);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Telefone";
            // 
            // cBoxCliente
            // 
            this.cBoxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCliente.FormattingEnabled = true;
            this.cBoxCliente.Location = new System.Drawing.Point(12, 71);
            this.cBoxCliente.Name = "cBoxCliente";
            this.cBoxCliente.Size = new System.Drawing.Size(292, 23);
            this.cBoxCliente.TabIndex = 1;
            // 
            // checkBoxCliente
            // 
            this.checkBoxCliente.AutoSize = true;
            this.checkBoxCliente.Location = new System.Drawing.Point(12, 100);
            this.checkBoxCliente.Name = "checkBoxCliente";
            this.checkBoxCliente.Size = new System.Drawing.Size(122, 19);
            this.checkBoxCliente.TabIndex = 2;
            this.checkBoxCliente.Text = "Usar dados cliente";
            this.checkBoxCliente.UseVisualStyleBackColor = true;
            this.checkBoxCliente.CheckedChanged += new System.EventHandler(this.checkBoxCliente_CheckedChanged);
            // 
            // btnInserir
            // 
            this.btnInserir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnInserir.Location = new System.Drawing.Point(32, 411);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(90, 36);
            this.btnInserir.TabIndex = 10;
            this.btnInserir.Text = "[label]";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(197, 411);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 36);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtBoxEmail
            // 
            this.txtBoxEmail.Location = new System.Drawing.Point(12, 320);
            this.txtBoxEmail.Name = "txtBoxEmail";
            this.txtBoxEmail.PlaceholderText = "email@dominio.com";
            this.txtBoxEmail.Size = new System.Drawing.Size(292, 23);
            this.txtBoxEmail.TabIndex = 8;
            // 
            // txtBoxTelefone
            // 
            this.txtBoxTelefone.Location = new System.Drawing.Point(12, 364);
            this.txtBoxTelefone.Name = "txtBoxTelefone";
            this.txtBoxTelefone.PlaceholderText = "(00) 0 0000-0000";
            this.txtBoxTelefone.Size = new System.Drawing.Size(99, 23);
            this.txtBoxTelefone.TabIndex = 9;
            this.txtBoxTelefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxTelefone_KeyPress);
            // 
            // maskedTxtBoxCpf
            // 
            this.maskedTxtBoxCpf.Location = new System.Drawing.Point(12, 187);
            this.maskedTxtBoxCpf.Mask = "000,000,000-00";
            this.maskedTxtBoxCpf.Name = "maskedTxtBoxCpf";
            this.maskedTxtBoxCpf.Size = new System.Drawing.Size(100, 23);
            this.maskedTxtBoxCpf.TabIndex = 5;
            // 
            // maskedTxtBoxCnh
            // 
            this.maskedTxtBoxCnh.Location = new System.Drawing.Point(12, 232);
            this.maskedTxtBoxCnh.Mask = "00000000000";
            this.maskedTxtBoxCnh.Name = "maskedTxtBoxCnh";
            this.maskedTxtBoxCnh.Size = new System.Drawing.Size(100, 23);
            this.maskedTxtBoxCnh.TabIndex = 6;
            // 
            // limparCamposLinkLabel
            // 
            this.limparCamposLinkLabel.AutoSize = true;
            this.limparCamposLinkLabel.LinkColor = System.Drawing.Color.DimGray;
            this.limparCamposLinkLabel.Location = new System.Drawing.Point(213, 101);
            this.limparCamposLinkLabel.Name = "limparCamposLinkLabel";
            this.limparCamposLinkLabel.Size = new System.Drawing.Size(91, 15);
            this.limparCamposLinkLabel.TabIndex = 3;
            this.limparCamposLinkLabel.TabStop = true;
            this.limparCamposLinkLabel.Text = "Limpar Campos";
            this.limparCamposLinkLabel.Click += new System.EventHandler(this.limparCamposLinkLabel_Click);
            // 
            // TelaCadastroCondutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 459);
            this.Controls.Add(this.limparCamposLinkLabel);
            this.Controls.Add(this.maskedTxtBoxCnh);
            this.Controls.Add(this.maskedTxtBoxCpf);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.checkBoxCliente);
            this.Controls.Add(this.cBoxCliente);
            this.Controls.Add(this.txtBoxTelefone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBoxEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBoxEndereco);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxId);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroCondutorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCadastroCondutorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxEndereco;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cBoxCliente;
        private System.Windows.Forms.CheckBox checkBoxCliente;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtBoxEmail;
        private System.Windows.Forms.TextBox txtBoxTelefone;
        private System.Windows.Forms.MaskedTextBox maskedTxtBoxCpf;
        private System.Windows.Forms.MaskedTextBox maskedTxtBoxCnh;
        private System.Windows.Forms.LinkLabel limparCamposLinkLabel;
    }
}