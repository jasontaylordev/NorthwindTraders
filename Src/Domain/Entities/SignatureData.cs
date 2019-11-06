using System.Collections;
using System.Collections.Generic;
using Dms;

namespace Dms.Domain.Entities
{
    public class SignatureData :AuditableEntity
    {
        public SignatureData()
        {
        }
        public int Id { get; set; }
        public string PublicKey { get; set; }
        public int OwnerId { get; set; }
        public User OwnerParent { get; set; }

    }
}