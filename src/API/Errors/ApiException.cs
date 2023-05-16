using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
  /// <summary>
  /// A class that represents an api response containing the details of server-side errors or exceptions 
  /// </summary>
  public class ApiException : ApiResponse
  {
    public ApiException(int statusCode, string message = null, string details = null) : base(statusCode, message)
    {
        Details = details;
    }

    /// <summary>
    /// Details or stack trace of error
    /// </summary>
    public string Details { get; set; }
  }
}