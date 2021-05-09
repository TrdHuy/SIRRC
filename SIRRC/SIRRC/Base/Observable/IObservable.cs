using System;
using System.Collections.Generic;
using System.Text;

namespace SIRRC.Base.Observable
{
    public interface IObservable<T>
    {
        void Subcribe(IObserver<T> observer);

        void Unsubcribe(IObserver<T> observer);

        void NotifyChange(T result);
    }
}
