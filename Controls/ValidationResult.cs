using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maui_PagoJa.Controls
{
    public class ValidationResult
    {
        public bool IsValid { get;}
        public string ErrorMessage { get;}

        public ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public static ValidationResult Success => new ValidationResult(true, null);
    }
}
