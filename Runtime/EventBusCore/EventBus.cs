using System;
using System.Collections.Generic;

namespace EventBusCore
{
    public interface IEvent { }    

    public interface IEventBus
    {
        void Publish<T>(T evt) where T : IEvent;
        void Subscribe<T>(Action<T> handler) where T : IEvent;
        void Unsubscribe<T>(Action<T> handler) where T : IEvent;
    }

    public sealed class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Delegate>> _handlers = new();

        public void Publish<T>(T evt) where T : IEvent
        {
            if (_handlers.TryGetValue(typeof(T), out var list))
            {
                var snapshot = list.ToArray(); // evita modifica��o durante itera��o
                foreach (var d in snapshot) (d as Action<T>)?.Invoke(evt);
            }
        }

        public void Subscribe<T>(Action<T> handler) where T : IEvent
        {
            var t = typeof(T);
            if (!_handlers.TryGetValue(t, out var list))
                _handlers[t] = list = new List<Delegate>();
            if (!list.Contains(handler)) list.Add(handler);
        }

        public void Unsubscribe<T>(Action<T> handler) where T : IEvent
        {
            if (_handlers.TryGetValue(typeof(T), out var list)) list.Remove(handler);
        }
    }
}
