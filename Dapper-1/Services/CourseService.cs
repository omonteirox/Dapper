using System.Data.SqlClient;
using baltaDataAcess.Model;
using baltaDataAcess.Repositories;

namespace baltaDataAcess.Services
{

    public class CourseService
    {

        readonly Repository<Course> repository;
        public CourseService(SqlConnection connection)
        {
            repository = new Repository<Course>(connection);
        }

        public void Create(Course model) => repository.Create(model);
      
        public IEnumerable<Course> Get () => repository.Get();
       
        public void GetById(int id) => repository.GetById(id);
       
        public void Update(Course model) => repository.Update(model);
       
        public void Delete(Course model) => repository.Delete(model);

       
    }

}
