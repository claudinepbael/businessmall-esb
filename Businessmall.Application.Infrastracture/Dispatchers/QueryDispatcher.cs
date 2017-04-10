using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Businessmall.Application.Infrastracture.Dispatchers {

   public class QueryDispatcher: IQueryDispatcher {
       private readonly IKernel _kernel = new StandardKernel();

       public QueryDispatcher(IKernel kernel){
           if (kernel == null){
                throw new ArgumentNullException("kernel");
           }

           _kernel = kernel;

       }

       public TResult Dispatch<TParameter,TResult>(TParameter query) where TParameter:IQuery where TResult:IQueryResult{

           var queryHandler = _kernel.Get<IQueryHandler<TParameter, TResult>>();

           return queryHandler.Retrieve(query);
       }
    }
}
