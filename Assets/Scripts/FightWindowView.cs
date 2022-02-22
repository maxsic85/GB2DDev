using UnityEngine;
using TMPro;
using UI;
using UnityEngine.Events;
using UnityEngine.UI;

public class FightWindowView : MonoBehaviour, IView
{
    [SerializeField]
    public TMP_Text _countMoneyText;

    [SerializeField]
    public TMP_Text _countHealthText;

    [SerializeField]
    public TMP_Text _countPowerText;

    [SerializeField]
    public TMP_Text _countPowerEnemyText;


    [SerializeField]
    private Button _addMoneyButton;

    [SerializeField]
    private Button _minusMoneyButton;


    [SerializeField]
    private Button _addHealthButton;

    [SerializeField]
    private Button _minusHealthButton;


    [SerializeField]
    private Button _addPowerButton;

    [SerializeField]
    private Button _minusPowerButton;

    [SerializeField]
    private Button _fightButton;

    public void Init(UnityAction<DataType, int> changeAction, UnityAction fight)
    {
        SubscribeButtons(changeAction, fight);
    }
    private void SubscribeButtons(UnityAction<DataType, int> changeAction, UnityAction fight)
    {
        _addMoneyButton.onClick.AddListener(() => changeAction(DataType.Money, 1));
        _minusMoneyButton.onClick.AddListener(() => changeAction(DataType.Money, -1));

        _addHealthButton.onClick.AddListener(() => changeAction(DataType.Health, 1));
        _minusHealthButton.onClick.AddListener(() => changeAction(DataType.Health, -1));

        _addPowerButton.onClick.AddListener(() => changeAction(DataType.Power, 1));
        _minusPowerButton.onClick.AddListener(() => changeAction(DataType.Power, -1));

        _fightButton.onClick.AddListener(fight);
    }

    private void OnDestroy()
    {
        UnsubscribeButtons();
    }

    private void UnsubscribeButtons()
    {
        _addMoneyButton.onClick.RemoveAllListeners();
        _minusMoneyButton.onClick.RemoveAllListeners();

        _addHealthButton.onClick.RemoveAllListeners();
        _minusHealthButton.onClick.RemoveAllListeners();

        _addPowerButton.onClick.RemoveAllListeners();
        _minusPowerButton.onClick.RemoveAllListeners();

        _fightButton.onClick.RemoveAllListeners();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}