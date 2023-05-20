using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoMVC.Models
{
    public class Convenio
    {
        public int ConvenioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Descricao { get; set; }


        // EF Relacionamento
        public List<Paciente> Pacientes { get; set; }
    }
}
