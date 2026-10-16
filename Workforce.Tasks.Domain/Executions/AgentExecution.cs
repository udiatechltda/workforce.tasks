namespace Workforce.Domain.Executions
{
    public class AgentExecution
    {
        public Guid Id { get; private set; }

        public Guid AgentId { get; private set; }

        public string Objective { get; private set; }

        public ExecutionStatus Status { get; private set; }

        public DateTime StartedAt { get; private set; }

        public DateTime? FinishedAt { get; private set; }

        private AgentExecution()
        {
        }

        public AgentExecution(
            Guid agentId,
            string objective)
        {
            Id = Guid.NewGuid();
            AgentId = agentId;
            Objective = objective;
            Status = ExecutionStatus.Pending;
            StartedAt = DateTime.UtcNow;
        }
    }
}