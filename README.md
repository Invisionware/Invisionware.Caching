# Invisionware.Caching

Implements a caching servicing framework that can be used with the any IoC framework (like Invisionware.Ioc). Caching providers can support Sync, Async or both depending on the implementation

Current implementations
- SystemRuntime (Async and Sync)
  - Invisionware.Caching.Net45.MemoryCache
- HttpApplicationCache (Async and Sync)
  - Invisionware.Caching.ASPNET.HttpApplicationCache
- HttpSessionCache (Async and Sync)
  - Invisionware.Caching.ASPNET.HttpSessionCache

To be implemented
- Sqlite

## Usage

```
// Create service
ICacheProvider cacheProvider = new Invisionware.Caching.Net45.MemoryCache();

// Register service with IOC
IDependencyContainer container = Resolver.Resolve<IDependencyContainer)();
container.Register<ICacheProvider>(x => cacheProvider);

// Resolve service from IOC
cache = Resolver.Resolve<ICacheProvider>();

// Add Item to Cache
cache.Add("SOMESTRING", "Some String Value");
cache.Add("SOMEDATETIME", DateTime.Now());
cache.Add("SOMEINT", 1);

// Get Items from the Cache
var i = cache.Get<int>("SOMEINT");
```