using System.ComponentModel;
using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UnidadeData : IUnidadeData
{
    private readonly IsqlDataAccess _dataAccess;

    public UnidadeData(IsqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<IEnumerable<Unidade>> GetUnidades() =>
        _dataAccess.LoadData<Unidade, dynamic>("db_mac.sp_unidade_getALL", new { });

    public async Task<Unidade?> GetUnidade(int id)
    {
        var Unidades = await _dataAccess.LoadData<Unidade, dynamic>("db_mac.sp_unidade_get", new { Id = id });
        return Unidades.FirstOrDefault();
    }
    
}