using Northwind.Application.Managers.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;
using Northwind.Domain.Entities;
using Northwind.Persistence;
using Xunit;

namespace Northwind.Application.Tests.Managers
{
    public class ChangeEmployeeReportToCommandTest
        : TestBase, IDisposable
    {
        private readonly NorthwindDbContext _context;
        private readonly ChangeEmployeeReportToCommandHandler _commandHandler;

        public ChangeEmployeeReportToCommandTest()
        {
            _context = InitAndGetDbContext();
            _commandHandler = new ChangeEmployeeReportToCommandHandler(_context);
        }

        [Fact]
        public async Task ShouldMoveEmployeeUnderManager()
        {
            // Arrange
            var command = new ChangeEmployeeReportToCommand
            {
                EmployeeId = 1,
                ManagerId = 2
            };

            // Act
            await _commandHandler.Handle(command, CancellationToken.None);

            var employee = await _context.Employees.FindAsync(command.EmployeeId);

            // Assert
            Assert.Equal(employee.ReportsTo, command.ManagerId);
        }

        [Fact]
        public Task ShouldFailForNonExistingManager()
        {
            // Arrange
            var command = new ChangeEmployeeReportToCommand
            {
                EmployeeId = 1,
                ManagerId = 3
            };

            // Act + Assert
            return Assert.ThrowsAsync<ArgumentException>(() =>
                _commandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public Task ShouldNotBeManagerOfItself()
        {
            // Arrange
            var command = new ChangeEmployeeReportToCommand
            {
                EmployeeId = 1,
                ManagerId = 1
            };

            // Act + Assert
            return Assert.ThrowsAsync<ArgumentException>(() =>
                _commandHandler.Handle(command, CancellationToken.None));
        }

        private NorthwindDbContext InitAndGetDbContext()
        {
            //var context = GetDbContext(useSqlLite: true);
            var context = GetDbContext();

            context.Employees.Add(new Employee
            {
                EmployeeId = 1,
                FirstName = "",
                LastName = ""
            });
            context.Employees.Add(new Employee
            {
                EmployeeId = 2,
                FirstName = "",
                LastName = ""
            });
            context.SaveChanges();

            return context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
