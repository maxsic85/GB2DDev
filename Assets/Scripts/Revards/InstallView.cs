using UnityEngine;

public class InstallView : MonoBehaviour
{
    [SerializeField]
    private DailyRewardView _dailyRewardView;
    [SerializeField]
    private TaskingRewardView _taskingRewardView;

    private RewardController _dailyRewardController;
    private RewardController _taskingRewardController;

    private void Awake()
    {
        _dailyRewardController = new DailyRewardController(_dailyRewardView);
        _taskingRewardController = new TaskingRewardController(_taskingRewardView);
    }
    private void Start()
    {
        _dailyRewardController.RefreshView();
        _taskingRewardController.RefreshView();
    }
}