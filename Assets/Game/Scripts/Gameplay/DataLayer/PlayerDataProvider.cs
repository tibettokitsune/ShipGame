using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.DataLayer
{
    public class PlayerDataProvider : IPlayerDataProvider, IInitializable, IDisposable
    {
        public ReactiveProperty<int> Coins { get; } = new();

        public void Initialize()
        {
            LoadData();
        }

        private void LoadData()
        {
            Coins.Value = PlayerPrefs.GetInt(SaveKeys.CoinsKey);
        }
        
        private void SaveData()
        {
            PlayerPrefs.SetInt(SaveKeys.CoinsKey, Coins.Value);
        }

        public void Dispose()
        {
            SaveData();
            Coins?.Dispose();
        }
    }

    public interface IPlayerDataProvider
    {
        ReactiveProperty<int> Coins { get; }
    }
    
    public static class SaveKeys{
        public static string CoinsKey => "Coins";
    }
}