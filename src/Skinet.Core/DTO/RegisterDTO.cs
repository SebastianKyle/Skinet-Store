using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.Core.DTO
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        // [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?\\&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = "Password must have at least 1 uppercase, 1 lowercase, 1 number, 1 non alphanumeric and should be between 6 - 10 characters.")]
        // [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+}{\":;'?>.<,])(?!.*\\s).*$", ErrorMessage = "Password must have at least 1 uppercase, 1 lowercase, 1 number, 1 non-alphanumeric, and should be between 6 - 10 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}