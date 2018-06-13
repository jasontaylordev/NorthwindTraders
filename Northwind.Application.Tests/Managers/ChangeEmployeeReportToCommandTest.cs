using Northwind.Application.Managers.Commands;
using Northwind.Domain;
using System;
using System.Linq;
using Northwind.Persistence;
using Xunit;

namespace Northwind.Application.Tests.Managers
{
    public class ChangeEmployeeReportToCommandTest
        : TestBase
    {
        [Fact]
        public void ShouldMoveEmployeeUnderManager()
        {
            // Prepare
            var context = InitAndGetDbContext();
            var command = new ChangeEmployeeReportToCommand(context);

            // Execute
            int reportTo = 2;
            command.Execute(new EmployeeUnderManagerModel
            {
                EmployeeId = 1,
                ManagerId = reportTo
            });

            // Asses
            Assert.Single(context.Employees
                .Where(e => e.EmployeeId == 1 && e.ReportsTo == reportTo));
        }

        [Fact]
        public void ShouldFailForNonExistingManager()
        {
            // Prepare
            var context = InitAndGetDbContext();
            var command = new ChangeEmployeeReportToCommand(context);

            // Execute and asses
            int reportTo = 3;
            Assert.Throws<ArgumentException>(() => command.Execute(new EmployeeUnderManagerModel
            {
                EmployeeId = 1,
                ManagerId = reportTo
            }));
        }
        
        [Fact]
        public void ShouldNotBeManagerOfItself()
        {
            // Prepare
            var context = InitAndGetDbContext();
            var command = new ChangeEmployeeReportToCommand(context);

            // Execute and asses
            int reportTo = 1;
            Assert.Throws<ArgumentException>(() => command.Execute(new EmployeeUnderManagerModel
            {
                EmployeeId = 1,
                ManagerId = reportTo
            }));
        }

        private NorthwindDbContext InitAndGetDbContext()
        {
            //UseSqlite();
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
    }
}
