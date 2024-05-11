using FluentValidation;
using KnowledgeBasev2.Application.Commands.CmdCommands;
using KnowledgeBasev2.Application.Contracts;

namespace KnowledgeBasev2.Infrastructure.Validators
{
    public class CreateNewCmdCommandValidator : AbstractValidator<CreateNewCmdCommand>
    {
        //----------------------------------------------------------------
        //  Check if given CreateDTO has a Text-Property and the given
        //  Text does not already exist in DB
        //----------------------------------------------------------------
        public CreateNewCmdCommandValidator(IKbCommand repo)
        {
            RuleFor(c => c.Input).MustAsync(async (data, _) =>
            {
                return await repo.HasRequiredData(data);
            }).WithMessage("CommandText is required for Command Creation!!!");
        }
    }
}
