﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Messages
{
    public class ResponseCodeMessage
    {
        public ReponseCode Code { get; set; }

        public string Message { get; set; }
    }
}
