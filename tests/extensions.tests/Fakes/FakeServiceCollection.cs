using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Collections.Generic;

namespace Extensions.Tests.Fakes
{
	public class FakeServiceCollection : IServiceCollection
	{
		#region Fields

		private readonly IList<ServiceDescriptor> _serviceDescriptors;

		#endregion

		#region Consturctors

		public FakeServiceCollection()
		{
			_serviceDescriptors = new List<ServiceDescriptor>();
		}

		#endregion

		#region Indexers

		public ServiceDescriptor this[int index]
		{
			get => _serviceDescriptors[index];
			set => _serviceDescriptors[index] = value;
		}

		#endregion

		#region Properties

		public int Count => _serviceDescriptors.Count;

		public bool IsReadOnly => _serviceDescriptors.IsReadOnly;

		#endregion

		#region Public methods

		public void Add(ServiceDescriptor item) => _serviceDescriptors.Add(item);

		public void Clear() => _serviceDescriptors.Clear();

		public bool Contains(ServiceDescriptor item) => _serviceDescriptors.Contains(item);

		public void CopyTo(ServiceDescriptor[] array, int arrayIndex) => _serviceDescriptors.CopyTo(array, arrayIndex);

		public IEnumerator<ServiceDescriptor> GetEnumerator() => _serviceDescriptors.GetEnumerator();

		public int IndexOf(ServiceDescriptor item) => _serviceDescriptors.IndexOf(item);

		public void Insert(int index, ServiceDescriptor item) => _serviceDescriptors.Insert(index, item);

		public bool Remove(ServiceDescriptor item) => _serviceDescriptors.Remove(item);

		public void RemoveAt(int index) => _serviceDescriptors.RemoveAt(index);

		IEnumerator IEnumerable.GetEnumerator() => _serviceDescriptors.GetEnumerator();

		#endregion
	}
}
