using Profile;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.AddressableAssets;

public sealed class MainController : BaseController
{
    private MainMenuController _mainMenuController;
    private ShedController _shedController;
    private GameController _gameController;
    private InventoryModel _inventoryModel;
    private DailyRewardController _dailyRewardController;
    private FightWindowController _fightWindowController;
    private CurrencyController _currencyController;
    private StartFightController _startFightController;

    private DailyRewardView _dailyRewardView;
    private CurrencyView _currencyView;
    private FightWindowView _fightWindowView;
    private StartFightView _startFightView;

    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private readonly IAdsShower _adsShower;
    private readonly List<UpgradeItemConfig> _upgradeItemConfigs;
    private readonly List<AbilityItemConfig> _abilityItemConfigs;
    private readonly AssetReference _loadPrefabmainMenuView;
    public MainController(Transform placeForUi,
                        ProfilePlayer profilePlayer,
                        IAdsShower adsShower,
                        List<UpgradeItemConfig> upgradeItemConfigs,
                        List<AbilityItemConfig> abilityItemConfigs,
                        DailyRewardView dailyRewardView,
                        CurrencyView currencyView,
                        FightWindowView fightWindowView,
                        StartFightView startFightView,
                        AssetReference loadPrefabmainMenuView
                        )
    {
        _loadPrefabmainMenuView = loadPrefabmainMenuView;
        _profilePlayer = profilePlayer;
        _upgradeItemConfigs = upgradeItemConfigs;
        _abilityItemConfigs = abilityItemConfigs;
        _adsShower = adsShower;
        _placeForUi = placeForUi;
        _dailyRewardView = dailyRewardView;
        _currencyView = currencyView;
        _fightWindowView = fightWindowView;
        _startFightView = startFightView;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        _inventoryModel = new InventoryModel();
        if (_shedController == null)
            _shedController = new ShedController(_upgradeItemConfigs, _profilePlayer.CurrentCar, _placeForUi, _inventoryModel);
        AddController(_shedController);
    }
    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer, _adsShower,_loadPrefabmainMenuView);              
                _gameController?.Dispose();
                break;
            case GameState.Game:
                var abilityRepository = new AbilityRepository(_abilityItemConfigs);
                var objView = Object.Instantiate(ResourceLoader.LoadPrefab(new ResourcePath() { PathResource = "Prefabs/AbilityView" }), _placeForUi).GetComponent<IAbilityCollectionView>();
                var carController = new CarController();
                AddController(carController);
                var abilityController = new AbilitiesController(carController, _inventoryModel, abilityRepository, objView,_shedController._upgradeItemsRepository);
                abilityController.ShowAbilities();
                AddController(abilityController);
                _gameController = new GameController(_profilePlayer,_abilityItemConfigs, _inventoryModel,_placeForUi);
                _mainMenuController?.Dispose();
                _shedController?.Dispose();
                break;
            case GameState.Shed:
                 _shedController.EnterToShed();
                break;
            case GameState.Rewards:
                _dailyRewardController = new DailyRewardController(_dailyRewardView, _placeForUi, _currencyView);
                _dailyRewardController.RefreshView();
                break;
            case GameState.Fight:
                _fightWindowController = new FightWindowController(_placeForUi, _fightWindowView, _profilePlayer);
                _fightWindowController.RefreshView();
                _startFightController?.Dispose();
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;
            default:
                DisposeAllControllers();
                break;
        }
    }

    private void DisposeAllControllers()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _fightWindowController?.Dispose();
        _dailyRewardController?.Dispose();
        _startFightController?.Dispose();

    }

    protected override void OnChildDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        base.OnChildDispose();
    }
}
