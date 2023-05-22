using TesteProgramacaoMF.Core.DomainObjects;

namespace TesteProgramacaoMF.Profissionais.Domain
{
    public class Obra : Entity
    {
        public string Nome { get; private set; }

        public IEnumerable<FuncionarioObra> FuncionarioObras => _funcionarioObras;
        private readonly IList<FuncionarioObra> _funcionarioObras = new List<FuncionarioObra>();

        // EF Constutor
        protected Obra()
        {
        }

        public Obra(string nome)
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
