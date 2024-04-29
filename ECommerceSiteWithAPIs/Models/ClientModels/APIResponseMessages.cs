using System.Net;

namespace ECommerceSiteWithAPIs.Models.ClientModels
{
    //public class APIResponseMessage<T>
    //{
    //    public bool Success { get; set; }
    //    public bool Error { get; set; }
    //    public IEnumerable<string> Description { get; set; }
    //    public HttpStatusCode StatusCode { get; set; }
    //    public T Data { get; set; }

    //    public APIResponseMessage(bool success, bool error, IEnumerable<string> msg, HttpStatusCode statusCode, T data)
    //    {
    //        Success = success;
    //        Error = error;
    //        Description = msg;
    //        StatusCode = statusCode;
    //        Data = data;
    //    }
    //}
    public class APIResponse
    {
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Description { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object? Data { get; set; }

        public APIResponse(bool success, bool error, string msg, HttpStatusCode statusCode, object? data)
        {
            Success = success;
            Error = error;
            Description = msg;
            StatusCode = statusCode;
            Data = data;
        }
    }

}
