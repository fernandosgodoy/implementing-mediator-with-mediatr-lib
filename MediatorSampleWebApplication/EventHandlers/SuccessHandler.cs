using MediatorSample.WebApi.Notifications;
using MediatR;

namespace MediatorSample.WebApi.EventHandlers
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
