namespace Services.OfficeService;

public interface IOfficeService
{
	Task<ServiceResult<AssignEmployeeToOfficeReponse>> AssignEmployeeToOfficeAsync(AssignEmployeeRequestDto dto);
}