using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
  /// <summary>
  /// A base class for consistent API response when exceptions or errors occur
  /// </summary>
  public class ApiResponse
  {
    public ApiResponse(int statusCode, string message = null)
    {
      StatusCode = statusCode;
      Message = message ?? GetDefaultMessageForStatusCode(StatusCode);
    }

    /// <summary>
    /// Status code
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Error message
    /// </summary>
    public string Message { get; set; }

    private string GetDefaultMessageForStatusCode(int statusCode)
    {
      return statusCode switch
      {
        400 => "A bad request you have made",
        401 => "Authorized, you are not",
        404 => "Resource found, it was not",
        500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate lead to career change",
        _ => "Error occured"
      };
    }
  }
}