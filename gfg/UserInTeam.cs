using System.ComponentModel.DataAnnotations.Schema;

namespace TrinoWPF.Database
{
    public class UserInTeam
    {
        public int UserInTeamId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}