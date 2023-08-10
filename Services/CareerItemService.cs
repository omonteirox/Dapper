using System.Data.SqlClient;
using baltaDataAcess.Model;
using baltaDataAcess.Repositories;

namespace baltaDataAcess.Services
{

    public class CareerItemService
    {

        readonly Repository<CareerItem> repository;
        public CareerItemService(SqlConnection connection)
        {
            repository = new Repository<CareerItem>(connection);
        }

        public void Create(CareerItem model) => repository.Create(model);
      
        public IEnumerable<CareerItem> Get () => repository.Get();
       
        public void GetById(int id) => repository.GetById(id);
       
        public void Update(CareerItem model) => repository.Update(model);
       
        public void Delete(CareerItem model) => repository.Delete(model);

       
       
    }

}
