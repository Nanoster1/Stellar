using ErrorOr;

using FluentValidation.Results;

namespace Stellar.Core.ApplicationLayer.FluentValidation.Extensions;

public static class ValidationFailureExtensions
{
    public static List<Error> ToErrors(this List<ValidationFailure> validationErrors)
    {
        return validationErrors.ConvertAll(x => Error.Validation(x.PropertyName, x.ErrorMessage));
    }
}