using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.ViewModels
{
    public class ResponseViewModel<T> 
    {
        public bool Error { get; set; } = false;

        public T Response { get; set; }

        public ResponseViewModel(T response)
        {
            Response = response;
        }
    }
}
