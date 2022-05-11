using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class RewardController
{
    private IRewardView _rewardView;
    internal List<ContainerSlotRewardView> _slots;
    internal bool _isGetReward;
    public RewardController(IRewardView generateLevelView)
    {
        _rewardView = generateLevelView;
    }
    public virtual void RefreshView()
    {
        InitSlots();
        RefreshUi();
        SubscribeButtons();
    }
    public virtual void InitSlots()
    {
        _slots = new List<ContainerSlotRewardView>();
        for (var i = 0; i < _rewardView.Rewards.Count; i++)
        {
            var instanceSlot = GameObject.Instantiate(_rewardView.ContainerSlotRewardView,
            _rewardView.MountRootSlotsReward, false);
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
    public virtual void RefreshRewardsState()
    {
      
    }
    public virtual void RefreshUi()
    {
       
    }

    public virtual void SubscribeButtons()
    {
        
    }
    public virtual void ClaimReward()
    {
      
    }
      
}

