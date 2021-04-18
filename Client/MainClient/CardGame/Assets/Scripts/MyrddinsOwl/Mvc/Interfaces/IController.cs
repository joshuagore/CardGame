using System;

namespace MyrddinsOwl.Mvc.Interfaces
{
    public interface IController<TView> : IDisposable  where TView : IView
    {
        void BindView(TView view);
        void Init();
        

    }
    
    public interface IController<TView, TModel> : IController<TView> where TView : IView<TModel> where TModel : IModel
    {
        void BindModel(TModel model);
    }
}