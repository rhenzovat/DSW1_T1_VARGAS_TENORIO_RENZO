using System.ComponentModel.DataAnnotations;

namespace DSW1_T1_VARGAS_TENORIO_RENZO.Models
{
    public class NivelAcademico
    {
        [Key]
        public int NivelAcademicoId { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public int Orden { get; set; }

        public ICollection<Curso>? Cursos { get; set; }
    }
}
