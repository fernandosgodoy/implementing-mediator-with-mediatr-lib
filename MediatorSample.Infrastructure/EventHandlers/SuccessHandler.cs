using MediatorSample.Infrastructure.Notifications;
using MediatR;

namespace MediatorSample.Infrastructure.EventHandlers
{
    public class SuccessHandler
        : INotificationHandler<StudentActionNotification>
    {
        public Task Handle(StudentActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"The student {notification.FirstName} {notification.LastName} was {notification.Action.ToString()} successfully.");
            });
        }
    }
}
