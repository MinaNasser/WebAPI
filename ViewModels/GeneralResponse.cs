namespace WebAPIDotNet.DTO
{
    public class GeneralResponse
    {
        //public int StatusCode { get; set; }
        //public T Data { get; set; }

        public bool  IsSuccess { get; set; }

        public dynamic Data { get; set; }

    }
}
