using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrinoWPF.Database
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }

        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}