using System;

namespace MyrddinsOwl.Mvc.Interfaces
{
    public interface IController<T> : IDisposable  where T : IView
    {
        void BindView(T view);
        public T View { get; set; }
    }
}