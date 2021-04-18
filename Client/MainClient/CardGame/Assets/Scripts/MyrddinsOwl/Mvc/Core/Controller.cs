using MyrddinsOwl.Mvc.Interfaces;

namespace MyrddinsOwl.Core
{
    public abstract class Controller<T> : IController<T> where T : View
    {
        public void BindView(T view)
        {            
            View = view;
            View.Destroyed += OnViewDestroyed;
            OnViewReady();
        }
        
        protected abstract void OnViewReady();
        protected abstract void OnViewDestroyed();
        
        public T View { get; set; }

        public abstract void Dispose();
    }
}