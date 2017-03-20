using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
namespace Businessmall.Application.Infrastracture.Dispatchers {

   public class CommandDispatcher:ICommandDispatcher {
 
        private readonly IKernel _kernel = new StandardKernel();

    
       public CommandDispatcher (IKernel kernel){
           if(kernel ==  null){
               throw new ArgumentNullException("null exception");
           }
           _kernel = kernel;
       }

       public void Dispatch<TParameter>(TParameter command) where TParameter:ICommand{

           var kernel = _kernel.Get<ICommandHandler<TParameter>>();

           kernel.Execute(command);

       }
    }
}
