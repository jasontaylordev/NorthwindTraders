using System.Collections.Generic;
using MediatR;
using Northwind.Application.Employees.Models;

namespace Northwind.Application.Employees.Queries
{
    public class EmployeesWithManagersQuery : IRequest<IEnumerable<EmployeeManagerModel>>
    {
    }
}
