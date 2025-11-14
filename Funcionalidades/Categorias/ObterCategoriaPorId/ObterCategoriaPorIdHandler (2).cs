using Microsoft.EntityFrameworkCore;
using AprendizadoVerticalSlice.Infraestrutura;

namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.ObterCategoriaPorId;


public record CategoriaResposta(

    int Id,
    string Nome,
    string? Descricao
);


public class ObterCategoriaPorIdHandler
{
    private readonly BancoDeDados _bancoDeDados;

    public ObterCategoriaPorIdHandler(BancoDeDados bancoDeDados)
    {
        _bancoDeDados = bancoDeDados;
    }

    public async Task<CategoriaResposta?> Executar(int id)
    {

        var categoria = await _bancoDeDados.Categorias
            .Where(c => c.Id == id)
            .Select(c => new CategoriaResposta(
                c.Id,
                c.Nome,
                c.Descricao
            ))
            .FirstOrDefaultAsync();

        return categoria;
    }
}
