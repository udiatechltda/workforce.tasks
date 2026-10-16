namespace Workforce.Domain.Agents
{
    public interface IAgentRepository
    {
        Task AddAsync(
            Agent agent,
            CancellationToken cancellationToken = default);

        Task<Agent?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);
    }
}