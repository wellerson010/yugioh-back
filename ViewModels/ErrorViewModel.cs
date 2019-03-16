using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.ViewModels
{
    public class ErrorViewModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public bool Error { get; set; } = true;
    }
}
