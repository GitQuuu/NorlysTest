using System.Net;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Services.EmployeeService;

public partial class EmployeeService
{
	public async Task<ServiceResult<List<ReadEmployeesResponse>>> ReadEmployeesAsync()
	{
		const string sql = "SELECT * FROM Employees";

		var employees = await _context.Employees
									  .FromSqlRaw(sql)
									  .ToListAsync();
		if (!employees.Any())
		{
			return new ServiceResult<List<ReadEmployeesResponse>>(true,HttpStatusCode.NoContent ,"Empty collection",employees.Adapt<List<ReadEmployeesResponse>>());
		}
		
		return new ServiceResult<List<ReadEmployeesResponse>>(true,HttpStatusCode.OK ,employees.Adapt<List<ReadEmployeesResponse>>());
	}
}