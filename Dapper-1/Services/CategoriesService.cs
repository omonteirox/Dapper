using System.Data.SqlClient;
using baltaDataAcess.Model;
using baltaDataAcess.Repositories;

namespace baltaDataAcess.Services
{

    public class CategoriesService
    {

        readonly Repository<Category> repository;
        public CategoriesService(SqlConnection connection)
        {
            repository = new Repository<Category>(connection);
        }

        public void Create(Category model) => repository.Create(model);
      
        public IEnumerable<Category> Get () => repository.Get();
       
        public Category GetById(int id) => repository.GetById(id);
       
        public void Update(Category model) => repository.Update(model);
       
        public void Delete(Category model) => repository.Delete(model);

       
    }

}
