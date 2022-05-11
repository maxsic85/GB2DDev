using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IRewardView
{
    public List<Reward> Rewards { get; }
    public Transform MountRootSlotsReward { get; }
    public ContainerSlotRewardView ContainerSlotRewardView { get; }
    public int CurrentSlotInActive { get; set; }

}