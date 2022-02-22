using System;
using Tools;

public class RewardData
{
    private const string WoodKey = "Wood";
    private const string DiamondKey = "Diamond";
    private const string ActiveSlotKey = "ActiveSlot";
    private const string LastTimeKey = "LastRewardTime";

    public RewardData()
    {
        Wood = new PrefsSubscriptionProperty<int>(WoodKey, int.Parse);
        Diamond = new PrefsSubscriptionProperty<int>(DiamondKey, int.Parse);
        CurrentActiveSlot = new PrefsSubscriptionProperty<int>(ActiveSlotKey, int.Parse);
        LastRewardTime = new PrefsSubscriptionProperty<DateTime?>(LastTimeKey, NullableDateTimeConverter());
    }

    public SubscriptionProperty<int> Wood;
    public SubscriptionProperty<int> Diamond;
    public SubscriptionProperty<int> CurrentActiveSlot;
    public SubscriptionProperty<DateTime?> LastRewardTime;

    private static Func<string, DateTime?> NullableDateTimeConverter()
    {
        return (v) =>
        {
            if (DateTime.TryParse(v, out var value))
                return value;
            return null;
        };
    }
}
