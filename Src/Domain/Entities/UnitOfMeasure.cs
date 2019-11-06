using System.Collections;
using System.Collections.Generic;
using Dms;

namespace Dms.Domain.Entities
{
    public class UnitOfMeasure :AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Data> DataChildren { get; set; }
    }
}