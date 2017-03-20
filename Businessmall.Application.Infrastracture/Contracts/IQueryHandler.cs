using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Infrastracture.Contracts {
    public interface IQueryHandler<in TParameter, out TResult> where TParameter:IQuery where TResult:IQueryResult{

        TResult Retrieve(TParameter query);
    }
}
