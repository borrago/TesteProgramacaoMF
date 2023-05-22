using TesteProgramacaoMF.Core.DomainObjects;

namespace TesteProgramacaoMF.Profissionais.Domain
{
    public class FuncionarioObra : Entity
    {
        public Guid FuncionarioId { get; private set; }
        public Funcionario Funcionario { get; private set; }
        public Guid ObraId { get; private set; }
        public Obra Obra { get; private set; }
        public DateTime DtInicio { get; private set; }
        public DateTime DtFim { get; private set; }

        // EF Constutor
        protected FuncionarioObra()
        {
        }

        public FuncionarioObra(Guid funcionarioId, Guid obraId, DateTime dtInicio, DateTime dtFim)
        {
            FuncionarioId = funcionarioId;
            ObraId = obraId;
            DtInicio = dtInicio;
            DtFim = dtFim;
        }
    }
}
