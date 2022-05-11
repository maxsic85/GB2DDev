using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class TaskingRewardView :MonoBehaviour, IRewardView
{
    private const string CurrentSlotInActiveKey = nameof(CurrentSlotInActiveKey);
    [Header("Settings Rewards")]
    [SerializeField]
    private List<Reward> _rewards;

    [SerializeField]
    private Transform _mountRootSlotsReward;
    [SerializeField]
    private ContainerSlotRewardView _containerSlotRewardView;
    [SerializeField]
    private Button _getRewardButton;
    [SerializeField]
    private Toggle _isReady;



    public List<Reward> Rewards => _rewards;

    public Transform MountRootSlotsReward => _mountRootSlotsReward;

    public ContainerSlotRewardView ContainerSlotRewardView => _containerSlotRewardView;

    public Button GetRewardButton => _getRewardButton;

    public Toggle IsReady { get => _isReady; set => _isReady = value; }
    public int CurrentSlotInActive
    {
        get => PlayerPrefs.GetInt(CurrentSlotInActiveKey, 0);
        set => PlayerPrefs.SetInt(CurrentSlotInActiveKey, value);
    }

    private void OnDestroy()
    {
        _getRewardButton.onClick.RemoveAllListeners();
    }
}