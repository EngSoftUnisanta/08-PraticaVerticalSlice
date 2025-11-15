using AprendizadoVerticalSlice.Infraestrutura;
using Microsoft.EntityFrameworkCore;

namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.ObterCategoriaPorId
{
    public class ObterCategoriaPorIdHandler
    {
        private readonly BancoDeDados _db;

        public ObterCategoriaPorIdHandler(BancoDeDados db)
        {
            _db = db;
        }

        // O tipo de retorno deve ser Task<CategoriaResposta?> para permitir o retorno null
        public async Task<CategoriaResposta?> Executar(int id)
        {
            // Nota: Você pode precisar adicionar o DbSet<Categoria> aqui,
            // mas presumo que _db.Categorias esteja corretamente definido como DbSet<Categoria>.
            var categoria = await _db.Categorias
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria is null) return null;

            return new CategoriaResposta(
                categoria.Id,
                categoria.Nome,
                categoria.Descricao
            );
        }
    }

    public record CategoriaResposta(int Id, string Nome, string? Descricao);
}
