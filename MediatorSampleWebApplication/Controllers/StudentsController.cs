using MediatorSample.Domain.Student.Command;
using MediatorSample.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IMediator mediator,
            IStudentRepository studentRepository)
        {
            _mediator = mediator;
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>
            Ok(await _studentRepository.GetAll());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyIdAsync(int id) =>
            Ok(await _studentRepository.GetById(id));
        [HttpPost]
        public async Task<IActionResult> PostAsync(StudentCreateCommand command) =>
            Ok(await _mediator.Send(command));
        [HttpPut]
        public async Task<IActionResult> PutAsync(StudentUpdateCommand command) =>
            Ok(await _mediator.Send(command));
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var dto = new StudentDeleteCommand { Id = id };
            return Ok(await _mediator.Send(dto));
        }
    }
}
