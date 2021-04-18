using System;
using MyrddinsOwl.Mvc.Interfaces;

namespace MyrddinsOwl.Core
{
    public abstract class View : ValidatedMonoBehaviour, IView
    {
        public event Action Destroyed;
        
        private void OnDestroy()
        {
            Destroyed?.Invoke();
        }
    }
}