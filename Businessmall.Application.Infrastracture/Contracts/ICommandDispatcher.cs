using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Infrastracture.Contracts {
    public interface ICommandDispatcher {

       void Dispatch<TParameter>(TParameter command) where TParameter:ICommand;
    }
}
