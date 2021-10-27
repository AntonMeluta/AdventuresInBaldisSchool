using Zenject;
using UnityEngine;

public class BootstrapInstaller : MonoInstaller
{
    public GameObject gameManagerPrefab;
    public GameObject uiControllerPrefab;
    public GameObject audioControllerPrefab;

    public override void InstallBindings()
    {
        BindAudioController();
        BindGameManger();        
        BindUiController();
    }

    private void BindGameManger()
    {
        GameManager gameManager = Container.
                    InstantiatePrefabForComponent<GameManager>(gameManagerPrefab);

        Container.
            Bind<GameManager>().
            FromInstance(gameManager).
            AsSingle();
    }

    private void BindUiController()
    {
        UIManager uiManager = Container.
                    InstantiatePrefabForComponent<UIManager>(uiControllerPrefab);

        Container.
            Bind<UIManager>().
            FromInstance(uiManager).
            AsSingle();
    }

    private void BindAudioController()
    {
        AudioController audioController = Container.
                    InstantiatePrefabForComponent<AudioController>(audioControllerPrefab);

        Container.
            Bind<AudioController>().
            FromInstance(audioController).
            AsSingle();
    }

}
