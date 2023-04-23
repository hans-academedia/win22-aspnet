namespace _02_AspNet_WebApi.Models.Dtos
{
    public class User
    {
        public string Id { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
