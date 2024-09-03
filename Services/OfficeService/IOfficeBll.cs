using Microsoft.AspNetCore.Mvc;

namespace Services.OfficeService;

public interface IOfficeBll
{
	Task<IActionResult> AssignEmployeeAsync(AssignEmployeeRequestDto dto);
}