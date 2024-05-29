using MediatR;

namespace MediatorSample.Infrastructure.Notifications
{
    public class ErrorNotification
        : INotification
    {
        public string Error { get; set; } = string.Empty;
        public string StackError { get; set; } = string.Empty;
    }
}
