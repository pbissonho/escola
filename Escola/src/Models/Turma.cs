using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Models
{
    public class Turma
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string serie { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string titulo { get; set; }

        [NotMapped]
        public int quantidadeDeAlunos
        {
            get
            {
                if(alunos != null){
                    return alunos.Count;
                } else return 0;
                
            }
            set
            {

            }
        }

        public List<Aluno> alunos { get; set; }

    }
}