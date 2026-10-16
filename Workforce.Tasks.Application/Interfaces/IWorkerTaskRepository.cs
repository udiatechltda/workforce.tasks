using Workforce.Tasks.Application.DTOs;

namespace Workforce.Tasks.Application.Interfaces
{
    public interface IWorkerTaskRepository
    {
        Task<Guid> CreateAsync(Guid workerId, string taskType, string? inputData, CancellationToken cancellationToken);

        Task<WorkerTaskDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}