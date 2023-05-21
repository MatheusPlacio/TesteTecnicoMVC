using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoMVC.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataDeNascimento { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Genero { get; set; }

        [StringLength(11, ErrorMessage = "O campo {0} precisa ter 11 dígitos", MinimumLength = 11)]
        public string? CPF { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 7)]
        public string RG { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string UF_RG { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter no mínimo 11 dígitos", MinimumLength = 11)]
        public string Celular { get; set; }

        [StringLength(14, ErrorMessage = "O campo {0} precisa ter no mínimo 10 dígitos", MinimumLength = 10)]
        public string TelefoneFixo { get; set; }

        [StringLength(70, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(70, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string CarteirinhaDoConvenio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(7, ErrorMessage = "O campo {0} preciso ser no format 01/2001")]
        public string ValidadeDaCarteirinha { get; set; }



        // EF Relacionamento
        public Convenio Convenio { get; set; }

        [Display(Name = "Convênio")]
        public int ConvenioId { get; set; }
    }
}
