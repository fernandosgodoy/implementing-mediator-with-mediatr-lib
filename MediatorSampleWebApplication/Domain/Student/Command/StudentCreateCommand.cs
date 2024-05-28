using MediatR;

namespace MediatorSample.WebApi.Domain.Student.Command
{
    public class StudentCreateCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
