using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonStartBattle;
    [SerializeField] private Button _buttonInventory;
    [SerializeField] private Button _buttonReward;
    [SerializeField] private Button _buttonExit;




    public void Init(UnityAction startGame, UnityAction startBattle , UnityAction showInventoryAction, UnityAction watchReward)
    {
        _buttonStart.onClick.AddListener(startGame);
        _buttonStartBattle.onClick.AddListener(startBattle);
        _buttonInventory.onClick.AddListener(showInventoryAction);
        _buttonReward.onClick.AddListener(watchReward);
        _buttonExit.onClick.AddListener(ExitGame);

    }

    private void ExitGame()
    {
        Application.Quit();
    }

    protected void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
    }
}