namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public abstract class DomainEvent
    {
        public DateTimeOffset Timestamp { get; private set; } = DateTimeOffset.UtcNow;
    }
}
