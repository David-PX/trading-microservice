using FluentValidation.Results;

namespace Pacagroup.Trade.Application.UseCases.Commons.Exceptions
{
    public class ValidationExceptionCustom : Exception
    {
        public List<string> Errors { get; }
        public ValidationExceptionCustom() :base("One or more validation errors occurred.")
        {
            Errors = [];
        }

        public ValidationExceptionCustom(IEnumerable<ValidationFailure> failures) : this()
        {
            var errors = failures.Select(f => f.ErrorMessage).ToList();
            
            Errors = errors;
        }
    }
}