using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
  /// <summary>
  /// A class for containing details of validation errors
  /// </summary>
  public class ApiValidationErrorResponse : ApiResponse
  {
    public ApiValidationErrorResponse() : base(400)
    {

    }

    public ApiValidationErrorResponse(IEnumerable<string> errors) : base(400)
    {
      Errors = errors;
    }

    public IEnumerable<string> Errors { get; set; }
  }
}