using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.Compartilhado
{
    internal static class TextBoxBaseExtension
    {
        /// <summary>
        /// Metodo formata TextBox para moeda real
        /// Este método deve ser implementado no evendo de key press do TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void FormatarCampoMoedaReal(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox box = (TextBox)sender;

                string texto = Regex.Replace(box.Text, "[^0-9]", string.Empty);

                if (texto == string.Empty) texto = "00";

                if (e.KeyChar.Equals((char)Keys.Back))
                    texto = texto.Substring(0, texto.Length -1);
                else
                    texto += e.KeyChar;

                box.Text = string.Format("{0:#,##0.00}", Double.Parse(texto)/100);

                box.Select(box.Text.Length, 0);
            }
            e.Handled = true;

        }

        /// <summary>
        /// Metodo formata decimal para string em formato moeda real
        /// Este método deve ser implementado junto ao contrutor das telas para formatar campo do textBox
        /// </summary>
        /// <param decimal="valor"></param>
        public static string FormatarStringMoedaReal(decimal? valor)
        {
            return string.Format("{0:#,##0.00}", Double.Parse(valor.ToString()));
        }

        /// <summary>
        /// Método recebe um email por string e retorno verdadeiro caso valide o formato
        /// Método implementado no evento text changed, que é disparado sempre que o texto for alterado
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ValidarFormatoEmail(string email)
        {
            char[] caracteresEspeciaisEmail = { '@', '.' };

            string[] emailSplit = email.Split(caracteresEspeciaisEmail, 3);

            if (emailSplit.Length >= 3 && emailSplit[2].Length > 1)
                return true;

            return false;
        }
        /// <summary>
        /// Metodo formata TextBox para moeda real
        /// Este método deve ser implementado no evendo de key press do TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void FormatarCampoTelefoneOuCelulcar(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox campo = (TextBox)sender;

                string stringComCaracteres = campo.Text;

                string stringSemCaracteresEspeciais = RetirarCaracteresEspeciais(stringComCaracteres);

                if (e.KeyChar.Equals((char)Keys.Back) && !string.IsNullOrEmpty(stringSemCaracteresEspeciais))
                    stringSemCaracteresEspeciais = stringSemCaracteresEspeciais.Substring(0, stringSemCaracteresEspeciais.Length -1);

                if (!e.KeyChar.Equals((char)Keys.Back))
                    stringSemCaracteresEspeciais += Convert.ToString(e.KeyChar.ToString());

                if (stringSemCaracteresEspeciais.Length <= 11)
                {
                    string ddd = formataDDD(stringSemCaracteresEspeciais);

                    string telefone = formataTelefone(stringSemCaracteresEspeciais);

                    campo.Text = ddd+telefone;

                    campo.Select(campo.Text.Length, 0);
                }
            }
            e.Handled = true;

        }

        /// <summary>
        /// Método retorna um string de telefone formatada
        /// </summary>
        /// <param name="numeroSemFormatacao"></param>
        /// <returns></returns>
        public static string FormataStringTelefoneOuCelular(string numeroSemFormatacao)
        {
            string stringSemCaracteresEspeciais = RetirarCaracteresEspeciais(numeroSemFormatacao);

            string ddd = formataDDD(stringSemCaracteresEspeciais);

            string telefone = formataTelefone(stringSemCaracteresEspeciais);

            return ddd+telefone;
        }

        /// <summary>
        /// Retira caracteres especiais de uma string e retorna
        /// </summary>
        /// <param name="textoComAcento"></param>
        /// <returns></returns>
        public static string RetirarCaracteresEspeciais(string textoComAcento)
        {
            /** Troca os caracteres especiais da string por "" **/
            string[] caracteresEspeciais = { "(", ")", "-", " " };
            string str = textoComAcento;
            for (int i = 0; i < caracteresEspeciais.Length; i++)
            {
                str = str.Replace(caracteresEspeciais[i], "");
            }
            return str;
        }

        #region Métodos privados
        private static string formataDDD(string stringSemCaracteresEspeciais)
        {

            if (stringSemCaracteresEspeciais.Length > 1)
                return "("+stringSemCaracteresEspeciais[0]+stringSemCaracteresEspeciais[1]+")";

            if (stringSemCaracteresEspeciais.Length == 1 && stringSemCaracteresEspeciais[0].ToString() != "")
                return "("+stringSemCaracteresEspeciais[0];

            return "";
        }

        private static string formataTelefone(string stringSemCaracteres)
        {
            if (stringSemCaracteres.Length < 3)
                return "";

            string numeroSemDDD = stringSemCaracteres.Substring(2);

            string stringFormatada = "";
            for (int i = 0; i < numeroSemDDD.Length; i++)
            {
                if (numeroSemDDD.Length == 9 && i == 1)
                    stringFormatada += " ";

                stringFormatada += numeroSemDDD[i];

                if (i == 3 && numeroSemDDD.Length <= 8)
                    stringFormatada += "-";

                if (i == 4 && numeroSemDDD.Length == 9)
                    stringFormatada += "-";
            }

            return " "+stringFormatada;
        }

        #endregion
    }
}
