using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MTModels.DTOs
{
    public class Response<T>
    {

        public Response(bool isSuccessful, string message, IEnumerable<T> data, HttpStatusCode status)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            Data = data;
            Status = status;
        }

        public Response(bool isSuccessful, string message, HttpStatusCode status)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            Status = status;
        }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
