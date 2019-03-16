using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.ViewModels
{
    public class ResponseViewModel
    {
        public bool Error { get; set; } = false;

        public dynamic Response { get; set; }

        public ResponseViewModel(object response)
        {
            Response = response;
        }
    }
}
