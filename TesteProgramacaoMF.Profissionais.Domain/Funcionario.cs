using TesteProgramacaoMF.Core.DomainObjects;

namespace TesteProgramacaoMF.Profissionais.Domain
{
    public class Funcionario : Entity
    {
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Rg { get; private set; }
        public decimal Salario { get; private set; }
        public Guid CargoId { get; private set; }
        public Cargo Cargo { get; private set; }

        public IEnumerable<FuncionarioObra> FuncionarioObras => _funcionarioObras;
        private readonly IList<FuncionarioObra> _funcionarioObras = new List<FuncionarioObra>();

        // EF Constutor
        protected Funcionario()
        {
        }

        public Funcionario(string nome, DateTime dataNascimento, string rg, decimal salario, Guid cargoId)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Rg = rg;
            Salario = salario;
            CargoId = cargoId;

            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio");
            Validacoes.ValidarSeNulo(Nome, "O campo Nome não pode estar nulo");
            Validacoes.ValidarTamanho(Nome, 100, "O campo Nome não pode ser maior que 100 caracteres");

            Validacoes.ValidarSeVazio(Rg, "O campo Nome não pode estar vazio");
            Validacoes.ValidarSeNulo(Rg, "O campo Nome não pode estar nulo");
            Validacoes.ValidarTamanho(Rg, 9, "O campo Nome não pode ser maior que 9 caracteres");
        }
    }
}
