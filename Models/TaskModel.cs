namespace TaskManager.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }

        public string TaskDescription { get; set; }

        public DateTime TaskDueDate { get; set; }

        public string TaskStatus { get; set; }

        public string TaskRemarks { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedOn { get; set; } = DateTime.UtcNow;
        //public DateTime CreatedOn { get; set; }
        //public DateTime LastUpdatedOn { get; set; }

        public string CreatedBy { get; set; }
        public string LastUpdatedBy { get; set; }

    }
}
