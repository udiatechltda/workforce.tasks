using Npgsql;
using NpgsqlTypes;
using Workforce.Tasks.Application.DTOs;
using Workforce.Tasks.Application.Interfaces;

namespace Workforce.Tasks.Infrastructure.Repositories
{
    public class WorkerTaskRepository : IWorkerTaskRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public WorkerTaskRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<Guid> CreateAsync(Guid workerId, string taskType, string? inputData, CancellationToken cancellationToken)
        {
            var taskId = Guid.NewGuid();

            const string sql = """
                INSERT INTO "WorkerTasks"
                (
                    "Id",
                    "WorkerId",
                    "TaskType",
                    "InputData",
                    "Status",
                    "CreatedAt"
                )
                VALUES
                (
                    @Id,
                    @WorkerId,
                    @TaskType,
                    @InputData,
                    @Status,
                    @CreatedAt
                )
            """;

            await using var command = _dataSource.CreateCommand(sql);

            command.Parameters.AddWithValue("Id", taskId);

            command.Parameters.AddWithValue("WorkerId", workerId);

            command.Parameters.AddWithValue("TaskType", taskType);

            command.Parameters.Add("InputData", NpgsqlDbType.Text).Value = (object?)inputData ?? DBNull.Value;

            // WorkerTaskStatus.Pending = 1
            command.Parameters.AddWithValue("Status", 1);

            command.Parameters.AddWithValue("CreatedAt", DateTime.UtcNow);

            await command.ExecuteNonQueryAsync(cancellationToken);

            return taskId;
        }

        public async Task<WorkerTaskDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            const string sql = """
                    SELECT
                        "Id",
                        "WorkerId",
                        "ScheduleId",
                        "TaskType",
                        "InputData",
                        "Status",
                        "CreatedAt",
                        "CompletedAt"
                    FROM "WorkerTasks"
                    WHERE "Id" = @Id
                """;

            await using var command = _dataSource.CreateCommand(sql);

            command.Parameters.AddWithValue("Id", id);

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (!await reader.ReadAsync(cancellationToken))
                return null;

            return new WorkerTaskDto
            {
                Id = reader.GetGuid(0),
                WorkerId = reader.GetGuid(1),
                ScheduleId = reader.IsDBNull(2)
                    ? null
                    : reader.GetGuid(2),
                TaskType = reader.GetString(3),
                InputData = reader.IsDBNull(4)
                    ? null
                    : reader.GetString(4),
                Status = reader.GetInt32(5),
                CreatedAt = reader.GetFieldValue<DateTimeOffset>(6),
                CompletedAt = reader.IsDBNull(7)
                    ? null
                    : reader.GetFieldValue<DateTimeOffset>(7)
            };
        }
    }
}