using CarInput;
using Profile;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MainMenuController : BaseController
{
    private readonly ResourcePath _carviewPath = new ResourcePath { PathResource = "Prefabs/CarViewInfo" };
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/mainMenu" };

    private readonly ResourcePath _tileRenderPath = new ResourcePath { PathResource = "Prefabs/tileRender" };

    private readonly ProfilePlayer _profilePlayer;
    private readonly IAdsShower _adsShower;
    private MainMenuView _view;
    private CarInfoView _carview;

    private readonly TileRenderView _tileView;

    private List<AsyncOperationHandle<GameObject>> _addressablePrefabs = new
List<AsyncOperationHandle<GameObject>>();


    public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer, IAdsShower adsShower, AssetReference loadPrefab)
    {
        _profilePlayer = profilePlayer;
        _adsShower = adsShower;
        LoadView(loadPrefab, placeForUi);
        _tileView = LoadTileRender(placeForUi);
        _tileView.Init(StartGame);

        _carview = LoadView(placeForUi);
        _carview.Init(profilePlayer);
   

    }

    //private void ShowRewards()
    //{
    //    throw new System.NotImplementedException();
    //}

    private TileRenderView LoadTileRender(Transform placeForUi)
    {
        var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_tileRenderPath), placeForUi, false);
        AddGameObjects(objectView);
        return objectView.GetComponent<TileRenderView>();
    }
    private CarInfoView LoadView(Transform placeForUi)
    {
        var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_carviewPath), placeForUi, false);
        AddGameObjects(objectView);
        return objectView.GetComponent<CarInfoView>();
    }

    private async void LoadView(AssetReference loadPrefab, Transform placeForUi)
    {
        var addressablePrefab = await Addressables.InstantiateAsync(loadPrefab, placeForUi).Task;
        if (addressablePrefab != null)
        {

            _view = addressablePrefab.gameObject.GetComponent<MainMenuView>();
            AddGameObjects(addressablePrefab.gameObject);
            _view.Init(StartGame, StartBattle, GoToTheShed, DailyRewardGame);

        }
    }
    private void StartGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
     //   _profilePlayer.CurrenMoney.Value = _profilePlayer.PlayerMoney.Money;
        _adsShower.ShowInterstitial();
        _profilePlayer.AnalyticTools.SendMessage("start_game");
    }
    private void StartBattle()
    {
        _profilePlayer.CurrentState.Value = GameState.Fight;
        _adsShower.ShowInterstitial();
        _profilePlayer.AnalyticTools.SendMessage("start_game");
    }
    private void DailyRewardGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Rewards;
    }

    private void GoToTheShed()
    {
        _profilePlayer.CurrentState.Value = GameState.Shed;
    }

    protected override void OnChildDispose()
    {
        foreach (var addressablePrefab in _addressablePrefabs)
            Addressables.ReleaseInstance(addressablePrefab);
        _addressablePrefabs.Clear();
        base.OnChildDispose();
    }
}

