using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.OfficeService;

namespace Api.Controllers.Offices;

public partial class OfficesController
{
	/// <summary>
	/// Assign employee to an office
	/// </summary>
	/// <param name="request">Payload</param>
	/// <returns></returns>
	/// <remarks>Use get endpoints for employees to fetch employees id, for office look into app.db (sql lite)</remarks>
	[HttpPost]
	public async Task<IActionResult> AssignEmployee([FromBody] AssignEmployeeRequest request)
	{
		return await _officeBll.AssignEmployeeAsync(request.Adapt<AssignEmployeeRequestDto>());
	}
}