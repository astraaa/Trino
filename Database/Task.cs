using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Database
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? FinishedOn { get; set; }

        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        public int UserId { get; set; }
    }
}