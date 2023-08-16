using System.Data.SqlClient;
using baltaDataAcess.Model;
using baltaDataAcess.Repositories;

namespace baltaDataAcess.Services
{

    public class CareerService
    {

        readonly Repository<Career> repository;
        public CareerService(SqlConnection connection)
        {
            repository = new Repository<Career>(connection);
        }

        public void Create(Career model) => repository.Create(model);
      
        public IEnumerable<Career> Get () => repository.Get();
       
        public void GetById(int id) => repository.GetById(id);
       
        public void Update(Career model) => repository.Update(model);
       
        public void Delete(Career model) => repository.Delete(model);

       
    }

}
