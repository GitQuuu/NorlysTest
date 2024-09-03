using Microsoft.AspNetCore.Mvc;
using Services.OfficeService;

namespace Api.Controllers.Offices;

/// <summary>
/// CRUD endpoints for offices
/// </summary>
[ApiController]
[Route("api/[controller]")]
public partial class OfficesController : ControllerBase
{
	private readonly IOfficeBll _officeBll;

	/// <inheritdoc />
	public OfficesController(IOfficeBll officeBll)
	{
		_officeBll = officeBll;
	}
}