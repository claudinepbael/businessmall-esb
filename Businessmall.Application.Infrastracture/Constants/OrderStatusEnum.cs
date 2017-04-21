using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Infrastracture.Constants
{
    public partial class Constants
    {
        public Constants() { 
        
        }

        public enum OrderStatus { 
            CONFIRMED,
            OUT_OF_STOCK,
            FAILED,
            //REJECTED
        }

        public static string getOrderStatus(OrderStatus status) {
            string statusString = "";

            switch (status) {
                case OrderStatus.CONFIRMED: 
                    statusString = "CONFIRMED";
                    break;
                case OrderStatus.OUT_OF_STOCK:
                    statusString = "OUT_OF_STOCK";
                    break;
                case OrderStatus.FAILED:
                    statusString = "FAILED";
                    break;
                default:
                    break;
            }

            return statusString;
        }
    }
}
