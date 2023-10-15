using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputHandler>().FromComponentInHierarchy().AsSingle();
        Container.Bind<FrameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CollisionHandler>().FromComponentInHierarchy().AsSingle();
    }
}