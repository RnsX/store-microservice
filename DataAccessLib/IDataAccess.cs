using System.Collections.Generic;

namespace DataAccessLib
{
    public interface IDataAccess
    {
        string ConnectionString { get; set; }

        List<T> LoadData<T, U>(string query, U parameters);
        void SaveData<U>(string query, U parameters);
    }
}