using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Reports.Queries
{
    public class EmployeeManagerModel
    {
        public string EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string ManagerId { get; set; }
        public string EmployeeTitle { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public string ManagerTitle { get; set; }
    }
}
