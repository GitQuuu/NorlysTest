namespace Services.EmployeeService;

public interface IEmployeeService
{
	Task<ServiceResult<AddEmployeeResponseDto>> CreateEmployeeAsync(AddEmployeeRequestDto request);
}