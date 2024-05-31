using CommunityToolkit.Mvvm.Messaging.Messages;
using System.Windows;

namespace KnowledgeBasev2.WPF.Messages
{
    public class ApplicationSizeMessage : ValueChangedMessage<Size>
    {
        public ApplicationSizeMessage(Size value) : base(value)
        {
        }
    }
}
