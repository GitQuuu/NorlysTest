using DAL;

namespace Services.EmployeeService;

public partial class EmployeeService:IEmployeeService
{
	private readonly ApplicationDbContext _context;

	public EmployeeService(ApplicationDbContext context)
	{
		_context = context;
	}
}