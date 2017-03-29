using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.DataSyncServices.Queries {
    public class NewProductQuery: IQuery {

        public int id {get;set;}
        public string name {get;set;}
        public decimal price {get;set;}
        public int qty_at_hand {get;set;}
    }
}
