using MediatorSample.Domain.Student.Command;
using MediatorSample.Domain.Student.Entity;
using MediatorSample.Infrastructure.Interfaces;
using MediatorSample.Infrastructure.Notifications;
using MediatR;

namespace MediatorSample.Infrastructure.EventHandlers
{
    public class StudentCommandHandler
        : IRequestHandler<StudentCreateCommand, string>,
          IRequestHandler<StudentUpdateCommand, string>,
          IRequestHandler<StudentDeleteCommand, string>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMediator _mediator;
        public StudentCommandHandler(IStudentRepository studentRepository,
            IMediator mediator)
        {
            _studentRepository = studentRepository;
            _mediator = mediator;

        }
        public async Task<string> Handle(StudentCreateCommand request, CancellationToken cancellationToken)
        {
            var student = new StudentEntity(request.Id, request.FirstName, request.LastName, request.Email);
            await _studentRepository.Save(student);

            await _mediator.Publish(new StudentActionNotification
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Action = ActionNotification.Created
            }, cancellationToken);

            return await Task.FromResult("Student created successfully.");
        }

        public async Task<string> Handle(StudentUpdateCommand request, CancellationToken cancellationToken)
        {
            var student = new StudentEntity(request.Id, request.FirstName, request.LastName, request.Email);
            await _studentRepository.Update(request.Id, student);

            await _mediator.Publish(new StudentActionNotification
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Action = ActionNotification.Updated
            }, cancellationToken);

            return await Task.FromResult("Student updated successfully.");
        }

        public async Task<string> Handle(StudentDeleteCommand request, CancellationToken cancellationToken)
        {
            var client = await _studentRepository.GetById(request.Id);
            await _studentRepository.Delete(request.Id);

            await _mediator.Publish(new StudentActionNotification
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Action = ActionNotification.Deleted
            }, cancellationToken);

            return await Task.FromResult("Student deleted successfully.");
        }
    }
}
