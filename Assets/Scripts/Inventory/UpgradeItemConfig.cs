
using UnityEngine;
[CreateAssetMenu(fileName ="UpdrateItem", menuName = "ItemMenu/ConfigItem", order =1)]
public class UpgradeItemConfig : ScriptableObject
{
    public ItemConfig itemConfig;
    public UpgradeType type;
    public float value;
    public int Id => itemConfig.id;
}
