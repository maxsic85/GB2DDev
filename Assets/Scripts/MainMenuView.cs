using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonInventory;


    public void Init(UnityAction startGame, UnityAction showInventoryAction)
    {
        _buttonStart.onClick.AddListener(startGame);
        _buttonInventory.onClick.AddListener(showInventoryAction);
    }

    protected void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
    }
}