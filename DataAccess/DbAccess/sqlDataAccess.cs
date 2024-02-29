using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DbAccess;

public class sqlDataAccess : IsqlDataAccess
{
    private readonly IConfiguration _configuration;

    public sqlDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProdcedure, U parameters,
        string connectioname = "con01")
    {
        var con = _configuration.GetConnectionString(connectioname);
        using IDbConnection connection = new SqlConnection(con);
        return await connection.QueryAsync<T>(storedProdcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProdcedure, T parameters,
        string connectioname = "con01")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectioname));
        await connection.ExecuteAsync(storedProdcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}