using System;
namespace Application.Infrastructure
{
    // public interface IDomainEvents
    // {
    //     static void Raise<T>(T EventArgs);
    //     IDisposable Register<T>(Action<T> callback);
    // }

    public static class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> _actions = new List<Delegate>();
        private static List<Delegate> Actions
        {

            get
            {
                if (_actions == null)
                {
                    _actions = new List<Delegate>();
                }
                return _actions;
            }
        }

        public static IDisposable Register<T>(Action<T> callback)
        {
            if (callback == null)
            {
                throw new ArgumentNullException("callback");
            }

            Actions.Add(callback);
            return new DomainEventUnsubscriber<T>(Actions, callback);
        }

        public static void  Raise<T>(T EventArgs)
        {
            foreach (var typedAction in Actions.OfType<Action<T>>())
            {
                typedAction(EventArgs);
            }
        }

        private sealed class DomainEventUnsubscriber<T> : IDisposable
        {
            private List<Delegate> _actions;
            private Action<T> _callback;

            public DomainEventUnsubscriber(List<Delegate> actions, Action<T> callback)
            {
                _actions = actions;
                _callback = callback;
            }

            public void Dispose()
            {
                if (_actions.Contains(_callback))
                {
                    _actions.Remove(_callback);
                }
            }
        }

    }
}