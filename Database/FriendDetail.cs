using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Database
{
    public class FriendDetail
    {
        public int FriendDetailId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int FriendId { get; set; }
        [ForeignKey("FriendId")]
        public Friend Friend { get; set; }

        public string Type { get; set; }
    }
}