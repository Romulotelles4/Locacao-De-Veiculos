namespace Locadora.Apresentacao.WinForm.Compartilhado.ServiceLocator
{
    public interface IServiceLocator
    {
        T Get<T>() where T : ControladorBase;
    }
}
