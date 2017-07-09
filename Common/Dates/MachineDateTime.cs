using System;

namespace NorthwindTraders.Common.Dates
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
