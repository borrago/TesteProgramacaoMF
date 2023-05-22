using System.ComponentModel.DataAnnotations;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Application.ViewModels
{
    [Display(Name = "Funcionario Obra")]
    public class FuncionarioObraViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Funcionario")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }

        [Display(Name = "Obra")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ObraId { get; set; }
        public Obra? Obra { get; set; }

        [Display(Name = "Data de Inicio")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DtInicio { get; set; }

        [Display(Name = "Data de Termino")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DtFim { get; set; }
    }
}
