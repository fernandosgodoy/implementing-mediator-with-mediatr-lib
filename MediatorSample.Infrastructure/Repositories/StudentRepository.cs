using MediatorSample.Domain.Student.Entity;
using MediatorSample.Infrastructure.Interfaces;

namespace MediatorSample.Infrastructure.Repositories
{
    public class StudentRepository
        : IStudentRepository
    {
        public List<StudentEntity> Students { get; }
        public StudentRepository()
        {
            Students = new List<StudentEntity>();
        }
        public async Task Delete(int id)
        {
            int index = Students.FindIndex(x => x.Id == id);
            await Task.Run(() => Students.RemoveAt(index));
        }

        public async Task<IEnumerable<StudentEntity>> GetAll() =>
            await Task.Run(() => Students);

        public async Task<StudentEntity> GetById(int id)
        {
            var result = Students.Where(st => st.Id == id).SingleOrDefault() ?? null!;
            return await Task.FromResult(result);
        }

        public async Task Save(StudentEntity student) =>
            await Task.Run(() => Students.Add(student));

        public async Task Update(int id, StudentEntity student)
        {
            int index = Students.FindIndex(x => x.Id == id);
            if (index > -1)
                await Task.Run(() => Students[index] = student);
        }
    }
}
