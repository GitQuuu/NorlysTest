using Microsoft.AspNetCore.Mvc;

namespace Services.EmployeeService;

public interface IEmployeeBll
{
	Task<IActionResult> AddEmployeeAsync(AddEmployeeRequestDto request);
}