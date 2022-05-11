using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
internal class TaskingRewardController : RewardController
{
    private TaskingRewardView _taskingRewardView;

    public TaskingRewardController(TaskingRewardView taskingRewardView) : base(taskingRewardView)
    { 
    _taskingRewardView = taskingRewardView;
    }
    public override void RefreshView()
    {
        InitSlots();
        _taskingRewardView.StartCoroutine(RewardsStateUpdater());
        RefreshUi();
        SubscribeButtons();
    }
    public override void InitSlots()
    {
        _slots = new List<ContainerSlotRewardView>();
        for (var i = 0; i < _taskingRewardView.Rewards.Count; i++)
        {
            var instanceSlot = GameObject.Instantiate(_taskingRewardView.ContainerSlotRewardView,
            _taskingRewardView.MountRootSlotsReward, false);
            _slots.Add(instanceSlot);
        }
    }
    private IEnumerator RewardsStateUpdater()
    {
        while (true)
        {
            RefreshRewardsState();
            yield return new WaitForSeconds(1);
        }
    }
    public override void RefreshRewardsState()
    {
        _isGetReward = true;
        if (_taskingRewardView.IsReady.isOn)
        {     
                _isGetReward = true;
            _taskingRewardView.CurrentSlotInActive = 0;
        }
        else
        {
            _isGetReward = false;
        }
        RefreshUi();
    }
    public override void RefreshUi()
    {
        _taskingRewardView.GetRewardButton.interactable = _isGetReward;
        if (_isGetReward)
        {
            Debug.Log(" reward is ready");         
        }
        for (var i = 0; i < _slots.Count; i++)
            _slots[i].SetData(_taskingRewardView.Rewards[i], i + 1, i == _taskingRewardView.CurrentSlotInActive);

    }

    public override void SubscribeButtons()
    {
        _taskingRewardView.GetRewardButton.onClick.AddListener(ClaimReward);
    }
    public override void ClaimReward()
    {
        if (!_isGetReward)
            return;

        var reward = _taskingRewardView.Rewards[_taskingRewardView.CurrentSlotInActive];
        switch (reward.RewardType)
        {
            case RewardType.Wood:
                CurrencyView.Instance.AddWood(reward.CountCurrency);
                break;
            case RewardType.Diamond:
                CurrencyView.Instance.AddDiamonds(reward.CountCurrency);
                break;
        }
        _taskingRewardView.CurrentSlotInActive = (_taskingRewardView.CurrentSlotInActive + 1) %
        _taskingRewardView.Rewards.Count;
        _taskingRewardView.IsReady.isOn = false;
        _isGetReward = false;
        RefreshRewardsState();
    }
    private void ResetTimer()
    {
        PlayerPrefs.DeleteAll();
    }


}