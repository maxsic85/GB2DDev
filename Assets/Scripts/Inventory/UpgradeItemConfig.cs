
using UnityEngine;
[CreateAssetMenu(fileName = "UpdrateItem", menuName = "ItemMenu/ConfigItem", order = 1)]
public class UpgradeItemConfig : ScriptableObject
{
    public ItemConfig itemConfig;
    private UpgradeType type;
    public float value;
    public int price;

    public int Id => itemConfig.id;

    public UpgradeType UpgrtType => type;
}