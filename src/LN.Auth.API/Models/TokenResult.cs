namespace LN.Auth.API.Models
{
    public class TokenResult
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
