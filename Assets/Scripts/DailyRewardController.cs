using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardController:BaseController
{
    private readonly DailyRewardView _rewardView;
    private readonly ProfilePlayer _profile;
    private List<SlotRewardView> _slots;

    private bool _rewardReceived = false;

    public DailyRewardController(DailyRewardView rewardView, CurrencyWindow currencyWindow, ProfilePlayer profile)
    {
        _rewardView = rewardView;
        _profile = profile;
        currencyWindow.Init(profile.RewardData.Diamond, profile.RewardData.Wood);
        InitSlots();
        RefreshUi();
        _rewardView.StartCoroutine(UpdateCoroutine());
        SubscribeButtons();
    }

    private IEnumerator UpdateCoroutine()
    {
        while (true)
        {
            Update();
            yield return new WaitForSeconds(1);
        }
    }

    private void Update()
    {
        RefreshRewardState();
        RefreshUi();
    }

    private void RefreshRewardState()
    {
        _rewardReceived = false;
        if (_profile.RewardData.LastRewardTime.Value.HasValue)
        {
            var timeSpan = DateTime.UtcNow - _profile.RewardData.LastRewardTime.Value.Value;
            if (timeSpan.Seconds > _rewardView.TimeDeadline)
            {
                _profile.RewardData.LastRewardTime.Value = null;
                _profile.RewardData.CurrentActiveSlot.Value = 0;
            }
            else if(timeSpan.Seconds < _rewardView.TimeCooldown)
            {
                _rewardReceived = true;
            }
        }
    }

    private void RefreshUi()
    {
        _rewardView.GetRewardButton.interactable = !_rewardReceived;

        for (var i = 0; i < _rewardView.Rewards.Count; i++)
        {
            _slots[i].SetData(_rewardView.Rewards[i], i+1, i <= _profile.RewardData.CurrentActiveSlot.Value);
        }

        DateTime nextDailyBonusTime =
            !_profile.RewardData.LastRewardTime.Value.HasValue
                ? DateTime.MinValue
                : _profile.RewardData.LastRewardTime.Value.Value.AddSeconds(_rewardView.TimeCooldown);
        var delta = nextDailyBonusTime - DateTime.UtcNow;
        if (delta.TotalSeconds < 0)
            delta = new TimeSpan(0);

        _rewardView.RewardTimer.text = delta.ToString();
    }

    private void InitSlots()
    {
        _slots = new List<SlotRewardView>();
        for (int i = 0; i < _rewardView.Rewards.Count; i++)
        {
            var reward = _rewardView.Rewards[i];
            var slotInstance = GameObject.Instantiate(_rewardView.SlotPrefab, _rewardView.SlotsParent, false);
            slotInstance.SetData(reward, i+1, false);
            _slots.Add(slotInstance);
        }
    }

    private void SubscribeButtons()
    {
        _rewardView.GetRewardButton.onClick.AddListener(ClaimReward);
        _rewardView.ResetButton.onClick.AddListener(ResetReward);
    }

    private void ResetReward()
    {
        _profile.RewardData.LastRewardTime.Value = null;
        _profile.RewardData.CurrentActiveSlot.Value = 0;
    }

    private void ClaimReward()
    {
        if (_rewardReceived)
            return;
        var reward = _rewardView.Rewards[_profile.RewardData.CurrentActiveSlot.Value];
        switch (reward.Type)
        {
            case RewardType.None:
                break;
            case RewardType.Wood:
                _profile.RewardData.Wood.Value += reward.Count;
                break;
            case RewardType.Diamond:
                _profile.RewardData.Diamond.Value += reward.Count;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        _profile.RewardData.LastRewardTime.Value = DateTime.UtcNow;
        _profile.RewardData.CurrentActiveSlot.Value = (_profile.RewardData.CurrentActiveSlot.Value + 1) % _rewardView.Rewards.Count;
        RefreshRewardState();
    }
}
