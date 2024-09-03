using Microsoft.AspNetCore.Mvc;

namespace Services.OfficeService;

public partial class OfficeBll
{
	public async Task<IActionResult> AssignEmployeeAsync(AssignEmployeeRequestDto dto)
	{
		var response = await _officeService.AssignEmployeeToOfficeAsync(dto);	
		return await _responseService.HandleResultAsync(response);
	}
}