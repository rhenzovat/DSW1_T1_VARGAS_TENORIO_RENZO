using DSW1_T1_VARGAS_TENORIO_RENZO.Models;

namespace DSW1_T1_VARGAS_TENORIO_RENZO.Data
{
    public class NivelAcademicoRepository
    {
        private readonly ApplicationDbContext _context;

        public NivelAcademicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<NivelAcademico> Listar()
        {
            return _context.NivelesAcademicos.ToList();
        }
    }
}
