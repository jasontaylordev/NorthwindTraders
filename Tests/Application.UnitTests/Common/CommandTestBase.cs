using System;
using Dms.Persistence;

namespace Dms.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly DmsDbContext _context;

        public CommandTestBase()
        {
            _context = NorthwindContextFactory.Create();
        }

        public void Dispose()
        {
            NorthwindContextFactory.Destroy(_context);
        }
    }
}