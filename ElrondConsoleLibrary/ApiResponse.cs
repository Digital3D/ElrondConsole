using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElrondConsoleLibrary
{
    public class ApiResponse<T>
    {
        public T Result { get; set; }

        public bool IsError { get; set; }

        public string Message { get; set; }
        public string Url { get; set; }
        public string ResultJson { get; set; }
        public string Data { get; set; }
    }
}
