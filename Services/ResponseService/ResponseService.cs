using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Services.ResponseService;

public class ResponseService : IResponseService
{
	///  <summary>
	///  This service is meant to be used in the BLL layer it return the proper ObjectResult to the controller, it takes in a ServiceResult&lt;T&gt; object, checks its HttpResponse property, and returns an appropriate error response based on that HTTP status code, along with the error message provided in the ServiceResult&lt;T&gt;
	///  </summary>
	///  <param name="result">The response from ServiceResult&lt;T&gt;</param>
	///  <typeparam name="T">The expected return type</typeparam>
	///  <returns>A specific object result type</returns>
	///  <example>
	/// 		var result = await _authenticationService.LoginAsync(dto);
	/// 		return _responseService(result)
	/// 		
	///  </example>
	///  <remarks>Foreach new case added here create a test for it in HandleResultUnitTests</remarks>
	public Task<IActionResult> HandleResultAsync<T>(ServiceResult<T> result) where T : class
	{
		ArgumentNullException.ThrowIfNull(result);

		return Task.FromResult<IActionResult>(result.HttpResponse switch
											  {
												  HttpStatusCode.OK           => new OkObjectResult(result),
												  HttpStatusCode.NoContent    => new NoContentResult(),
												  HttpStatusCode.NotFound     => new NotFoundObjectResult(result.Message),
												  HttpStatusCode.BadRequest   => new BadRequestObjectResult(result.Message),
												  HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(result.Message),
												  HttpStatusCode.Forbidden    => new ForbidResult(result.Message!),
												  _                           => new ConflictObjectResult(result.Message)
											  });
	}
}