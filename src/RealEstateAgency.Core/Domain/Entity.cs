using FluentValidation.Results;
using System;

namespace RealEstateAgency.Core.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public ValidationResult ValidationResult { get; protected set; }

        // EquinoxProjetct / NetDevPack
        // https://github.com/EduardoPires/EquinoxProject/blob/2cbb15cff0274227642ff67928b637a60f4f17a2/src/Equinox.Domain.Core/Models/Entity.cs
        // Lançar eventos de domínio
        //private List<Event> _domainEvents;
        //public IReadOnlyCollection<Event> DomainEvents => _domainEvents?.AsReadOnly();

        // Curso Domínios Ricos
        // Notificar erros ou problemas
        //private List<Event> _notificacoes;
        //public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        #region BaseBehaviours

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() ^ 93) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        #endregion

        #region Validations

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
