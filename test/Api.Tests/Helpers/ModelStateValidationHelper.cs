using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Tests.Helpers
{
    public static class ModelStateValidationHelper
    {
        public static bool Validate<T>(T model)
        {
            return Validator.TryValidateObject(model ?? throw new ArgumentNullException(nameof(model)),
                new ValidationContext(model, null, null), null, true);
        }
    }
}