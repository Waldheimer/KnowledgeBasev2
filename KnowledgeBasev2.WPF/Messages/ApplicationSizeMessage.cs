using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
