namespace Workforce.Domain.Agents
{
    public class Agent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        private readonly List<AgentVersion> _versions = [];
        public IReadOnlyCollection<AgentVersion> Versions => _versions;

        private Agent()
        {
        }

        public static Agent Create(string name, string description)
        {
            return new Agent
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Active = true
            };
        }
    }
}