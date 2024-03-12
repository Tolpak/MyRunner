using System;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

// Main installer
public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ObstacleSpawner>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
        InstallPlayerStates();
    }

    void InstallPlayerStates()
    {
        Container.Bind<PlayerStateFactory>().AsSingle();

        // PlayerObject is bound by zenject component

        Container.BindFactory<PlayerFlyingState, PlayerFlyingState.Factory>().WhenInjectedInto<PlayerStateFactory>();
        Container.BindFactory<PlayerDeadState, PlayerDeadState.Factory>().WhenInjectedInto<PlayerStateFactory>();
        Container.BindFactory<PlayerRunningState, PlayerRunningState.Factory>().WhenInjectedInto<PlayerStateFactory>();
    }
}
