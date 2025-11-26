using Microsoft.AspNetCore.Mvc;
using DSW1_T1_VARGAS_TENORIO_RENZO.Data;
using DSW1_T1_VARGAS_TENORIO_RENZO.Models;

namespace DSW1_T1_VARGAS_TENORIO_RENZO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly CursoRepository _repo;

        public CursosController(CursoRepository repo)
        {
            _repo = repo;
        }

        // GET: api/cursos
        [HttpGet]
        public ActionResult<IEnumerable<Curso>> Listar()
        {
            return Ok(_repo.ListarTodos());
        }

        // GET: api/cursos/nivel/3
        [HttpGet("nivel/{nivelId}")]
        public ActionResult<IEnumerable<Curso>> ListarPorNivel(int nivelId)
        {
            return Ok(_repo.ListarPorNivel(nivelId));
        }

        // POST: api/cursos
        [HttpPost]
        public ActionResult Crear([FromBody] Curso curso)
        {
            var creado = _repo.Crear(curso);
            return CreatedAtAction(nameof(Listar), new { id = creado.CursoId }, creado);
        }

        // PUT: api/cursos/4
        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, [FromBody] Curso curso)
        {
            var ok = _repo.Actualizar(id, curso);
            if (!ok) return NotFound();

            return NoContent();
        }
    }
}
