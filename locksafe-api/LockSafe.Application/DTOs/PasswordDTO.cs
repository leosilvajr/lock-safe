namespace LockSafe.Application.DTOs
{
    public class PasswordDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public string Account { get; set; }
        public string PasswordValue { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }

}
