namespace LockSafe.Application.DTOs
{
    public class PasswordCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public string Account { get; set; }
        public string PasswordValue { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsAdmin { get; set; }
    }

}
