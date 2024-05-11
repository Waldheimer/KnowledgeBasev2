using FluentValidation;
using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.Queries.CommandQueries;

namespace KnowledgeBasev2.Infrastructure.Validators
{
    public class GetCommandQueryValidator : AbstractValidator<GetCommandByIdQuery>
    {
        //----------------------------------------------------------------
        //  Check if given Id corresponds to an existing Command in DB
        //----------------------------------------------------------------
        public GetCommandQueryValidator(IKbCommand repo)
        {
            RuleFor(c => c.Id).MustAsync(async (data, _) =>
            {
                return await repo.IsExistingId(data);
            }).WithMessage("No existing Command with the given Id!!!");
        }
    }
}
