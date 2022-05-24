
using UnityEngine;
[CreateAssetMenu(fileName = "UpdrateItem", menuName = "ItemMenu/ConfigItem", order = 1)]
public class UpgradeItemConfig : ScriptableObject
{
    public ItemConfig itemConfig;
    private UpgradeType type;
    public float value;
    public int price;

    public int Id => itemConfig.id;
    public float Value => itemConfig.value;
    public int Price => itemConfig.price;

    public UpgradeType UpgrtType => type;
}