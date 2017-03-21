using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shuttle.Esb;
using Businessmall.Application.Commands;
using Businessmall.Repositories;

namespace Businessmall.Application.CommandHandlers
{
    class LoginShopUserCommandHandler : IMessageHandler<LoginShopUserCommand>
    {

        public void ProcessMessage(IHandlerContext<LoginShopUserCommand> context)
        {
            using (var _bmService = new BusinessmallService())
            {
                try
                {
                   // _bmService.IsUserAuthorized(context._username, context._password, false);
                }
                catch (Exception e)
                {
                    
                }
            }
        }
    }
}
