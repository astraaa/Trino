using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Database
{
    public class Commentary
    {
        public int CommentaryId { get; set; }
        public string Text { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public Task Task { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}