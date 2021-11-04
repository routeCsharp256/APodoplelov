using System;
using System.Collections.Generic;
using MediatR;

namespace MerchandiseService.Domain.Models
{
    public abstract class Entity
    {
        private int? _RequestedHashCode;

        public virtual int Id { get; protected set; }

        private List<INotification> _DomainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => this._DomainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            this._DomainEvents ??= new List<INotification>();
            this._DomainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            this._DomainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            this._DomainEvents?.Clear();
        }

        public bool IsTransient() => this.Id == default;

        public override bool Equals(object obj)
        {
            if (obj is not Entity entity)
            {
                return false;
            }

            if (object.ReferenceEquals(this, entity))
            {
                return true;
            }

            if (this.GetType() != entity.GetType())
            {
                return false;
            }

            if (entity.IsTransient() || this.IsTransient())
            {
                return false;
            }

            return entity.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!this.IsTransient())
            {
                if (!this._RequestedHashCode.HasValue)
                {
                    this._RequestedHashCode = HashCode.Combine(Id, 31);
                }

                return _RequestedHashCode.Value;
            }

            return base.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right) =>
            Object.Equals(left, null) ? Object.Equals(right, null) : left.Equals(right);

        public static bool operator !=(Entity left, Entity right) => !(left == right);
    }
}
