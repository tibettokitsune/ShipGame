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
        public void SetupTimer(float time, ITimerHandler handler)
        {
            _timers.Add(Guid.NewGuid().ToString(), (Time.time + time, handler));
        }

        public void Tick()
        {
            foreach (var (id, (time, handler)) in _timers)
            {
                if (Time.time > time)
                {
                    handler.HandleTimer();
                    _idsToRemove.Add(id);
                }
            }

            foreach (var removeIndex in _idsToRemove)
            {
                _timers.Remove(removeIndex);
            }
            
            _idsToRemove.Clear();
        }
    }
}