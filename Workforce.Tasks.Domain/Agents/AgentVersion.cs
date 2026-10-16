namespace Workforce.Domain.Agents;

public class AgentVersion
{
    public Guid Id { get; private set; }

    public Guid AgentId { get; private set; }

    public string Version { get; private set; }

    public string DefinitionJson { get; private set; }

    public bool Published { get; private set; }
}