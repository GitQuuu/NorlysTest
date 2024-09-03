using System.Net;
using Microsoft.EntityFrameworkCore;

namespace Services.OfficeService;

public partial class OfficeService
{
    public async Task<ServiceResult<AssignEmployeeToOfficeReponse>> AssignEmployeeToOfficeAsync(AssignEmployeeRequestDto dto)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            const string getOfficeSql = @"
            SELECT * FROM Offices o
            LEFT JOIN Employees e ON o.Id = e.id
            WHERE o.Id = {0}";
            
            var officeWithEmployees = await _context.Offices
                                                    .FromSqlRaw(getOfficeSql, dto.OfficeId)
                                                    .Include(o => o.Employees)
                                                    .SingleOrDefaultAsync();

            if (officeWithEmployees is null)
            {
                return new ServiceResult<AssignEmployeeToOfficeReponse>(false, HttpStatusCode.NotFound, "Office not found");
            }

            
            const string getEmployeeSql = "SELECT * FROM Employees WHERE Id = {0}";

        
            var employee = await _context.Employees
                                         .FromSqlRaw(getEmployeeSql, dto.EmployeeId)
                                         .SingleOrDefaultAsync();

            if (employee is null)
            {
                return new ServiceResult<AssignEmployeeToOfficeReponse>(false, HttpStatusCode.NotFound, "Employee not found");
            }

            if (officeWithEmployees.Employees.Any(x => x.Id == dto.EmployeeId))
            {
                return new ServiceResult<AssignEmployeeToOfficeReponse>(false, HttpStatusCode.Conflict, $"Employee already assigned to office in {officeWithEmployees.City}");
            }

            if (officeWithEmployees.Employees.Count == officeWithEmployees.FireCode)
            {
                return new ServiceResult<AssignEmployeeToOfficeReponse>(false, HttpStatusCode.Conflict, $"The allowed number of employees {officeWithEmployees.FireCode} in the office is exceeded");
            }
            
            const string insertEmployeeOfficeSql = "INSERT INTO EmployeeOffice (EmployeesId, OfficesId) VALUES ({0}, {1})";

            await _context.Database.ExecuteSqlRawAsync(insertEmployeeOfficeSql, dto.EmployeeId, dto.OfficeId);

            await transaction.CommitAsync();
            
            
            return new ServiceResult<AssignEmployeeToOfficeReponse>(
                true,
                HttpStatusCode.OK,
                $"Assigned employee {employee.FirstName} {employee.LastName} to office in {officeWithEmployees.City}"
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            
            return new ServiceResult<AssignEmployeeToOfficeReponse>(
                false,
                HttpStatusCode.InternalServerError,
                ex.Message
            );
        }
    }
}
