using System;

namespace Locadora.Dominio.Compartilhado
{
    public class NaoPodeExcluirEsteRegistroException : Exception
    {
        public NaoPodeExcluirEsteRegistroException(Exception ex) : base("", ex)
        {

        }
    }
}
