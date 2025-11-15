using Microsoft.AspNetCore.Mvc;

namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.ObterCategoriaPorId
{
    public static class ObterCategoriaPorIdEndpoint
    {
        public static IEndpointRouteBuilder MapObterCategoriaPorId(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/categorias/{id:int}", async (
                [FromRoute] int id,
                [FromServices] ObterCategoriaPorIdHandler handler) =>
            {
                var resposta = await handler.Executar(id);
                return resposta is null
                    ? Results.NotFound(new { mensagem = "Categoria não encontrada." })
                    : Results.Ok(resposta);
            })
            .WithName("ObterCategoriaPorId")
            .WithTags("Categorias")
            .Produces<CategoriaResposta>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            return endpoints;
        }
    }
}
