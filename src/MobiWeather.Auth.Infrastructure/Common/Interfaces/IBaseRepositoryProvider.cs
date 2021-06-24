namespace MobiWeather.Auth.Infrastructure.Common.Interfaces
{
    public interface IBaseRepositoryProvider
    {
        public IBaseRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, new();
    }
}