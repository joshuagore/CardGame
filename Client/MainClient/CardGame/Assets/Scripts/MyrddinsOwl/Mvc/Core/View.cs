using System;
using MyrddinsOwl.Mvc.Interfaces;

namespace MyrddinsOwl.Core
{
    public abstract class View : ValidatedMonoBehaviour, IView
    {
        public event Action Destroyed;

        public void Init()
        {
            OnReady();
        }

        protected virtual void OnReady()
        {
        }

        private void OnDestroy()
        {
            Destroyed?.Invoke();
            Dispose();
        }
        
        #region Dispose
        // To detect redundant calls
        private bool _disposed = false;

        ~View() => Dispose(false);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // dispose managed state (managed objects).
            }

            // free unmanaged resources (unmanaged objects) and override a finalizer below.
            // set large fields to null.

            _disposed = true;
        }
        #endregion
    }
    
    public abstract class View<TModel> : View, IView<TModel> where TModel : IModel
    {
        protected TModel Model { get; private set; }
        public void BindModel(TModel model)
        {
            Model = model;
        }

        protected override void OnReady()
        {
            
        }
        
        #region Dispose
        // To detect redundant calls
        private bool _disposed = false;

        ~View() => Dispose(false);

        // Protected implementation of Dispose pattern.
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // dispose managed state (managed objects).
                Model = default(TModel);
            }

            // free unmanaged resources (unmanaged objects) and override a finalizer below.
            // set large fields to null.
            _disposed = true;

            // Call the base class implementation.
            base.Dispose(disposing);
        }
        #endregion
    }
}