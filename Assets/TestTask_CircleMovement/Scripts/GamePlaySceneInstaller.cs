using Assets.TestTask_CircleMovement.Scripts;
using UnityEngine;
using Zenject;

public class GamePlaySceneInstaller : MonoInstaller
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private GameObject _circlePrefab;
    [SerializeField] private GameObject _uIPrefab;

    private const string CIRCLESETTINGS = "CircleSettings";
    private const int TARGETFPS = 120;

    public override void InstallBindings()
    {
        Application.targetFrameRate = TARGETFPS;

        BindPlayer();
        BindInput();
        BindUI();
    }

    private void BindPlayer()
    {
        Container.Bind<CircleController>().FromComponentInNewPrefab(_circlePrefab).AsSingle().NonLazy();
        CircleSettings circleSettings = Resources.Load<CircleSettings>(CIRCLESETTINGS);
        Container.Bind<CircleSettings>().FromScriptableObject(circleSettings).AsSingle();
    }

    private void BindUI()
    {
        Container.Bind<SliderController>().FromComponentInNewPrefab(_uIPrefab).AsSingle().NonLazy();
        Container.Bind<DisplayUIValues>().FromComponentInParents(_uIPrefab).AsSingle();
    }

    private void BindInput()
    {
        Container.Bind<InputHandler>().FromInstance(_inputHandler).AsSingle();
    }
}