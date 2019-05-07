
namespace AngularAPI2_2.Models.ResponseModels
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = false;
            Msg = null;
            Data = null;
        }
        public BaseResponse(bool success, string msg, object data)
        {
            Success = success;
            Msg = msg;
            Data = data;
        }
        public bool Success { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
