using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Interfaces;
using Northwind.Persistence;

namespace Northwind.Application.System.Commands.SeedSampleData
{
    public class SeedSampleDataCommand : IRequest<Unit>
    {
    }

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand, Unit>
    {
        private readonly INorthwindDbContext _context;
        private readonly IUserManager _userManager;

        public SeedSampleDataCommandHandler(INorthwindDbContext context, IUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context, _userManager);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
