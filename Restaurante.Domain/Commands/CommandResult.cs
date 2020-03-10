using Restaurante.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Commands
{
    public class CommandResult : Notification, ICommandResult
    {
        public DateTime Executed { get; private set; }

        protected CommandResult()
        {
            Executed = DateTime.UtcNow;
        }
    
    }
}
