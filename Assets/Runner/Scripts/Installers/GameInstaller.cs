using System;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;
using Zenject.SpaceFighter;

// Main installer
public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
        InstallPlayerStates();
    }

    void InstallPlayerStates()
    {
        Container.Bind<PlayerStateFactory>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerEffectHandler>().AsSingle();

        // PlayerObject is bound by zenject component
        // setting up player state machine factory
        Container.BindFactory<PlayerFlyingState, PlayerFlyingState.Factory>().WhenInjectedInto<PlayerStateFactory>();
        Container.BindFactory<PlayerDeadState, PlayerDeadState.Factory>().WhenInjectedInto<PlayerStateFactory>();
        Container.BindFactory<PlayerRunningState, PlayerRunningState.Factory>().WhenInjectedInto<PlayerStateFactory>();

        // setting up Spawner factory
        Container.Bind<SpawnerFactory>().AsSingle();
        Container.BindFactory<ObstacleSpawner, ObstacleSpawner.Factory>().WhenInjectedInto<SpawnerFactory>();
        Container.BindFactory<CollectableSpawner, CollectableSpawner.Factory>().WhenInjectedInto<SpawnerFactory>();
    }
}
