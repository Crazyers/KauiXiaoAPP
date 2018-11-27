using System;
using System.Collections.Generic;
using System.Text;

namespace FastSchool.Interface
{
    public interface ICache
    {
        void Set<T>(object key, T value);
        T Get<T>(object key);
        void Remove(object key);
    }
}
