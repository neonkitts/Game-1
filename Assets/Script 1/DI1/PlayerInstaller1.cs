using System;
using System.ComponentModel;
using Script_1.Player1;
using UnityEngine;
using Zenject;

namespace Script_1.DI1
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private  PlayerMovement _playerMovement;
    
                public override void InstallBindings()
               {
                 Container.Bind<PlayerMovement>().FromInstance(_playerMovement).AsSingle().NonLaz();
               }
    }
}