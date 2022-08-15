using System;
using Taikandi;

namespace Locadora.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        protected EntidadeBase()
        {
            Id = SequentialGuid.NewGuid();
        }

        public Guid Id { get; set; }

        public abstract void Atualizar(T registro);
    }
}
