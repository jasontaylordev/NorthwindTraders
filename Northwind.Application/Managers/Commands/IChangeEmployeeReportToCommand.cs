namespace Northwind.Application.Managers.Commands
{
    public interface IChangeEmployeeReportToCommand
    {
        void Execute(EmployeeUnderManagerModel model);
    }
}