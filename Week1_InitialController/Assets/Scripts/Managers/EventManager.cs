using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC
{
    public abstract class GameEvent
    {
        public delegate void Handler(GameEvent e);
    }
    public class EventManager
    {
        private readonly Dictionary<System.Type, GameEvent.Handler> _eventTypeToHandlersMap = new Dictionary<System.Type, GameEvent.Handler>();

        public void Register<EventType>(GameEvent.Handler handler) where EventType : GameEvent
        {
            System.Type t = typeof(EventType);
            if (_eventTypeToHandlersMap.ContainsKey(t)) _eventTypeToHandlersMap[t] += handler;
            else _eventTypeToHandlersMap[t] = handler;
        }

        public void Unregister<EventType>(GameEvent.Handler handler) where EventType : GameEvent
        {
            System.Type type = typeof(GameEvent);
            GameEvent.Handler handlers;
            if(_eventTypeToHandlersMap.TryGetValue(type, out handlers))
            {
                handlers -= handler;
                if (handlers == null) _eventTypeToHandlersMap.Remove(type);
                else _eventTypeToHandlersMap[type] = handlers;
            }
        }

        public void Fire(GameEvent e)
        {
            //get the list of handlers for eventType 
            System.Type type = e.GetType();
            GameEvent.Handler handlers;
            //call each one with the event
            if (_eventTypeToHandlersMap.TryGetValue(type, out handlers)) handlers(e);
        }
    }
}

