using TesteProgramacaoMF.Core.DomainObjects;

namespace TesteProgramacaoMF.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
