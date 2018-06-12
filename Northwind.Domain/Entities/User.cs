using Northwind.Domain.Enumerations;
using Northwind.Domain.ValueObjects;

namespace Northwind.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public UserType Type { get; set; }

        public AdAccount AdAccount { get; set; }
    }
}
