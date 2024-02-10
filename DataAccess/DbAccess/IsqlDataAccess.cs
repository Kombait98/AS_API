namespace DataAccess.DbAccess;

public interface IsqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProdcedure, U parameters,
        string connectioname = "Default");

    Task SaveData<T>(string storedProdcedure, T parameters,
        string connectioname = "Default");
}