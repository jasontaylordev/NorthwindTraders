using System.Collections;
using System.Collections.Generic;
using Dms;
using Dms.Domain.Common;

namespace Dms.Domain.Entities
{
    public class Value :AuditableEntity
    {
        public int Id { get; set; }
        public string StringValue { get; set; }
        private ICollection<DocumentDataValue> DocumentDataValueChildren { get; set; }
    }
}