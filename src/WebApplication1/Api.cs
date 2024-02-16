using DataAccess.Data;
namespace WebApplication1;
public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/Unidade", GetUnidade);
        app.MapGet("/Unidades/{id}", GetUnidades);
        
    }
    private static async Task<IResult> GetUnidades(IUnidadeData data)
    {
        try
        {
            return Results.Ok(await data.GetUnidades());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetUnidade(int id,IUnidadeData data)
    {
        try
        {
            var unid = await data.GetUnidade(id);
            if (unid == null) return Results.NotFound();

            return Results.Ok(unid);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}