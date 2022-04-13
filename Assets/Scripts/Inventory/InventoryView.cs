using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class InventoryView : MonoBehaviour, IInventoryView
{
    public event EventHandler<IItem> Selected;
    public event EventHandler<IItem> Deselected;
    private List<IItem> _itemInfoCollection;
    private List<GameObject> _itemsObjectsView=new List<GameObject>();
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Item" };



    public void Display(List<IItem> items)
    {
        _itemInfoCollection = items;
        foreach (var item in _itemInfoCollection)
        {
            _itemsObjectsView.Add(GameObject.Instantiate(ResourceLoader.LoadPrefab(_viewPath), transform, false));
            _itemsObjectsView.LastOrDefault().transform.GetChild(0).GetComponent<Text>().text = item.Info.Title;
            _itemsObjectsView.LastOrDefault().transform.GetChild(1).GetComponent<Image>().sprite = item.Info.Sprite;

            Debug.Log($"item {item}");
        }
    }

    protected virtual void OnSelected(IItem e)
    {
        Selected?.Invoke(this, e);
    }
    protected virtual void OnDeselected(IItem e)
    {
        Deselected?.Invoke(this, e);
    }
}