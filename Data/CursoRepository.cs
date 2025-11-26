using DSW1_T1_VARGAS_TENORIO_RENZO.Models;
using Microsoft.EntityFrameworkCore;

namespace DSW1_T1_VARGAS_TENORIO_RENZO.Data
{
    public class CursoRepository
    {
        private readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Curso> ListarTodos()
        {
            return _context.Cursos.Include(c => c.NivelAcademico).ToList();
        }

        public IEnumerable<Curso> ListarPorNivel(int nivelId)
        {
            return _context.Cursos
                .Where(c => c.NivelAcademicoId == nivelId)
                .Include(c => c.NivelAcademico)
                .ToList();
        }

        public Curso Crear(Curso curso)
        {
            _context.Cursos.Add(curso);
            _context.SaveChanges();
            return curso;
        }

        public bool Actualizar(int id, Curso cursoActualizado)
        {
            var curso = _context.Cursos.Find(id);
            if (curso == null) return false;

            curso.CodigoCurso = cursoActualizado.CodigoCurso;
            curso.NombreCurso = cursoActualizado.NombreCurso;
            curso.Creditos = cursoActualizado.Creditos;
            curso.HorasSemanales = cursoActualizado.HorasSemanales;
            curso.NivelAcademicoId = cursoActualizado.NivelAcademicoId;

            _context.SaveChanges();
            return true;
        }
    }
}

