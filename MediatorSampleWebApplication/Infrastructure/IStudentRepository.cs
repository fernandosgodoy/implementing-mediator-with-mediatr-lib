using MediatorSample.Domain.Student.Entity;

namespace MediatorSample.WebApi.Infrastructure
{
    public interface IStudentRepository
    {
        Task Save(StudentEntity student);
        Task Update(int id, StudentEntity student);
        Task Delete(int id);
        Task<StudentEntity> GetById(int id);
        Task<IEnumerable<StudentEntity>> GetAll();
    }
}
