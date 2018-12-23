using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invisionware.Caching.ASPNET
{
	public class HttpApplicationCache : IAsyncCacheProvider
	{
		//private ISession _session;

		public HttpApplicationCache()
		{
			//if (session == null) throw new ArgumentNullException(nameof(session));

			//_session = session;
		}

		public bool Add<T>(string key, T value)
		{
			return Set<T>(key, value);
		}

		public bool Add<T>(string key, T value, DateTime expiresAt)
		{
			return Set<T>(key, value, expiresAt);
		}

		public bool Add<T>(string key, T value, TimeSpan expiresIn)
		{
			return Set<T>(key, value, expiresIn);
		}

		public Task<bool> AddAsync<T>(string key, T value)
		{
			return Task.Run(() => Add(key, value));
		}

		public Task<bool> AddAsync<T>(string key, T value, DateTime expiresAt)
		{
			return Task.Run(() => Add(key, value, expiresAt));
		}

		public Task<bool> AddAsync<T>(string key, T value, TimeSpan expiresIn)
		{
			return Task.Run(() => Add(key, value, expiresIn));
		}

		public void Dispose()
		{
		}

		public bool FlushAll()
		{
			//_session.CommitAsync();

			return true;
		}

		public Task<bool> FlushAllAsync()
		{
			//await _session.CommitAsync();

			return Task.FromResult(true);
		}

		public T Get<T>(string key)
		{
			//byte[] value;

			//if (_session.TryGetValue(key, out value))
			//{
			//	var serializer = Resolver.Resolve<ISerializer>();

			//	var obj = serializer.Deserialize<T>(value);

			//	return (T)obj;
			//}

			return default(T);
		}

		public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
		{
			var d = new Dictionary<string, T>();

			foreach (var k in keys)
			{
				d[k] = Get<T>(k);
			}

			return d;
		}

		public Task<IDictionary<string, T>> GetAllAsync<T>(IEnumerable<string> keys)
		{
			return Task.Run(() => GetAll<T>(keys));
		}

		public Task<T> GetAsync<T>(string key)
		{
			return Task.Run(() => Get<T>(key));
		}

		public bool Remove(string key)
		{
			//_session.Remove(key);

			return true;
		}

		public bool RemoveAll(IEnumerable<string> keys)
		{
			foreach (var k in keys)
			{
				Remove(k);
			}

			return true;
		}

		public Task<bool> RemoveAllAsync(IEnumerable<string> keys)
		{
			return Task.Run(() => RemoveAll(keys));
		}

		public Task<bool> RemoveAsync(string key)
		{
			return Task.Run(() => Remove(key));
		}

		public bool Replace<T>(string key, T value)
		{
			return Add(key, value);
		}

		public bool Replace<T>(string key, T value, DateTime expiresAt)
		{
			return Add(key, value, expiresAt);
		}

		public bool Replace<T>(string key, T value, TimeSpan expiresIn)
		{
			return Add(key, value, expiresIn);
		}

		public Task<bool> ReplaceAsync<T>(string key, T value)
		{
			return Task.Run(() => Replace(key, value));
		}

		public Task<bool> ReplaceAsync<T>(string key, T value, DateTime expiresAt)
		{
			return Task.Run(() => Replace(key, value, expiresAt));
		}

		public Task<bool> ReplaceAsync<T>(string key, T value, TimeSpan expiresIn)
		{
			return Task.Run(() => Replace(key, value, expiresIn));

		}

		public bool Set<T>(string key, T value)
		{
			//var serializer = Resolver.Resolve<ISerializer>();

			//var obj = serializer.SerializeToBytes<T>(value);

			//_session.Set(key, obj);

			return true;
		}

		public bool Set<T>(string key, T value, DateTime expiresAt)
		{
			throw new NotImplementedException();
		}

		public bool Set<T>(string key, T value, TimeSpan expiresIn)
		{
			throw new NotImplementedException();
		}

		public Task<bool> SetAsync<T>(string key, T value)
		{
			return Task.Run(() => Set(key, value));
		}

		public Task<bool> SetAsync<T>(string key, T value, DateTime expiresAt)
		{
			return Task.Run(() => Set(key, value, expiresAt));
		}

		public Task<bool> SetAsync<T>(string key, T value, TimeSpan expiresIn)
		{
			return Task.Run(() => Set(key, value, expiresIn));
		}
	}
}
