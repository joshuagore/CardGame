using System;
using MyrddinsOwl.Mvc.Interfaces;

namespace MyrddinsOwl.Core
{
    public abstract class Controller<T> : IController<T> where T : View
    {
        protected T View { get; private set; }
        public void BindView(T view)
        {            
            View = view;
        }
        
        public void Init()
        {
            View.Init();
            View.Destroyed += OnViewDestroyed;
            OnReady();
        }

        protected virtual void OnReady()
        {
            
        }

        protected virtual void OnViewDestroyed()
        {
            Dispose();
        }

        #region Dispose
        // To detect redundant calls
        private bool _disposed = false;

        ~Controller() => Dispose(false);

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
    
    public abstract class Controller<TView, TModel> : Controller<TView>, IController<TView, TModel> where TView : View<TModel> where TModel : IModel
    {
        protected TModel Model { get; private set; }
        public void BindModel(TModel model)
        {            
            Model = model;
            View.BindModel(model);
        }
        
        #region Dispose
        // To detect redundant calls
        private bool _disposed = false;

        ~Controller() => Dispose(false);

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