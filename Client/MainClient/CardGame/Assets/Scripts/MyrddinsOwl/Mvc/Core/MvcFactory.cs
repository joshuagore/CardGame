using MyrddinsOwl.Mvc.Interfaces;

namespace MyrddinsOwl.Core
{
    public class MvcFactory
    {
        private readonly IContainer _container;

        public MvcFactory(IContainer container)
        {
            _container = container;
        }

        public TController CreateController<TController, TView>(TView view) 
            where TView : IView 
            where TController : IController<TView>
        {
            var controller = _container.Resolve<TController>();
            controller.BindView(view);
            controller.Init();
            return controller;
        }
        
        public TController CreateController<TController, TView, TModel>(TView view, TModel model) 
            where TView : IView<TModel> 
            where TController : IController<TView, TModel> 
            where TModel : IModel
        {
            var controller = _container.Resolve<TController>();
            controller.BindView(view);
            controller.BindModel(model);
            controller.Init();
            return controller;
        }
    }
}