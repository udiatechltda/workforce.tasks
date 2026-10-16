namespace Workforce.Domain.Agents
{
    public class AgentTemplate
    {
        public Guid Id { get; private set; }
        public Guid AgentTypeId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public AgentType AgentType { get; private set; }
    }
}