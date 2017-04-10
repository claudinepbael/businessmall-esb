using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Infrastracture.Contracts {

    public interface ICommandHandler<in TParameter> where TParameter:ICommand {

        void Execute(TParameter command);


    }

    public interface ICommandHandlerWithReturn<in TParameter, TResult>
        where TParameter : ICommand
        where TResult : ICommandResult {

        TResult Execute(TParameter command);
    }
}
