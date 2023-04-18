using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net;

namespace Laba_5
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public List<T> Data { get; set; }
    }
}
