using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.Employees;

/// <summary>
/// CRUD endpoints for employees
/// </summary>
[ApiController]
[Route("api/[controller]")]
public partial class EmployeesController : ControllerBase
{
	private readonly IEmployeeBll _employeeBll;

	/// <inheritdoc />
	public EmployeesController(IEmployeeBll employeeBll)
	{
		_employeeBll = employeeBll;
	}
}