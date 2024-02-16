using DataAccess.Models;

namespace DataAccess.Data;

public interface IUnidadeData
{
    Task<IEnumerable<Unidade>> GetUnidades();
    Task<Unidade?> GetUnidade(int id);
}