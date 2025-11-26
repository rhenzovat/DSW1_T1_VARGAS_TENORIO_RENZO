using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSW1_T1_VARGAS_TENORIO_RENZO.Models
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }

        [Required]
        public string CodigoCurso { get; set; } = string.Empty;

        [Required]
        public string NombreCurso { get; set; } = string.Empty;

        public int Creditos { get; set; }

        public int HorasSemanales { get; set; }

        [ForeignKey("NivelAcademico")]
        public int NivelAcademicoId { get; set; }

        public NivelAcademico? NivelAcademico { get; set; }
    }
}

