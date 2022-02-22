using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardView : MonoBehaviour, IView
{
    private const string LastTimeKey = "LastRewardTime";
    private const string ActiveSlotKey = "ActiveSlot";

    #region Fields
    [Header("Time settings")]
    [SerializeField]
    public int TimeCooldown = 86400;
    [SerializeField]
    public int TimeDeadline = 172800;
    [Space]
    [Header("RewardSettings")]
    public List<Reward> Rewards;
    [Header("UI")]
    [SerializeField]
    public TMP_Text RewardTimer;
    [SerializeField]
    public Transform SlotsParent;
    [SerializeField]
    public SlotRewardView SlotPrefab;
    [SerializeField]
    public Button ResetButton;
    [SerializeField]
    public Button GetRewardButton;
    [SerializeField]
    private Button CloseButton;
    #endregion

    private void OnDestroy()
    {
        GetRewardButton.onClick.RemoveAllListeners();
        ResetButton.onClick.RemoveAllListeners();
    }

    public void Show()
    {
        throw new NotImplementedException();
    }

    public void Hide()
    {
        throw new NotImplementedException();
    }
}
