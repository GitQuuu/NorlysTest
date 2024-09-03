using Microsoft.AspNetCore.Mvc;
using Services.EmployeeService;

namespace Services;

public interface IEmployeeBll
{
	Task<IActionResult> AddEmployeeAsync(AddEmployeeRequestDto request);
	Task<IActionResult> GetEmployeesAsync();
	Task<IActionResult> GetEmployeeAsync(int id);
	Task<IActionResult> RemoveEmployeeAsync(int id);
	Task<IActionResult> EditEmployeeAsync(EditEmployeeRequestDto request);
}	