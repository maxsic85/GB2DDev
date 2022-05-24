
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Item",menuName ="ItemMenu/item",order =0)]
public class ItemConfig : ScriptableObject
{
    public int id;
    public string title;
    public float value;
    public int price;

    public Sprite image;
}
