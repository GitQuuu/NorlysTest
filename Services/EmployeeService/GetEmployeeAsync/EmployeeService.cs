using System.Net;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Services.EmployeeService;

public partial class EmployeeService
{
	public async Task<ServiceResult<ReadEmployeeResponse>> ReadEmployeeAsync(int id)
	{
		const string sql = "SELECT * FROM Employees WHERE Id = {0}";;
		
		var employee = await  _context.Employees
												.FromSqlRaw(sql,id)
												.SingleOrDefaultAsync();
												
		if (employee is null)
		{
			return new ServiceResult<ReadEmployeeResponse>(false, HttpStatusCode.NotFound,"Employee not found");
		}
		
		return new ServiceResult<ReadEmployeeResponse>(true, HttpStatusCode.OK, "Employee found" ,employee.Adapt<ReadEmployeeResponse>());
	}
}