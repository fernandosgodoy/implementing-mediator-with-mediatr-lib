using MediatR;

namespace MediatorSample.WebApi.Domain.Student.Command
{
    public class StudentDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
