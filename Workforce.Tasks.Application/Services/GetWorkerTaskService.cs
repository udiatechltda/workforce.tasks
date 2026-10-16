using Workforce.Tasks.Application.DTOs;
using Workforce.Tasks.Application.Interfaces;

namespace Workforce.Tasks.Application.Services
{
    public class GetWorkerTaskService
    {
        private readonly IWorkerTaskRepository _repository;

        public GetWorkerTaskService(IWorkerTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<WorkerTaskDto?> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }
    }
}