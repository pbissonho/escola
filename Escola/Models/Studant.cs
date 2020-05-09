using System.ComponentModel.DataAnnotations;

namespace Escola.Models
{
    public class Estudante
    {

        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome {get; set;}

        public int Faltas {get; set;}

        public int Media {get; set;}

        public int TurmaId {get; set;}

        public Turma Turma {get; set;}
    
    }
}