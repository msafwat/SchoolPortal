using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Messages
{
    public class ResponseCodeMessageListResult<T> : ResponseCodeMessage
    {
        public List<T> Result { get; set; }
    }
}
