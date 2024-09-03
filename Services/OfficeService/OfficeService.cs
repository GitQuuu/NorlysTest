using DAL;

namespace Services.OfficeService;

public partial class OfficeService : IOfficeService
{
	private readonly ApplicationDbContext _context;

	public OfficeService(ApplicationDbContext context)
	{
		_context = context;
	}
}