using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Infrastructure.TimerService
{
    public class TimerService : ITimerService, ITickable
    {
        private readonly Dictionary<string, (float, ITimerHandler)> _timers = new();
        private readonly List<string> _idsToRemove = new();
        private readonly List<ITimerHandler> _handlersToTrigger = new();
        public string SetupTimer(float time, ITimerHandler handler)
        {
            string id = Guid.NewGuid().ToString();
            _timers.Add(id, (Time.time + time, handler));
            return id;
        }

        public void Remove(string timerId)
        {
            _timers.Remove(timerId);
        }

        public void Tick()
        {
            foreach (var (id, (time, handler)) in _timers)
            {
                if (Time.time > time)
                {
                    _handlersToTrigger.Add(handler);
                    _idsToRemove.Add(id);
                }
            }

            ClearTimers();
            TriggerHandlers();
        }

        private void TriggerHandlers()
        {
            foreach (var handler in _handlersToTrigger)
            {
                handler.HandleTimer();
            }

            _handlersToTrigger.Clear();
        }

        private void ClearTimers()
        {
            foreach (var removeIndex in _idsToRemove)
            {
                _timers.Remove(removeIndex);
            }

            _idsToRemove.Clear();
        }
    }
}