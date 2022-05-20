using Profile.Analytic;
using Profile;
using UnityEngine;
using Tools;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Root : MonoBehaviour
{
    [SerializeField]
    private Transform _placeForUi;
    [SerializeField]
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
    [SerializeField] private List<UpgradeItemConfig> _upgradeItemConfigs;
    [SerializeField] private List<AbilityItemConfig> _abilityItemConfigs;

    [SerializeField]
    private AssetReference _loadPrefab;
  
    public ProfilePlayer ProfilePlayer  => _profilePlayer;
    private void Awake()
    {
        _profilePlayer = new ProfilePlayer(3f, new UnityAnalyticTools());
        _profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, _profilePlayer, _unityAdsTool, _upgradeItemConfigs, _abilityItemConfigs,
                                             _dailyRewardView, _currencyView, _fightWindowView, _startFightView, _loadPrefab);
    }
    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
