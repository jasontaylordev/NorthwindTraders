using System.Collections.Generic;
using MediatR;
using Northwind.Application.Reports.Models;

namespace Northwind.Application.Reports.Queries
{
    public class EmployeesWithManagersViewQuery : IRequest<IEnumerable<EmployeeManagerModel>>
    {
    }
}
