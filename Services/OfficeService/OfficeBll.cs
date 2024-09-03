using Services.ResponseService;

namespace Services.OfficeService;

public partial class OfficeBll : IOfficeBll
{
	private readonly IOfficeService _officeService;
	private readonly IResponseService _responseService;

	public OfficeBll(IOfficeService officeService, IResponseService responseService)
	{
		_officeService   = officeService;
		_responseService = responseService;
	}
}