using FluentValidation;
using KnowledgeBasev2.Application.Commands.CmdCommands;
using KnowledgeBasev2.Application.Contracts;

namespace KnowledgeBasev2.Infrastructure.Validators
{
    public class UpdateCmdCommandValidator : AbstractValidator<UpdateCmdCommand>
    {
        //----------------------------------------------------------------
        //  Check if Id of given ReadUpdateDTO corresponds to an existing Command in DB
        //----------------------------------------------------------------
        public UpdateCmdCommandValidator(IKbCommand repo)
        {
            RuleFor(c => c.Dto).MustAsync(async (data, _) =>
            {
                return await repo.IsExistingId(data.Id);
            }).WithMessage("No existing Command with the given Id!!!");
        }
    }
}
