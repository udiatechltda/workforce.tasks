namespace Workforce.Domain.Agents
{
    public class AgentType
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }

        private AgentType()
        {
        }

        public static AgentType Create(string name, string description)
        {
            return new AgentType
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Active = true
            };
        }
    }
}