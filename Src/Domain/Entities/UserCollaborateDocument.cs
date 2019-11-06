using Dms;

namespace Dms.Domain.Entities
{
    public class UserCollaborateDocument :AuditableEntity
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int UserCollaboratorId { get; set; }

        public Document DocumentParent { get; set; }
        public User CollaboratorUserParent { get; set; }
    }
}