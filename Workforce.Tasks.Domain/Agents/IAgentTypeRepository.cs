namespace Workforce.Domain.Agents
{
    public interface IAgentTypeRepository
    {
        Task AddAsync(
            AgentType agentType,
            CancellationToken cancellationToken = default);

        Task<AgentType?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<AgentType>> GetAllAsync(
            CancellationToken cancellationToken = default);
    }
}
