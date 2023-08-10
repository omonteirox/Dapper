using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;


namespace baltaDataAcess.Repositories
{
    public class Repository<T> where T : class
    {
        readonly SqlConnection _connection;
        public Repository(SqlConnection connection) {
            _connection = connection;
        }
        public IEnumerable<T> Get() {
            return _connection.GetAll<T>();
        }
        public T GetById(int id) {
            return _connection.Get<T>(id);
        }
        public void Create(T model) {
            _connection.Insert<T>(model);
        }
        public void Update(T model) {
            _connection.Update<T>(model);
        }
        public void Delete(T model) {
            _connection.Delete<T>(model);
        }
        public void DeleteById(int id) {
            var model = GetById(id);
            if (model != null)
                _connection.Delete<T>(model);
            else
                return;
        }
        
       

    }
}
