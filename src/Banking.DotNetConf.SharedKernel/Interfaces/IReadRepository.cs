using Ardalis.Specification;

namespace Banking.DotNetConf.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
