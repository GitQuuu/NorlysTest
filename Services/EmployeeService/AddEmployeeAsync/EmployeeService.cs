using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Services.EmployeeService;

public partial class EmployeeService
{
	public async Task<ServiceResult<AddEmployeeResponseDto>> CreateEmployeeAsync(AddEmployeeRequestDto request)
	{
		request.FirstName = $"{request.FirstName} {request.MiddleName}";
		request.LastName  = Regex.Replace(request.LastName, @"\s+", "");
		
		return await CreateEntityAsync(request);
	}

	private async Task<ServiceResult<AddEmployeeResponseDto>> CreateEntityAsync(AddEmployeeRequestDto request)
	{
		await using var transaction = await _context.Database.BeginTransactionAsync();
		try
		{
			const string sql = "INSERT INTO Employees (FirstName, MiddleName, LastName, Birthdate) VALUES (@p0, @p1, @p2, @p3)";

			await _context.Database.ExecuteSqlRawAsync(sql, 
													   new SqliteParameter("@p0", request.FirstName), 
													   new SqliteParameter("@p1", request.MiddleName), 
													   new SqliteParameter("@p2", request.LastName), 
													   new SqliteParameter("@p3", request.Birthdate));
			
			await transaction.CommitAsync();

				
			return new ServiceResult<AddEmployeeResponseDto>(
															 success: true,
															 httpResponse: HttpStatusCode.OK,
															 message: "Employee created successfully"
															);
		}
		catch (Exception ex)
		{
				
			await transaction.RollbackAsync();
				
			return new ServiceResult<AddEmployeeResponseDto>(
															 success: false,
															 httpResponse: HttpStatusCode.InternalServerError,
															 message: ex.Message
															);
		}
	}

}