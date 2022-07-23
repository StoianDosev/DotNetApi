namespace MyWeb.Application;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
