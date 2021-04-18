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

        public TController CreateController<TController, TView>(TView view) where TView : IView where TController : IController<TView>
        {
            var controller = _container.Resolve<TController>();
            controller.BindView(view);
            return controller;
        }
    }
}