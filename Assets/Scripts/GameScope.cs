using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameScope : LifetimeScope
{
    [SerializeField] private KnifeManager knifeManager;
    [SerializeField] private SkinManager skinManager;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<GameManager>().AsSelf();
        builder.RegisterEntryPoint<Wallet>().AsSelf();
        builder.RegisterComponent(knifeManager);
        builder.RegisterComponent(skinManager);
    }
}