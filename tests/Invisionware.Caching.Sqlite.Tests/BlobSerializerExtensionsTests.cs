using System;
using NUnit.Framework;
using Invisionware.Caching;
using Invisionware.Serialization;
using System.Linq;
using Invisionware.Caching.SQLite;

namespace Invisionware.Caching
{
	[TestFixture]
	public class BlobSerializerExtensionsTests
	{
		public class ByteSerializerInternal : IByteSerializer
		{
			#region IByteSerializer implementation
			public byte[] SerializeToBytes<T> (T obj)
			{
				byte[] myBytes = { 0x00, 0xff };
				return myBytes;
			}
			public T Deserialize<T> (byte[] data) 
			{
				return default(T);
			}
			public object Deserialize (byte[] data, Type type)
			{
				return "The Quick Brown Fox";
			}
			#endregion
		}
		public class DataClassInternal
		{
			public string Name{ get; set; }
		}
		[Test]
		public void BlobSerializerExtensionsAsBlobSerializerTest()
		{
			var blobDelegate = BlobSerializerExtensions.AsBlobSerializer (new ByteSerializerInternal());

			Assert.IsTrue (blobDelegate.CanDeserialize(typeof(string)));
			byte[] myBytes = { 0xaa, 0xbb };
			Assert.AreEqual ((new ByteSerializerInternal()).SerializeToBytes(myBytes), blobDelegate.Serialize<string>("nothing"));
			Assert.AreEqual ((new ByteSerializerInternal()).Deserialize(myBytes,typeof(string)), blobDelegate.Deserialize(myBytes,typeof(string)));
		}
	}
}

