namespace LockSafe.Application.DTOs
{
    public class PasswordAllowanceDTO
    {
        public int PasswordId { get; set; }
        public int UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
