using System;
using System.Collections.Generic;
using System.Text;

namespace LightInjectAb.Business.Dto
{
    public abstract class DtoBase : IDtoBase<Guid>
    {
        protected DtoBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as DtoBase;

            if (other == null)
                return false;

            return Id.Equals(other.Id);
        }

        public virtual void TranslateProperties() { }
    }
}
