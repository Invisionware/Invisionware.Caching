// ***********************************************************************
// Assembly         : Invisionware.Caching.ASPNET
// Author           : sanderson
// Created          : 10-04-2018
//
// Last Modified By : sanderson
// Last Modified On : 12-23-2018
// ***********************************************************************
// <copyright file="HttpApplicationCache.cs" company="Invisionware">
//     Copyright © 2020 Invisionware
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invisionware.Caching.ASPNET
{
	/// <summary>
	/// Class HttpApplicationCache.
	/// Implements the <see cref="Invisionware.Caching.IAsyncCacheProvider" />
	/// </summary>
	/// <seealso cref="Invisionware.Caching.IAsyncCacheProvider" />
	public class HttpApplicationCache : IAsyncCacheProvider
	{
		//private ISession _session;

		/// <summary>
		/// Initializes a new instance of the <see cref="HttpApplicationCache"/> class.
		/// </summary>
		public HttpApplicationCache()
		{
			//if (session == null) throw new ArgumentNullException(nameof(session));

			//_session = session;
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <param name="fianlly"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool fianlly)
		{
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Adds a new item into the cache at the specified cache key only if the cache is empty.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item.</param>
		/// <param name="value">Item to add.</param>
		/// <returns>True if item was added, otherwise false.</returns>
		public bool Add<T>(string key, T value)
		{
			return Set<T>(key, value);
		}

		/// <summary>
		/// Adds a new item into the cache at the specified cache key only if the cache is empty.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item.</param>
		/// <param name="value">Item to add.</param>
		/// <param name="expiresAt">Expiration time.</param>
		/// <returns>True if item was added, otherwise false.</returns>
		public bool Add<T>(string key, T value, DateTime expiresAt)
		{
			return Set<T>(key, value, expiresAt);
		}

		/// <summary>
		/// Adds a new item into the cache at the specified cache key only if the cache is empty.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item.</param>
		/// <param name="value">Item to add.</param>
		/// <param name="expiresIn">Expiration timespan.</param>
		/// <returns>True if item was added, otherwise false.</returns>
		public bool Add<T>(string key, T value, TimeSpan expiresIn)
		{
			return Set<T>(key, value, expiresIn);
		}

		/// <summary>
		/// Adds a new item into the cache at the specified cache key only if the cache is empty.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item.</param>
		/// <param name="value">Item to add.</param>
		/// <returns>True if item was added, otherwise false.</returns>
		public Task<bool> AddAsync<T>(string key, T value)
		{
			return Task.Run(() => Add(key, value));
		}

		/// <summary>
		/// Adds a new item into the cache at the specified cache key only if the cache is empty.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item.</param>
		/// <param name="value">Item to add.</param>
		/// <param name="expiresAt">Expiration time.</param>
		/// <returns>True if item was added, otherwise false.</returns>
		public Task<bool> AddAsync<T>(string key, T value, DateTime expiresAt)
		{
			return Task.Run(() => Add(key, value, expiresAt));
		}

		/// <summary>
		/// Adds a new item into the cache at the specified cache key only if the cache is empty.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item.</param>
		/// <param name="value">Item to add.</param>
		/// <param name="expiresIn">Expiration timespan.</param>
		/// <returns>True if item was added, otherwise false.</returns>
		public Task<bool> AddAsync<T>(string key, T value, TimeSpan expiresIn)
		{
			return Task.Run(() => Add(key, value, expiresIn));
		}

		/// <summary>
		/// Flushes the entire cache (and clears it).
		/// </summary>
		/// <returns>Retrurns true on success</returns>
		public bool FlushAll()
		{
			//_session.CommitAsync();

			return true;
		}

		/// <summary>
		/// Flushes the entire cache (and clears it).
		/// </summary>
		/// <returns>Retrurns true on success</returns>
		public Task<bool> FlushAllAsync()
		{
			//await _session.CommitAsync();

			return Task.FromResult(true);
		}

		/// <summary>
		/// Retrieves the requested item from the cache.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">The key.</param>
		/// <returns>Requested cache item.</returns>
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

		/// <summary>
		/// Gets all of the items in the cache related to the specified keys.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="keys">The keys.</param>
		/// <returns>A dictionary with thne requested items</returns>
		public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
		{
			var d = new Dictionary<string, T>();

			foreach (var k in keys)
			{
				d[k] = Get<T>(k);
			}

			return d;
		}

		/// <summary>
		/// Gets all of the items in the cache related to the specified keys.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="keys">The keys.</param>
		/// <returns>A dictionary with thne requested items</returns>
		public Task<IDictionary<string, T>> GetAllAsync<T>(IEnumerable<string> keys)
		{
			return Task.Run(() => GetAll<T>(keys));
		}

		/// <summary>
		/// Retrieves the requested item from the cache.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">The key.</param>
		/// <returns>Requested cache item.</returns>
		public Task<T> GetAsync<T>(string key)
		{
			return Task.Run(() => Get<T>(key));
		}

		/// <summary>
		/// Removes the requested item from the cache.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>Retrurns true on success</returns>
		public bool Remove(string key)
		{
			//_session.Remove(key);

			return true;
		}

		/// <summary>
		/// Removes all items in the cache with the specified keys.
		/// </summary>
		/// <param name="keys">The keys.</param>
		/// <returns>Retrurns true on success</returns>
		public bool RemoveAll(IEnumerable<string> keys)
		{
			foreach (var k in keys)
			{
				Remove(k);
			}

			return true;
		}

		/// <summary>
		/// Removes all items in the cache with the specified keys.
		/// </summary>
		/// <param name="keys">The keys.</param>
		/// <returns>Task&lt;System.Boolean&gt;.</returns>
		public Task<bool> RemoveAllAsync(IEnumerable<string> keys)
		{
			return Task.Run(() => RemoveAll(keys));
		}

		/// <summary>
		/// Removes the requested item from the cache.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>Task&lt;System.Boolean&gt;.</returns>
		public Task<bool> RemoveAsync(string key)
		{
			return Task.Run(() => Remove(key));
		}

		/// <summary>
		/// Replaces the item at the cache.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item to replace.</param>
		/// <param name="value">Item to replace with.</param>
		/// <returns>True if the item exists, otherwise false.</returns>
		public bool Replace<T>(string key, T value)
		{
			return Add(key, value);
		}

		/// <summary>
		/// Replaces the item at the cache.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item to replace.</param>
		/// <param name="value">Item to replace with.</param>
		/// <param name="expiresAt">Expiration time.</param>
		/// <returns>True if the item exists, otherwise false.</returns>
		public bool Replace<T>(string key, T value, DateTime expiresAt)
		{
			return Add(key, value, expiresAt);
		}

		/// <summary>
		/// Replaces an item in the cache.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item to replace.</param>
		/// <param name="value">Item to replace with.</param>
		/// <param name="expiresIn">Expiration timespan.</param>
		/// <returns>True if item was replaced, otherwise false.</returns>
		public bool Replace<T>(string key, T value, TimeSpan expiresIn)
		{
			return Add(key, value, expiresIn);
		}

		/// <summary>
		/// Replaces the item at the cache.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item to replace.</param>
		/// <param name="value">Item to replace with.</param>
		/// <returns>True if the item exists, otherwise false.</returns>
		public Task<bool> ReplaceAsync<T>(string key, T value)
		{
			return Task.Run(() => Replace(key, value));
		}

		/// <summary>
		/// Replaces the item at the cache.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item to replace.</param>
		/// <param name="value">Item to replace with.</param>
		/// <param name="expiresAt">Expiration time.</param>
		/// <returns>True if the item exists, otherwise false.</returns>
		public Task<bool> ReplaceAsync<T>(string key, T value, DateTime expiresAt)
		{
			return Task.Run(() => Replace(key, value, expiresAt));
		}

		/// <summary>
		/// Replaces an item in the cache.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item to replace.</param>
		/// <param name="value">Item to replace with.</param>
		/// <param name="expiresIn">Expiration timespan.</param>
		/// <returns>True if item was replaced, otherwise false.</returns>
		public Task<bool> ReplaceAsync<T>(string key, T value, TimeSpan expiresIn)
		{
			return Task.Run(() => Replace(key, value, expiresIn));

		}

		/// <summary>
		/// Sets an item into the cache at the cache key specified regardless if it already exists or not.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item.</param>
		/// <param name="value">Item to set.</param>
		/// <returns>True if item was set, otherwise false.</returns>
		public bool Set<T>(string key, T value)
		{
			//var serializer = Resolver.Resolve<ISerializer>();

			//var obj = serializer.SerializeToBytes<T>(value);

			//_session.Set(key, obj);

			return true;
		}

		/// <summary>
		/// Sets an item into the cache at the cache key specified regardless if it already exists or not.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item.</param>
		/// <param name="value">Item to set.</param>
		/// <param name="expiresAt">Expiration time.</param>
		/// <returns>True if item was set, otherwise false.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public bool Set<T>(string key, T value, DateTime expiresAt)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sets an item into the cache at the cache key specified regardless if it already exists or not.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item.</param>
		/// <param name="value">Item to set.</param>
		/// <param name="expiresIn">Expiration timespan.</param>
		/// <returns>True if item was set, otherwise false.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public bool Set<T>(string key, T value, TimeSpan expiresIn)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sets an item into the cache at the cache key specified regardless if it already exists or not.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item.</param>
		/// <param name="value">Item to set.</param>
		/// <returns>True if item was set, otherwise false.</returns>
		public Task<bool> SetAsync<T>(string key, T value)
		{
			return Task.Run(() => Set(key, value));
		}

		/// <summary>
		/// Sets an item into the cache at the cache key specified regardless if it already exists or not.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item.</param>
		/// <param name="value">Item to set.</param>
		/// <param name="expiresAt">Expiration time.</param>
		/// <returns>True if item was set, otherwise false.</returns>
		public Task<bool> SetAsync<T>(string key, T value, DateTime expiresAt)
		{
			return Task.Run(() => Set(key, value, expiresAt));
		}

		/// <summary>
		/// Sets an item into the cache at the cache key specified regardless if it already exists or not.
		/// </summary>
		/// <typeparam name="T">Type of item.</typeparam>
		/// <param name="key">Key for the item.</param>
		/// <param name="value">Item to set.</param>
		/// <param name="expiresIn">Expiration timespan.</param>
		/// <returns>True if item was set, otherwise false.</returns>
		public Task<bool> SetAsync<T>(string key, T value, TimeSpan expiresIn)
		{
			return Task.Run(() => Set(key, value, expiresIn));
		}
	}
}
