using Profile.Analytic;
using Profile;
using UnityEngine;
using Tools;
using System.Collections.Generic;

public class Root : MonoBehaviour
{
    [SerializeField] 
    private Transform _placeForUi;
    [SerializeField]
    private UnityAdsTools _unityAdsTool;
    private MainController _mainController;
   [SerializeField] private  List<UpgradeItemConfig> _upgradeItemConfigs;
   [SerializeField] private List<AbilityItemConfig> _abilityItemConfigs;
    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(3f, new  UnityAnalyticTools());
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _unityAdsTool, _upgradeItemConfigs,_abilityItemConfigs);
    }
    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
