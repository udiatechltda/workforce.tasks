
using Workforce.Tasks.Application.Interfaces;

namespace Workforce.Tasks.Application.Services
{
    public class CreateWorkerTaskService
    {
        private readonly IWorkerTaskRepository _repository;

        public CreateWorkerTaskService(IWorkerTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> ExecuteAsync(Guid workerId, string taskType, string? inputData, CancellationToken cancellationToken)
        {
            if (workerId == Guid.Empty)
                throw new ArgumentException("WorkerId inválido.");

            if (string.IsNullOrWhiteSpace(taskType))
                throw new ArgumentException("TaskType é obrigatório.");

            return await _repository.CreateAsync(workerId, taskType.Trim(), inputData, cancellationToken);
        }
    }
}