using System;

namespace Game.Scripts.Infrastructure.Loading
{
    public interface ILoading: IDisposable
    {
        float Progress { get; set; }
    }
}