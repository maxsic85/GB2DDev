﻿using Profile;
using Profile.Analytic;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Root : MonoBehaviour
{
    [SerializeField]
    private Transform _placeForUi;

    private DailyRewardView _dailyRewardView;
    [SerializeField]
    private CurrencyView _currencyView;
    [SerializeField]
    private FightWindowView _fightWindowView;
    [SerializeField]
    private StartFightView _startFightView;
    [SerializeField]
    private UnityAdsTools _unityAdsTool;
    private MainController _mainController;
    private ProfilePlayer _profilePlayer;
    [SerializeField] private UpgradeItemConfigDataSource _upgradeItemConfigs;
    [SerializeField] private List<AbilityItemConfig> _abilityItemConfigs;

    [SerializeField]
    private AssetReference _loadMainMenuView;
    [SerializeField]
    private AssetReference _loadWindowFightView;
    [SerializeField]
    private AssetReference _loadDailyRewardView;
    [SerializeField]
    private AssetReference _loadCurrencyView;
    public ProfilePlayer ProfilePlayer => _profilePlayer;

  

    private  void Awake()
    {
            _profilePlayer = new ProfilePlayer(3f, new UnityAnalyticTools());
            _profilePlayer.CurrentState.Value = GameState.Start;
        _profilePlayer.CurrenMoney.Value = _profilePlayer.PlayerMoney.Money;
        _mainController = new MainController(_placeForUi, _profilePlayer, _unityAdsTool, _upgradeItemConfigs, _abilityItemConfigs,
                                                 _loadDailyRewardView, _loadCurrencyView, _loadWindowFightView, _startFightView, _loadMainMenuView);
       
    }


   

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
