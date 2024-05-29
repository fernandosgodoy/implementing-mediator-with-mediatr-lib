using MediatR;

namespace MediatorSample.Infrastructure.Notifications
{
    public class StudentActionNotification
        : INotification
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ActionNotification Action { get; set; }
    }
}
