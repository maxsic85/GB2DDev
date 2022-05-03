using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MainWindowObserver : MonoBehaviour
{
    public Action ShowPassButton;

    [SerializeField]
    private TMP_Text _countMoneyText;
    [SerializeField]
    private TMP_Text _countHealthText;
    [SerializeField]
    private TMP_Text _countPowerText;
    [SerializeField]
    private TMP_Text _countPowerEnemyText;
    [SerializeField]
    private TMP_Text _banditizmPlayerText;
    [SerializeField]
    private Button _addCoinsButton;
    [SerializeField]
    private Button _minusCoinsButton;
    [SerializeField]
    private Button _addHealthButton;
    [SerializeField]
    private Button _minusHealthButton;
    [SerializeField]
    private Button _addPowerButton;
    [SerializeField]
    private Button _minusPowerButton;


    [SerializeField]
    private Button _addPBanditizmButton;
    [SerializeField]
    private Button _minusBanditizmButton;

    [SerializeField]
    private Button _fightButton;
    [SerializeField]
    private Button _passButton;
    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;
    private int _allBanditizmoPlayer;

    private Money _money;
    private Health _heath;
    private Power _power;
    private Banditizm _banditizm;
    private Enemy _enemy;
    private void Start()
    {
        _enemy = new Enemy("Enemy Flappy");
        _money = new Money(nameof(Money));
        _money.Attach(_enemy);
        _heath = new Health(nameof(Health));
        _heath.Attach(_enemy);
        _power = new Power(nameof(Power));
        _power.Attach(_enemy);
        _banditizm = new Banditizm(nameof(Banditizm));
        _banditizm.Attach(_enemy);

        _addCoinsButton.onClick.AddListener(() => ChangeMoney(true));
        _minusCoinsButton.onClick.AddListener(() => ChangeMoney(false));
        _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));
        _addPowerButton.onClick.AddListener(() => ChangePower(true));
        _minusPowerButton.onClick.AddListener(() => ChangePower(false));
        _addPBanditizmButton.onClick.AddListener(() => ChangeBanditizm(true));
        _minusBanditizmButton.onClick.AddListener(() => ChangeBanditizm(false));
        _fightButton.onClick.AddListener(Fight);
        _passButton.onClick.AddListener(Pass);
        _passButton.gameObject.SetActive(true);
        ShowPassButton += OnShowPassButton;
    }

    private void Pass()
    {
        Debug.LogError("You Pass");
    }

    private void OnShowPassButton()
    {
        _passButton.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _addCoinsButton.onClick.RemoveAllListeners();
        _minusCoinsButton.onClick.RemoveAllListeners();
        _addHealthButton.onClick.RemoveAllListeners();
        _minusHealthButton.onClick.RemoveAllListeners();
        _addPowerButton.onClick.RemoveAllListeners();
        _minusPowerButton.onClick.RemoveAllListeners();
        _fightButton.onClick.RemoveAllListeners();
        _addPBanditizmButton.onClick.RemoveAllListeners();
        _minusBanditizmButton.onClick.RemoveAllListeners();
        _money.Detach(_enemy);
        _heath.Detach(_enemy);
        _power.Detach(_enemy);
        _banditizm.Detach(_enemy);

    }
    private void ChangeBanditizm(bool isAddCount)
    {
        if (isAddCount)
        {
            _allBanditizmoPlayer++;
            if (_allBanditizmoPlayer > 2) ShowPassButton?.Invoke();
        }
        else
        { 
            _allBanditizmoPlayer--;
        }
        ChangeDataWindow(_allBanditizmoPlayer, DataType.Banditizm);
    }
    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
            _allCountMoneyPlayer++;
        else
            _allCountMoneyPlayer--;
        ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
    }
    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
            _allCountHealthPlayer++;
        else
            _allCountHealthPlayer--;
        ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
    }
    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
            _allCountPowerPlayer++;
        else
            _allCountPowerPlayer--;
        ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
    }
    private void Fight()
    {
        Debug.Log(_allCountPowerPlayer >= _enemy.Power
        ? "<color=#07FF00>Win!!!</color>"
        : "<color=#FF0000>Lose!!!</color>");
    }
    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _countMoneyText.text = $"Player Money {countChangeData.ToString()}";
                _money.Money = countChangeData;
                break;
            case DataType.Health:
                _countHealthText.text = $"Player Health {countChangeData.ToString()}";
                _heath.Health = countChangeData;
                break;
            case DataType.Power:
                _countPowerText.text = $"Player Power {countChangeData.ToString()}";
                _power.Power = countChangeData;
                break;
            case DataType.Banditizm:
                _banditizmPlayerText.text = $"Player Banditizmo {countChangeData.ToString()}";
                _banditizm.Banditizm = countChangeData;
                break;
        }
        _countPowerEnemyText.text = $"Enemy Power {_enemy.Power}";
    } 
}