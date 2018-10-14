using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core.Middlewares.TenantCatching
{
    public class TenantCatchingList : IList<ITenantCatchingStrategy>
    {
        #region Fields

        private readonly List<ITenantCatchingStrategy> _internalList;

        #endregion

        #region Constructor

        public TenantCatchingList()
        {
            _internalList = new List<ITenantCatchingStrategy>();
        }

        public TenantCatchingList(params ITenantCatchingStrategy[] tenantCatchingStrategies)
        {
            _internalList = tenantCatchingStrategies.ToList();
        }

        public TenantCatchingList(IEnumerable<ITenantCatchingStrategy> enumerable)
        {
            _internalList = enumerable.ToList();
        }

        #endregion

        #region Properties

        public ITenantCatchingStrategy this[int index]
        {
            get => _internalList[index];
            set => _internalList[index] = value;
        }

        public int Count => _internalList.Count;

        public bool IsReadOnly => false;

        #endregion
        
        #region Public methods

        public Guid? GetTenantId(HttpContext context)
        {
            foreach (var catchingStrategy in _internalList)
            {
                var id = catchingStrategy.GetTenantId(context);
                if (id.HasValue)
                {
                    return id;
                }
            }

            return null;
        }

        #endregion

        #region IList implementation

        public void Add(ITenantCatchingStrategy item) => _internalList.Add(item);
        public void Clear() => _internalList.Clear();
        public bool Contains(ITenantCatchingStrategy item) => _internalList.Contains(item);
        public void CopyTo(ITenantCatchingStrategy[] array, int arrayIndex) => _internalList.CopyTo(array, arrayIndex);
        public IEnumerator<ITenantCatchingStrategy> GetEnumerator() => _internalList.GetEnumerator();
        public int IndexOf(ITenantCatchingStrategy item) => _internalList.IndexOf(item);
        public void Insert(int index, ITenantCatchingStrategy item) => _internalList.Insert(index, item);
        public bool Remove(ITenantCatchingStrategy item) => _internalList.Remove(item);
        public void RemoveAt(int index) => _internalList.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => _internalList.GetEnumerator();

        #endregion
    }
}
