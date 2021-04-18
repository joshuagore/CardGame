using System;

namespace MyrddinsOwl.Mvc.Interfaces
{
    public interface IView
    {
        event Action Destroyed;
    }

    public interface IView<in TModel> : IView where TModel : IModel
    {
        void BindModel(TModel model);
    }
}