using Microsoft.Extensions.DependencyInjection;
using MobiWeather.Auth.Infrastructure.Common.Interfaces;
using System;

namespace MobiWeather.Auth.Infrastructure.Common.Providers
{
    public class BaseRepositoryProvider : IBaseRepositoryProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public BaseRepositoryProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        IBaseRepository<T> IBaseRepositoryProvider.GetRepository<T>()
        {
            return _serviceProvider.GetRequiredService<IBaseRepository<T>>();
        }
    }
}