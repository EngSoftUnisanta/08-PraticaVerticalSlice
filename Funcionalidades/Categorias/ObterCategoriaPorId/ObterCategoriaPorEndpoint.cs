using Microsoft.AspNetCore.Mvc;

namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.ObterCategoriaPorId;

public static class ObterCategoriaPorIdEndpoint
{
    public static IEndpointRouteBuilder MapObterCategoriaPorId(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/categorias/{id:int}", async (
            [FromRoute] int id,
            [FromServices] ObterCategoriaPorIdHandler handler) =>
        {
            var categoria = await handler.Executar(id);

            if (categoria is null)
                return Results.NotFound();

            return Results.Ok(categoria);
        })
        .WithName("ObterCategoriaPorId")
        .WithTags("Categorias")
        .Produces<CategoriaResposta>(200)
        .Produces(404);

        return endpoints;
    }
}