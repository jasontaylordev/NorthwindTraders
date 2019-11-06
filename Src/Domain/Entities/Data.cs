using Dms;
using Dms.Domain.Common;

namespace Dms.Domain.Entities
{
    public class Data:AuditableEntity
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public int DataTypeId { get; set; }
        public int? UnitOfMeasureId { get; set; }

        public UnitOfMeasure UnitOfMeasureParent { get; set; }
        public DataType DataTypeParent { get; set; }

    }
}