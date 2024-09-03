using System.Net;

namespace Services;

/// <summary>
/// Use in service layer to return a ServiceResult object so upper layer can decide what to do with the response
/// </summary>
/// <typeparam name="T">The dto</typeparam>
/// <remarks>Why? Because its adheres to separation of concern principle</remarks>
public class ServiceResult<T> where T : class
{
	public T? Data { get; set; }
	public HttpStatusCode? HttpResponse { get; set; }
	public string? Message { get; set; }
	public bool Success { get; set; }
	
	public ServiceResult()
	{
		
	}

	public ServiceResult(bool success, HttpStatusCode? httpResponse, string? message, T? data = default)
	{
		Success      = success;
		HttpResponse = httpResponse;
		Message      = message;
		Data         = data;
	}
	
	public ServiceResult(bool success, HttpStatusCode? httpResponse, T? data = default)
	{
		Success      = success;
		HttpResponse = httpResponse;
		Data         = data;
	}
}