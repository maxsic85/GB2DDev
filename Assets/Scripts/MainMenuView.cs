using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour, IView
{
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonRewards;
    [SerializeField] private Button _buttonExit;

    public void Init(UnityAction startGame, UnityAction openRewards)
    {
        _buttonStart.onClick.AddListener(startGame);
        _buttonRewards.onClick.AddListener(openRewards);
    }

    protected void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
        _buttonRewards.onClick.RemoveAllListeners();
    }

    public void Show()
    {
        
    }

    public void Hide()
    {
        
    }
}