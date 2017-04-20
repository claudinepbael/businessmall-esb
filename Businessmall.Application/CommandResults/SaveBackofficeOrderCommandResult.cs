using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.CommandResults
{
    public class SaveBackofficeOrderCommandResult : ICommandResult
    {
        public Guid orderID { get; set; }
        public bool isConfirmed { get; set; }
        public string message { get; set; }
    }
}
