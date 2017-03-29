using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.DataSyncServices.Services {
    public class SelectList<T>: IQueryResult where T:IQueryResult  {
        public SelectList(){
            Data = new List<T>();
        }

        public List<T> Data {get;set;}
    }
}
