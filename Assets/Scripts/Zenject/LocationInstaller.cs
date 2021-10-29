﻿using Zenject;
using UnityEngine;

public class LocationInstaller : MonoInstaller, IInitializable
{
    public Transform startPoint;
    public GameObject playerPrefab;
    public Transform[] targetsNpc;
    public PenaltyControl penaltyControl;
    public NpcMarker[] npcMarkers;
    public AutomatShop automatShop;
    public IceSceneMoving iceInScene;
    public BellControl bellControl;
    public TrapControl trapControl;
    public EvacuationButton evacuationButton;
    public TapeRecorderControl tapeRecorder;

    public override void InstallBindings()
    {
        BindInstallerInterfaces();
        BindPlayer();
        BindTargetsNpc();
        BindPenaltyController();
        BindAutomatShop();
        BindIcePlayer();
        BindBellLearning();
        BindTrap();
        BindButtonEvacuation();
        BindTapeRecorder();

        BindNpFactory();
    }

    private void BindInstallerInterfaces()
    {
        Container.
            BindInterfacesTo<LocationInstaller>().
            FromInstance(this).
            AsSingle();
    }

    private void BindPlayer()
    {
        PlayerController playerController = Container.
                    InstantiatePrefabForComponent<PlayerController>(playerPrefab,
                    startPoint.position, Quaternion.identity, null);

        Container.
            Bind<PlayerController>().
            FromInstance(playerController).
            AsSingle();
    }

    private void BindTargetsNpc()
    {
        Container.
            Bind<Transform[]>().
            FromInstance(targetsNpc).
            AsSingle();
    }

    private void BindPenaltyController()
    {
        Container.
            Bind<PenaltyControl>().
            FromInstance(penaltyControl).
            AsSingle();
    }

    private void BindAutomatShop()
    {
        Container.
            Bind<AutomatShop>().
            FromInstance(automatShop).
            AsSingle();
    }

    private void BindIcePlayer()
    {
        Container.
            Bind<IceSceneMoving>().
            FromInstance(iceInScene).
            AsSingle();
    }

    private void BindBellLearning()
    {
        Container.
            Bind<BellControl>().
            FromInstance(bellControl).
            AsSingle();
    }

    private void BindTrap()
    {
        Container.
            Bind<TrapControl>().
            FromInstance(trapControl).
            AsSingle();
    }

    private void BindButtonEvacuation()
    {
        Container.
            Bind<EvacuationButton>().
            FromInstance(evacuationButton).
            AsSingle();
    }

    private void BindTapeRecorder()
    {
        Container.
            Bind<TapeRecorderControl>().
            FromInstance(tapeRecorder).
            AsSingle();
    }

    private void BindNpFactory()
    {
        Container.
            Bind<INpcFactory>().
            To<NpcFactory>().
            AsSingle();
    }

    public void Initialize()
    {
        var npcFactory = Container.Resolve<INpcFactory>();
        npcFactory.Load();

        foreach (NpcMarker marker in npcMarkers)
            npcFactory.Create(marker.typeAI, marker.transform.position);
    }    
}
