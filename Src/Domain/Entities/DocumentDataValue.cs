using System.Dynamic;
using Dms;
using Dms.Domain.Common;

namespace Dms.Domain.Entities
{
    public class DocumentDataValue :AuditableEntity
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int DataId { get; set; }
        public int ValueId { get; set; }

        public Document DocumentParent { get; set; }
        public Data DataParent { get; set; }
        public Value ValueParent { get; set; }
    }
}