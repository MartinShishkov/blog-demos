using System;
using Microsoft.EntityFrameworkCore.Internal;

namespace CleanControllers.Web.Models.Business
{
    public class BuildResult<T>
    {
        public BuildResult(string[] errorCodes, T value)
        {
            ErrorCodes = errorCodes ?? throw new ArgumentNullException(nameof(errorCodes));
            Value = value;
        }

        public string[] ErrorCodes { get; }

        public T Value { get; }

        public bool IsValid => ErrorCodes.Any() == false;
    }
}