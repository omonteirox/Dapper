using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;


namespace MaoNaMassa.Repositories
{
    public class Repository<TModel> where TModel : class
    {
       

        public IEnumerable<TModel> Get() => Database.Connection.GetAll<TModel>();

        public TModel GetById(int id) => Database.Connection.Get<TModel>(id);

        public void Create(TModel model)
        {
            var idProp = typeof(TModel).GetProperty("Id");
            idProp.SetValue(model, 0);
            Database.Connection.Insert<TModel>(model);
        }
        public void Update(TModel model)
        {
            var idProp = typeof(TModel).GetProperty("Id");
            if (int.Parse(idProp.GetValue(model).ToString()) != 0)
                Database.Connection.Update<TModel>(model);
        }

        public void Delete(int id)
        {
            var model = GetById(id);
            if (model != null)
                Database.Connection.Delete<TModel>(model);
        }
    }
}
