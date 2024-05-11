using FluentValidation;
using KnowledgeBasev2.Application.Commands.CmdCommands;
using KnowledgeBasev2.Application.Contracts;

namespace KnowledgeBasev2.Infrastructure.Validators
{
    public class DeleteCmdCommandValidator : AbstractValidator<DeleteCmdCommand>
    {
        //----------------------------------------------------------------
        //  Check if given Id corresponds to an existing Command in DB
        //----------------------------------------------------------------
        public DeleteCmdCommandValidator(IKbCommand repo)
        {
            RuleFor(c => c.Id).MustAsync(async (data, _) =>
            {
                return await repo.IsExistingId(data);
            }).WithMessage("No existing Command with the given Id!!!");
        }
    }
}
