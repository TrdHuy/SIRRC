using System;
using System.Collections.Generic;
using System.Text;

namespace SIRRC.Base.Observable
{
    public interface IObserver<in T>
    {
        void Update(T value);
    }
}
