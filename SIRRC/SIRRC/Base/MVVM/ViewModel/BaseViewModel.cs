using SIRRC.Base.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIRRC.Base.MVVM.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged,  IDestroyable, Observable.IObservable<object>
    {
        private List<Observable.IObserver<object>> _observers = new List<Observable.IObserver<object>>();

        public BaseViewModel ParentsModel { get; set; }

        #region Ctor
        public BaseViewModel()
        {
            Init(null);
        }

        public BaseViewModel(BaseViewModel parentsModel)
        {
            Init(parentsModel);
        }

        private void Init(BaseViewModel parentsModel)
        {
            ParentsModel = parentsModel;
        }
        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChanged(object viewModel, string propertyName)
        {
            VerifyPropertyName(viewModel, propertyName);
            PropertyChanged?.Invoke(viewModel, new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(object viewModel, string propertyName)
        {
            if (TypeDescriptor.GetProperties(viewModel)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }
        #endregion

        #region Observable field
        public void Subcribe(Observable.IObserver<object> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Unsubcribe(Observable.IObserver<object> observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void NotifyChange(object result)
        {
            foreach (Observable.IObserver<object> observer in _observers)
            {
                observer.Update(result);
            }
        }

        #endregion

        #region Public methods
        public void Invalidate(string property)
        {
            OnChanged(this, property);
        }

        public void InvalidateOwn([CallerMemberName()] string name = null)
        {
            OnChanged(this, name);
        }

        #endregion


        public virtual void OnDestroy()
        {
        }

        public virtual void RefreshViewModel()
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this);

            foreach (PropertyDescriptor property in properties)
            {
                var attributes = property.Attributes;

                if (attributes[typeof(BindableAttribute)].Equals(BindableAttribute.Yes))
                {
                    Invalidate(property.Name);
                }
            }
        }
    }
}
