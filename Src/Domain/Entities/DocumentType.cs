using System;
using System.Collections.Generic;
using System.Text;
using Dms;

namespace Dms.Domain.Entities
{
    public class DocumentType :AuditableEntity
    {
        public DocumentType()
        {
            DocuumentChildren = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Name  { get; set; }
        public string ContentType { get; set; }
        public ICollection<Document> DocuumentChildren{ get; set; }

    }
}
