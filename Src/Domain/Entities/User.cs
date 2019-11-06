using System.Collections.Generic;
using System.Globalization;
using Dms;
using Dms.Domain.Common;

namespace Dms.Domain.Entities
{
    public class User :AuditableEntity
    {
        public User()
        {
            UserCollaborateDocumentChildren= new HashSet<UserCollaborateDocument>();
            DocumentChildren= new HashSet<Document>();
        }
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int SignatureDataId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username  { get; set; }
        public string   Email { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }
        public SignatureData SignatureData { get; set; }
        public ICollection<UserCollaborateDocument> UserCollaborateDocumentChildren { get; set; }
        public ICollection<Document> DocumentChildren { get; set; }
    }
}