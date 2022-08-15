using FluentResults;
using Locadora.Dominio.ModuloCarro;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloVeiculo
{
    public partial class TelaVeiculo : Form
    {
        Veiculo _veiculo;
        List<GrupoVeiculo> GruposVeiculos;
        List<EnumTipoDeCombustivel> tipoDeCombustivel;
        string caminhoFoto;


        public TelaVeiculo(List<GrupoVeiculo> grupoVeiculos, string titulo, string label)
        {
            InitializeComponent();

            this.GruposVeiculos = grupoVeiculos;
            this.tipoDeCombustivel=new List<EnumTipoDeCombustivel>();

            Text = titulo;
            btnInserir.Text = label;

            EncherComboBoxGrupoVeiculo(GruposVeiculos);
        }

        public Veiculo Veiculo
        {
            get
            {
                return _veiculo;
            }
            set
            {
                _veiculo = value;
                ConfigurarTela();
            }
        }
        public Func<Veiculo, Result<Veiculo>> GravarRegistro { get; set; }

        private void ConfigurarTela()
        {
            textBoxId.Text = Veiculo.Id.ToString();
            textBoxPlaca.Text = Veiculo.Placa == null ? "" : Veiculo.Placa;
            textBoxModelo.Text = Veiculo.Modelo == null ? "" : Veiculo.Modelo;
            textBoxMarca.Text = Veiculo.Marca == null ? "" : Veiculo.Marca;
            textBoxCor.Text = Veiculo.Cor == null ? "" : Veiculo.Cor;


            textBoxKmPercorrido.Text = Veiculo.KmPercorrido == null ? "" : string.Format("{0:#,##0.00}", Double.Parse(Veiculo.KmPercorrido.ToString()));
            TextBoxCapacidadeTanque.Text = Veiculo.CapacidadeTanque == null ? "" : string.Format("{0:#,##0.00}", Double.Parse(Veiculo.CapacidadeTanque.ToString()));

            comboBoxGrupoVeiculo.SelectedItem =Veiculo.GrupoDeVeiculo==null ? null : (GrupoVeiculo)Veiculo.GrupoDeVeiculo;
            comboBoxTipoCombustivel.SelectedItem = Veiculo.TipoDeCombustivel == null ? null : Veiculo.TipoDeCombustivel.ToString();
            carregarFoto();



        }
        private void ConfigurarObjeto()
        {
            _veiculo.Cor=textBoxCor.Text;
            _veiculo.Placa=textBoxPlaca.Text;
            _veiculo.Modelo=textBoxModelo.Text;
            _veiculo.Marca=textBoxMarca.Text;
            _veiculo.GrupoDeVeiculo = (GrupoVeiculo)comboBoxGrupoVeiculo.SelectedItem;
            _veiculo.TipoDeCombustivel=  (EnumTipoDeCombustivel)Enum.Parse(typeof(EnumTipoDeCombustivel), SelecionarEnum());
            _veiculo.CapacidadeTanque=Convert.ToDecimal(TextBoxCapacidadeTanque.Text);
            _veiculo.KmPercorrido = Convert.ToDecimal(textBoxKmPercorrido.Text);
            _veiculo.Foto= converterFoto();


        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (ExisteCampoVazio())
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Preencha todos os campos");

                DialogResult = DialogResult.None;

                return;
            }

            ConfigurarObjeto();

            var resultadoValidacao = GravarRegistro(Veiculo);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no Sistema"))
                {
                    MessageBox.Show("Falha no Sistema",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private bool ExisteCampoVazio()
        {
            if (string.IsNullOrEmpty(textBoxPlaca.Text) ||
                comboBoxGrupoVeiculo.SelectedItem == null ||
                string.IsNullOrEmpty(textBoxModelo.Text) ||
                string.IsNullOrEmpty(textBoxMarca.Text) ||
                string.IsNullOrEmpty(textBoxCor.Text) ||
                string.IsNullOrEmpty(textBoxKmPercorrido.Text) ||
                string.IsNullOrEmpty(TextBoxCapacidadeTanque.Text) ||
                pictureBox.Image==null
                )
                return true;

            return false;
        }

        private void EncherComboBoxGrupoVeiculo(List<GrupoVeiculo> GruposVeiculos)
        {
            comboBoxGrupoVeiculo.Items.Clear();

            foreach (var Grupo in GruposVeiculos)
            {
                comboBoxGrupoVeiculo.Items.Add(Grupo);
            }
        }

        private string SelecionarEnum()
        {
            var enumSelecionado = Enum.Parse(typeof(EnumTipoDeCombustivel), comboBoxTipoCombustivel.SelectedItem.ToString().Replace(" ", ""));

            switch (enumSelecionado)
            {
                case EnumTipoDeCombustivel.Gasolina:
                    return "Gasolina";
                    break;
                case EnumTipoDeCombustivel.Etanol:
                    return "Etanol";
                    break;
                default: return "Eletrico";
            }
            return null;
        }
        private void TextBoxCapacidadeTanque_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox box = (TextBox)sender;

                string texto = Regex.Replace(box.Text, "[^0-9]", string.Empty);

                if (texto == string.Empty) texto = "00";

                if (e.KeyChar.Equals((char)Keys.Back))
                    texto = texto.Substring(0, texto.Length - 1);
                else
                    texto += e.KeyChar;

                box.Text = string.Format("{0:#,##0.00}", Double.Parse(texto) / 100);

                box.Select(box.Text.Length, 0);
            }
            e.Handled = true;
        }

        private void textBoxKmPercorrido_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox box = (TextBox)sender;

                string texto = Regex.Replace(box.Text, "[^0-9]", string.Empty);

                if (texto == string.Empty) texto = "00";

                if (e.KeyChar.Equals((char)Keys.Back))
                    texto = texto.Substring(0, texto.Length - 1);
                else
                    texto += e.KeyChar;

                box.Text = string.Format("{0:#,##0.00}", Double.Parse(texto) / 100);

                box.Select(box.Text.Length, 0);
            }
            e.Handled = true;
        }

        private void btnInserirFoto_Click(object sender, EventArgs e)
        {
            var openfile = new OpenFileDialog();
            openfile.Filter = "Arquivos de Imagem jpg e png |*.jpg; *.png;";
            openfile.Multiselect = false;

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                caminhoFoto= openfile.FileName;
            }
            if (caminhoFoto != "" && caminhoFoto !=null)
            {
                try
                {
                    pictureBox.Load(caminhoFoto);

                }
                catch (Exception ex)
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("Erro ao Inserir a imagem selecionada");
                    return;
                }

            }
        }
        private void carregarFoto()
        {
            if (_veiculo.Foto != null)
            {
                using (var foto = new MemoryStream(_veiculo.Foto))
                {
                    pictureBox.Image = Image.FromStream(foto);
                }
            }
        }
        private byte[] converterFoto()
        {
            byte[] foto;

            if (caminhoFoto == null && pictureBox.Image != null)
            {
                return _veiculo.Foto;
            }

            using (var stream = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    foto = reader.ReadBytes((int)stream.Length);
                }
            }
            return foto;
        }
    }
}
