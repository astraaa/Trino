namespace Diplom.Database
{
    public class User
    {
        public int UserId { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Otdel { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public bool NewUser { get; set; }
        public bool isAdmin { get; set; }
    }
}