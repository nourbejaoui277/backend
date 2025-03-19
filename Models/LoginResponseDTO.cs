namespace Backend.Models
{
    public class LoginResponseDTO
    {
        public string token {  get; set; }
        public DateTime Expiration {  get; set; }
    }
}
