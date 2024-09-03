using Services.EmployeeService;

namespace Services;

public interface IEmployeeService
{
	Task<ServiceResult<AddEmployeeResponseDto>> CreateEmployeeAsync(AddEmployeeRequestDto request);
	Task<ServiceResult<List<ReadEmployeesResponse>>> ReadEmployeesAsync();
	Task<ServiceResult<ReadEmployeeResponse>> ReadEmployeeAsync(int id);
	Task<ServiceResult<DeleteEmployeeResponse>> DeleteAsync(int id);
	Task<ServiceResult<UpdateEmployeeResponse>> UpdateEmployeeAsync(EditEmployeeRequestDto request);
}