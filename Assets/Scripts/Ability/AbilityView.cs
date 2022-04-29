using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class AbilityView : MonoBehaviour,IAbilityCollectionView
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Transform _layout;
    [SerializeField] private AbilityItemView _itemView;
    private List<AbilityItemView> _abilityItemViews=new List<AbilityItemView>(4);

    public void Show()
    {
    
    }

    public void Hide()
    { 
    
    }

    public event EventHandler<IItem> UseRequested;

    public void Display(IReadOnlyList<IItem> abilityItems)
    {
        foreach (var abilka in abilityItems)
        {
            var view = Instantiate<AbilityItemView>(_itemView, _layout);
            view.Init(abilka);
            view.OnClick += OnRequested;

        }
    }

    private void OnRequested(IItem item)
    {
        UseRequested?.Invoke(this,item);
    }
}

