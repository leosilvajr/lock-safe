namespace LockSafe.Application.DTOs
{
    public class UserCreateDTO
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Password { get; set; } // Senha é necessária apenas na criação
    }
}
