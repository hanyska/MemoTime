using System;

namespace MemoTime.Core.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}