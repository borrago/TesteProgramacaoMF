using System.ComponentModel.DataAnnotations;

namespace TesteProgramacaoMF.Profissionais.Application.ViewModels
{
    [Display(Name = "Funcionario")]
    public class FuncionarioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Rg")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Rg { get; set; }

        [Display(Name = "Salario")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Salario { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CargoId { get; set; }

        public CargoViewModel? Cargo { get; set; }
    }
}
