using System.ComponentModel.DataAnnotations;

namespace TesteProgramacaoMF.Profissionais.Application.ViewModels
{
    [Display(Name = "Cargos")]
    public class CargoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
    }
}
