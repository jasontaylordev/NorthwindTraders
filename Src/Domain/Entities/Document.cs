using System.Collections;
using System.Collections.Generic;
using Dms;

namespace Dms.Domain.Entities
{
    public class Document : AuditableEntity
    {
        public Document()
        {
            DocumentDataValueChildren = new HashSet<DocumentDataValue>();
            UserCollaborateDocumentChildren = new HashSet<UserCollaborateDocument>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int DocumentTypeId { get; set; }
        public int UserCreatedId { get; set; }


        public User UserCreatorParent { get; set; }
        public DocumentType DocumentType { get; set; }
        public ICollection<DocumentDataValue> DocumentDataValueChildren { get; set; }
        public ICollection<UserCollaborateDocument> UserCollaborateDocumentChildren { get; set; }

    }
}