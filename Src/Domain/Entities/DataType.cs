using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using Dms;

namespace Dms.Domain.Entities
{
    public class DataType :AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Data> DataChildren { get; set; }
    }
}