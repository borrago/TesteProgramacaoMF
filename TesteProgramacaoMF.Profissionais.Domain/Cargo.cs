using TesteProgramacaoMF.Core.DomainObjects;

namespace TesteProgramacaoMF.Profissionais.Domain
{
    public class Cargo : Entity
    {
        public string Nome { get; private set; }

        public IEnumerable<Funcionario> Funcionarios => _funcionarios;
        private readonly IList<Funcionario> _funcionarios = new List<Funcionario>();

        // EF Constutor
        protected Cargo()
        {
        }

        public Cargo(string nome)
        {
            Nome = nome;

            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio");
            Validacoes.ValidarSeNulo(Nome, "O campo Nome não pode estar nulo");
            Validacoes.ValidarTamanho(Nome, 100, "O campo Nome não pode ser maior que 100 caracteres");
        }
    }
}
