namespace LN.Auth.API.Models
{
    public class Response
    {
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public object? Data { get; set; }
    }
}
