using System.Net;

namespace Foodie.Application.Common.Errors;

public interface IError
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}
