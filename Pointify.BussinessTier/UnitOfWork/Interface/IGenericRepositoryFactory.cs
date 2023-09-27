namespace Pointify.BussinessTier.UnitOfWork.Interface
{
	public interface IGenericRepositoryFactory
	{
		IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
	}
}
