using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract void Inserir();

        public abstract void Editar();

        public abstract void Excluir();

        public virtual void Filtrar() { }

        public virtual void GerarPdf() { }

        public virtual void Visualizar() { }

        public abstract UserControl ObtemListagem();

        public abstract ConfigurarToolboxBase ObtemConfiguracaoToolbox();
    }
}
