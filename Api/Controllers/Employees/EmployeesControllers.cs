using Microsoft.AspNetCore.Mvc;
using Services.EmployeeService;

namespace Api.Controllers.Employees;

[ApiController]
[Route("api/[controller]")]
public partial class EmployeesControllers : ControllerBase
{
	private readonly IEmployeeBll _employeeBll;

	public EmployeesControllers(IEmployeeBll employeeBll)
	{
		_employeeBll = employeeBll;
	}
}