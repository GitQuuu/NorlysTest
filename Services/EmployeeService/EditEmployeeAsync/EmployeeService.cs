using System.Net;
using System.Text.RegularExpressions;
using Mapster;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Services.EmployeeService;

public partial class EmployeeService
{
	public async Task<ServiceResult<UpdateEmployeeResponse>> UpdateEmployeeAsync(EditEmployeeRequestDto request)
	{
		request.FirstName = $"{request.FirstName} {request.MiddleName}";
		request.LastName  = Regex.Replace(request.LastName, @"\s+", "");
		
		await using var transaction = await _context.Database.BeginTransactionAsync();
		try
		{
			var updateQuery = @"
            UPDATE Employees
            SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Birthdate = @Birthdate
            WHERE Id = @Id";

			await _context.Database.ExecuteSqlRawAsync(
																	 updateQuery,
																	 new SqliteParameter("@FirstName", request.FirstName),
																	 new SqliteParameter("@MiddleName", request.MiddleName),
																	 new SqliteParameter("@LastName", request.LastName),
																	 new SqliteParameter("@Birthdate", request.Birthdate),
																	 new SqliteParameter("@Id", request.Id)
																	);

			await transaction.CommitAsync();

			return new ServiceResult<UpdateEmployeeResponse>(true, HttpStatusCode.OK, "Employee updated", request.Adapt<UpdateEmployeeResponse>());
		}
		catch (Exception ex)
		{
			await transaction.RollbackAsync();
			return new ServiceResult<UpdateEmployeeResponse>(false, HttpStatusCode.InternalServerError, ex.Message);
		}
	}
}