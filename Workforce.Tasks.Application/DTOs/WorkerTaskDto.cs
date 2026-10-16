namespace Workforce.Tasks.Application.DTOs
{
    public class WorkerTaskDto
    {
        public Guid Id { get; set; }
        public Guid WorkerId { get; set; }
        public Guid? ScheduleId { get; set; }
        public string TaskType { get; set; } = string.Empty;
        public string? InputData { get; set; }
        public int Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? CompletedAt { get; set; }
    }
}