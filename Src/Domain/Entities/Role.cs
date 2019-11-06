using System;
using System.Collections.Generic;
using System.Text;
using Dms;

namespace Dms.Domain.Entities
{
    public class Role :AuditableEntity
    {
        public Role()
        {
            UserChildren = new HashSet<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> UserChildren { get; set; }
    }
}
