using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Workforce.Tasks.Application.Services;

namespace Workforce.Tasks.Api.Controllers
{
    public record CreateTaskRequest(Guid WorkerId, string TaskType, JsonElement? InputData);

    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly CreateWorkerTaskService _createService;
        private readonly GetWorkerTaskService _getService;

        public TasksController(CreateWorkerTaskService createService, GetWorkerTaskService getService)
        {
            _createService = createService;
            _getService = getService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskRequest request, CancellationToken cancellationToken)
        {
            if (request.WorkerId == Guid.Empty || string.IsNullOrWhiteSpace(request.TaskType))
            {
                return BadRequest("WorkerId e TaskType são obrigatórios.");
            }

            var taskId = await _createService.ExecuteAsync(
                request.WorkerId,
                request.TaskType,
                request.InputData?.GetRawText(),
                cancellationToken);

            return Accepted(new
            {
                Id = taskId,
                Status = "Pending"
            });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var task = await _getService.ExecuteAsync(id, cancellationToken);

            if (task is null)
                return NotFound();

            return Ok(task);
        }
    }
}