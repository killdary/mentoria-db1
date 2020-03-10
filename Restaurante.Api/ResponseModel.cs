using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante.Api
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public IEnumerable<ResponseModelNotification> Notifications { get; set; }
    }
}
