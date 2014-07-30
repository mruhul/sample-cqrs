using System.Threading.Tasks;
using Lib.Validation;
using Lib.Validation.Extensions;
using Sample.Core.Commands;

namespace Sample.Infrastructure.Validators
{
    public class CreateBookInputValidator : IAsyncValidator<CreateBook>
    {
        public async Task<ValidationResult> ValidateAsync(CreateBook command)
        {
            return await Task.FromResult(
                RuleChecker.For(command)
                    .Property(x => x.Title)
                        .ErrorCode(100)
                        .ErrorMessage("Title is required")
                        .NotEmpty()
                    .Done()
                    .ValidationResult(1000)
            );
        }
    }
}
