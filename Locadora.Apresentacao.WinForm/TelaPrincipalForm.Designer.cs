namespace Locadora.Apresentacao.WinForm
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.MenuStrip();
            this.taxaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grupoVeiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condutoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planoDeCobrançaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbox = new System.Windows.Forms.ToolStrip();
            this.btnInserir = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnVisualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGerarPdf = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.statusStripMensagem = new System.Windows.Forms.StatusStrip();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.devoluçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem.SuspendLayout();
            this.toolbox.SuspendLayout();
            this.statusStripMensagem.SuspendLayout();
            this.SuspendLayout();
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taxaToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Location = new System.Drawing.Point(0, 0);
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(800, 24);
            this.cadastrosToolStripMenuItem.TabIndex = 2;
            this.cadastrosToolStripMenuItem.Text = "cadastrosToolStripMenuItem";
            // 
            // taxaToolStripMenuItem
            // 
            this.taxaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taxaToolStripMenuItem1,
            this.grupoVeiculosToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.funcionarioToolStripMenuItem,
            this.condutoresToolStripMenuItem,
            this.planoDeCobrançaToolStripMenuItem,
            this.veículosToolStripMenuItem,
            this.locaçãoToolStripMenuItem,
            this.devoluçãoToolStripMenuItem});
            this.taxaToolStripMenuItem.Name = "taxaToolStripMenuItem";
            this.taxaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.taxaToolStripMenuItem.Text = "Cadastro";
            // 
            // taxaToolStripMenuItem1
            // 
            this.taxaToolStripMenuItem1.Name = "taxaToolStripMenuItem1";
            this.taxaToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.taxaToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.taxaToolStripMenuItem1.Text = "Taxa";
            this.taxaToolStripMenuItem1.Click += new System.EventHandler(this.taxaToolStripMenuItem1_Click);
            // 
            // grupoVeiculosToolStripMenuItem
            // 
            this.grupoVeiculosToolStripMenuItem.Name = "grupoVeiculosToolStripMenuItem";
            this.grupoVeiculosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.grupoVeiculosToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.grupoVeiculosToolStripMenuItem.Text = "Grupo Veículos";
            this.grupoVeiculosToolStripMenuItem.Click += new System.EventHandler(this.grupoVeiculosToolStripMenuItem_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // funcionarioToolStripMenuItem
            // 
            this.funcionarioToolStripMenuItem.Name = "funcionarioToolStripMenuItem";
            this.funcionarioToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.funcionarioToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.funcionarioToolStripMenuItem.Text = "Funcionário";
            this.funcionarioToolStripMenuItem.Click += new System.EventHandler(this.funcionarioToolStripMenuItem_Click);
            // 
            // condutoresToolStripMenuItem
            // 
            this.condutoresToolStripMenuItem.Name = "condutoresToolStripMenuItem";
            this.condutoresToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.condutoresToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.condutoresToolStripMenuItem.Text = "Condutores";
            this.condutoresToolStripMenuItem.Click += new System.EventHandler(this.condutoresToolStripMenuItem_Click);
            // 
            // planoDeCobrançaToolStripMenuItem
            // 
            this.planoDeCobrançaToolStripMenuItem.Name = "planoDeCobrançaToolStripMenuItem";
            this.planoDeCobrançaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F6)));
            this.planoDeCobrançaToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.planoDeCobrançaToolStripMenuItem.Text = "Plano de Cobrança";
            this.planoDeCobrançaToolStripMenuItem.Click += new System.EventHandler(this.planoDeCobrançaToolStripMenuItem_Click);
            // 
            // veículosToolStripMenuItem
            // 
            this.veículosToolStripMenuItem.Name = "veículosToolStripMenuItem";
            this.veículosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F7)));
            this.veículosToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.veículosToolStripMenuItem.Text = "Veículos";
            this.veículosToolStripMenuItem.Click += new System.EventHandler(this.veículosToolStripMenuItem_Click);
            // 
            // locaçãoToolStripMenuItem
            // 
            this.locaçãoToolStripMenuItem.Name = "locaçãoToolStripMenuItem";
            this.locaçãoToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.locaçãoToolStripMenuItem.Text = "Locação";
            this.locaçãoToolStripMenuItem.Click += new System.EventHandler(this.locaçãoToolStripMenuItem_Click);
            // 
            // toolbox
            // 
            this.toolbox.Enabled = false;
            this.toolbox.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInserir,
            this.btnEditar,
            this.btnExcluir,
            this.toolStripSeparator2,
            this.btnVisualizar,
            this.toolStripSeparator3,
            this.btnGerarPdf,
            this.toolStripSeparator1,
            this.btnFiltrar,
            this.toolStripSeparator4,
            this.labelTipoCadastro});
            this.toolbox.Location = new System.Drawing.Point(0, 24);
            this.toolbox.Name = "toolbox";
            this.toolbox.Size = new System.Drawing.Size(800, 41);
            this.toolbox.TabIndex = 3;
            this.toolbox.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            this.btnInserir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInserir.Image = global::Locadora.Apresentacao.WinForm.Properties.Resources.add;
            this.btnInserir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Padding = new System.Windows.Forms.Padding(5);
            this.btnInserir.Size = new System.Drawing.Size(38, 38);
            this.btnInserir.Text = "Inserir";
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = global::Locadora.Apresentacao.WinForm.Properties.Resources.edit;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(5);
            this.btnEditar.Size = new System.Drawing.Size(38, 38);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcluir.Image = global::Locadora.Apresentacao.WinForm.Properties.Resources.trash;
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Padding = new System.Windows.Forms.Padding(5);
            this.btnExcluir.Size = new System.Drawing.Size(38, 38);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVisualizar.Image = global::Locadora.Apresentacao.WinForm.Properties.Resources.verify;
            this.btnVisualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnVisualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Padding = new System.Windows.Forms.Padding(5);
            this.btnVisualizar.Size = new System.Drawing.Size(38, 38);
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // btnGerarPdf
            // 
            this.btnGerarPdf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGerarPdf.Image = global::Locadora.Apresentacao.WinForm.Properties.Resources.icon_pdf;
            this.btnGerarPdf.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGerarPdf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGerarPdf.Name = "btnGerarPdf";
            this.btnGerarPdf.Padding = new System.Windows.Forms.Padding(5);
            this.btnGerarPdf.Size = new System.Drawing.Size(38, 38);
            this.btnGerarPdf.Click += new System.EventHandler(this.btnGerarPdf_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFiltrar.Image = global::Locadora.Apresentacao.WinForm.Properties.Resources.filter;
            this.btnFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Padding = new System.Windows.Forms.Padding(5);
            this.btnFiltrar.Size = new System.Drawing.Size(38, 38);
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(90, 38);
            this.labelTipoCadastro.Text = "[tipoCadastro]";
            // 
            // panelRegistros
            // 
            this.panelRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegistros.Location = new System.Drawing.Point(0, 65);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(800, 385);
            this.panelRegistros.TabIndex = 4;
            // 
            // statusStripMensagem
            // 
            this.statusStripMensagem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMensagem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodape});
            this.statusStripMensagem.Location = new System.Drawing.Point(0, 428);
            this.statusStripMensagem.Name = "statusStripMensagem";
            this.statusStripMensagem.Size = new System.Drawing.Size(800, 22);
            this.statusStripMensagem.TabIndex = 5;
            this.statusStripMensagem.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(52, 17);
            this.labelRodape.Text = "[rodapé]";
            // 
            // devoluçãoToolStripMenuItem
            // 
            this.devoluçãoToolStripMenuItem.Name = "devoluçãoToolStripMenuItem";
            this.devoluçãoToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.devoluçãoToolStripMenuItem.Text = "Devolução";
            this.devoluçãoToolStripMenuItem.Click += new System.EventHandler(this.devoluçãoToolStripMenuItem_Click);
            // 
            // TelaPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStripMensagem);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.toolbox);
            this.Controls.Add(this.cadastrosToolStripMenuItem);
            this.Name = "TelaPrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locadora de Veículos Rech";
            this.cadastrosToolStripMenuItem.ResumeLayout(false);
            this.cadastrosToolStripMenuItem.PerformLayout();
            this.toolbox.ResumeLayout(false);
            this.toolbox.PerformLayout();
            this.statusStripMensagem.ResumeLayout(false);
            this.statusStripMensagem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem grupoVeiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionarioToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolbox;
        private System.Windows.Forms.ToolStripButton btnInserir;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnVisualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnGerarPdf;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFiltrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.StatusStrip statusStripMensagem;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.ToolStripMenuItem condutoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planoDeCobrançaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devoluçãoToolStripMenuItem;
    }
}
