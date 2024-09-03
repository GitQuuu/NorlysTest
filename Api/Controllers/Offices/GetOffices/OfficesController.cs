using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Offices;

/// <summary>
/// Endpoint related to office informations
/// </summary>
public partial class OfficesController
{
	/// <summary>
	/// Get all offices
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	public async Task<IActionResult> GetOfficesAsync()
	{
		return Ok();
	}
}