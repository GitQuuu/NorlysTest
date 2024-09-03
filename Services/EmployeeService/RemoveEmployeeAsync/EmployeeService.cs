using System.Net;
using Microsoft.Data.Sqlite;

using Microsoft.EntityFrameworkCore;

namespace Services.EmployeeService;

public partial class EmployeeService
{
	public async Task<ServiceResult<DeleteEmployeeResponse>> DeleteAsync(int id)
	{
		await using var transaction = await _context.Database.BeginTransactionAsync();
		try
		{
			const string sql = "DELETE FROM Employees WHERE Id = {0}";

			var changes = await _context.Database.ExecuteSqlRawAsync(sql,id);
			
			if (changes <= 0)
			{
				return new ServiceResult<DeleteEmployeeResponse>(false, HttpStatusCode.NotFound, "Employee not found");
			}
			
			await transaction.CommitAsync();
			return new ServiceResult<DeleteEmployeeResponse>(true, HttpStatusCode.OK, "Employee deleted");
		}
		catch (Exception ex)
		{
			await transaction.RollbackAsync();

			return new ServiceResult<DeleteEmployeeResponse>(false, HttpStatusCode.InternalServerError, ex.Message);
		}


	}
}