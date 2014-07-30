using System.Threading.Tasks;
using Lib.Validation;
using Lib.Validation.Extensions;
using Sample.Core.Commands;
using Sample.Repositories;

namespace Sample.Infrastructure.Validators
{
    public class CreateBookUniqueValidator : IAsyncValidator<CreateBook>
    {
        private readonly IBooksRepository _repository;

        public CreateBookUniqueValidator(IBooksRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> ValidateAsync(CreateBook command)
        {
            var exists = await _repository.TitleExistsAsync(command.Title, null);

            return await Task.FromResult(
                    RuleChecker.For(command)
                        .Property(x => x.Title)
                        .ErrorCode(1001)
                        .ErrorMessage("Title already exists.")
                        .Should(s => !exists)
                        .Done()
                        .ValidationResult(1001)
                );
        }
    }
}