namespace Locadora.Apresentacao.WinForm.ModuloFuncionario
{
    partial class TelaCadastroFuncionarioForm
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
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxSenha = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxTipoFuncionario = new System.Windows.Forms.GroupBox();
            this.rBtnAdministrador = new System.Windows.Forms.RadioButton();
            this.rBtnComum = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxSalario = new System.Windows.Forms.TextBox();
            this.checkBoxMostrarSenha = new System.Windows.Forms.CheckBox();
            this.dtPickerDataEntrada = new System.Windows.Forms.DateTimePicker();
            this.groupBoxTipoFuncionario.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxID
            // 
            this.txtBoxID.Enabled = false;
            this.txtBoxID.Location = new System.Drawing.Point(12, 27);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(33, 23);
            this.txtBoxID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome *";
            // 
            // txtBoxNome
            // 
            this.txtBoxNome.Location = new System.Drawing.Point(12, 71);
            this.txtBoxNome.Name = "txtBoxNome";
            this.txtBoxNome.Size = new System.Drawing.Size(175, 23);
            this.txtBoxNome.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Login *";
            // 
            // txtBoxLogin
            // 
            this.txtBoxLogin.Location = new System.Drawing.Point(12, 115);
            this.txtBoxLogin.Name = "txtBoxLogin";
            this.txtBoxLogin.Size = new System.Drawing.Size(175, 23);
            this.txtBoxLogin.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Senha";
            // 
            // txtBoxSenha
            // 
            this.txtBoxSenha.Location = new System.Drawing.Point(12, 159);
            this.txtBoxSenha.Name = "txtBoxSenha";
            this.txtBoxSenha.Size = new System.Drawing.Size(175, 23);
            this.txtBoxSenha.TabIndex = 3;
            // 
            // btnSalvar
            // 
            this.btnSalvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvar.Location = new System.Drawing.Point(12, 373);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 36);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "Inserir";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(163, 373);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 36);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Data Cadastro";
            // 
            // groupBoxTipoFuncionario
            // 
            this.groupBoxTipoFuncionario.Controls.Add(this.rBtnAdministrador);
            this.groupBoxTipoFuncionario.Controls.Add(this.rBtnComum);
            this.groupBoxTipoFuncionario.Location = new System.Drawing.Point(11, 301);
            this.groupBoxTipoFuncionario.Name = "groupBoxTipoFuncionario";
            this.groupBoxTipoFuncionario.Size = new System.Drawing.Size(249, 52);
            this.groupBoxTipoFuncionario.TabIndex = 7;
            this.groupBoxTipoFuncionario.TabStop = false;
            this.groupBoxTipoFuncionario.Text = "Tipo Funcionario";
            // 
            // rBtnAdministrador
            // 
            this.rBtnAdministrador.AutoSize = true;
            this.rBtnAdministrador.Location = new System.Drawing.Point(141, 21);
            this.rBtnAdministrador.Name = "rBtnAdministrador";
            this.rBtnAdministrador.Size = new System.Drawing.Size(101, 19);
            this.rBtnAdministrador.TabIndex = 9;
            this.rBtnAdministrador.TabStop = true;
            this.rBtnAdministrador.Text = "Administrador";
            this.rBtnAdministrador.UseVisualStyleBackColor = true;
            // 
            // rBtnComum
            // 
            this.rBtnComum.AutoSize = true;
            this.rBtnComum.Checked = true;
            this.rBtnComum.Location = new System.Drawing.Point(21, 22);
            this.rBtnComum.Name = "rBtnComum";
            this.rBtnComum.Size = new System.Drawing.Size(69, 19);
            this.rBtnComum.TabIndex = 8;
            this.rBtnComum.TabStop = true;
            this.rBtnComum.Text = "Comum";
            this.rBtnComum.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Salário";
            // 
            // txtBoxSalario
            // 
            this.txtBoxSalario.Location = new System.Drawing.Point(11, 272);
            this.txtBoxSalario.Name = "txtBoxSalario";
            this.txtBoxSalario.Size = new System.Drawing.Size(101, 23);
            this.txtBoxSalario.TabIndex = 6;
            this.txtBoxSalario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxSalario_KeyPress);
            // 
            // checkBoxMostrarSenha
            // 
            this.checkBoxMostrarSenha.AutoSize = true;
            this.checkBoxMostrarSenha.Location = new System.Drawing.Point(12, 188);
            this.checkBoxMostrarSenha.Name = "checkBoxMostrarSenha";
            this.checkBoxMostrarSenha.Size = new System.Drawing.Size(101, 19);
            this.checkBoxMostrarSenha.TabIndex = 4;
            this.checkBoxMostrarSenha.Text = "Mostrar senha";
            this.checkBoxMostrarSenha.UseVisualStyleBackColor = true;
            this.checkBoxMostrarSenha.CheckedChanged += new System.EventHandler(this.checkBoxMostrarSenha_CheckedChanged);
            // 
            // dtPickerDataEntrada
            // 
            this.dtPickerDataEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerDataEntrada.Location = new System.Drawing.Point(12, 228);
            this.dtPickerDataEntrada.Name = "dtPickerDataEntrada";
            this.dtPickerDataEntrada.Size = new System.Drawing.Size(101, 23);
            this.dtPickerDataEntrada.TabIndex = 5;
            // 
            // TelaCadastroFuncionarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(270, 421);
            this.Controls.Add(this.dtPickerDataEntrada);
            this.Controls.Add(this.checkBoxMostrarSenha);
            this.Controls.Add(this.txtBoxSalario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBoxTipoFuncionario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxSenha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxID);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(286, 460);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(286, 460);
            this.Name = "TelaCadastroFuncionarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Funcionário";
            this.groupBoxTipoFuncionario.ResumeLayout(false);
            this.groupBoxTipoFuncionario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxSenha;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxTipoFuncionario;
        private System.Windows.Forms.RadioButton rBtnAdministrador;
        private System.Windows.Forms.RadioButton rBtnComum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxSalario;
        private System.Windows.Forms.CheckBox checkBoxMostrarSenha;
        private System.Windows.Forms.DateTimePicker dtPickerDataEntrada;
    }
}