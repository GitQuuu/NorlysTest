using Services.ResponseService;

namespace Services.EmployeeService;

public partial class EmployeeBll : IEmployeeBll
{
	private readonly IEmployeeService _employeeService;
	private readonly IResponseService _responseService;

	public EmployeeBll(IEmployeeService employeeService, IResponseService responseService)
	{
		_employeeService      = employeeService;
		_responseService = responseService;
	}
}