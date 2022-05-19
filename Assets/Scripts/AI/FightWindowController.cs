using Profile;
using UnityEngine;

public class FightWindowController : BaseController
{
    private FightWindowView _fightWindow;
    private ProfilePlayer _profilePlayer;

    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;
    private int _allBanditizmoPlayer;

    private Money _money;
    private Health _heath;
    private Force _force;
    private Banditizm _banditizm;
    private Enemy _enemy;

    public FightWindowController(Transform transformForUI, FightWindowView fightWindow, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _fightWindow = GameObject.Instantiate(fightWindow, transformForUI);
    }
    public void RefreshView()
    {
        _enemy = new Enemy("Enemy Flappy");
        _money = new Money(nameof(Money));
        _money.Attach(_enemy);
        _heath = new Health(nameof(Health));
        _heath.Attach(_enemy);
        _force = new Force(nameof(Force));
        _force.Attach(_enemy);
        _banditizm = new Banditizm(nameof(Banditizm));
        _banditizm.Attach(_enemy);
        SubscribeButtons();
    }
    private void SubscribeButtons()
    {
        _fightWindow.AddCoinsButton.onClick.AddListener(() => ChangeMoney(true));
        _fightWindow.MinusCoinsButton.onClick.AddListener(() => ChangeMoney(false));
        _fightWindow.AddHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _fightWindow.MinusHealthButton.onClick.AddListener(() => ChangeHealth(false));
        _fightWindow.AddPowerButton.onClick.AddListener(() => ChangePower(true));
        _fightWindow.MinusPowerButton.onClick.AddListener(() =>ChangeBanditizm(false));
        _fightWindow.AddPBanditizmButton.onClick.AddListener(() => ChangeBanditizm(true));
        _fightWindow.MinusBanditizmButton.onClick.AddListener(() => ChangeBanditizm(false));
    
        _fightWindow.PassButton.onClick.AddListener(Pass);
        _fightWindow.FightButton.onClick.AddListener(Fight);
        _fightWindow.LeaveFightButton.onClick.AddListener(CloseWindow);
    }
    private void ChangeBanditizm(bool isAddCount)
    {
        if (isAddCount)
        {
            _allBanditizmoPlayer++;
            if (_allBanditizmoPlayer > 2) _fightWindow.ShowPassButton?.Invoke();
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
    private void Pass()
    {
        Debug.LogError("You Pass");
    }

    private void OnShowPassButton()
    {
        _fightWindow.PassButton.gameObject.SetActive(false);
    }
    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _fightWindow.CountMoneyText.text = $"Player Money {countChangeData.ToString()}";
                _money.Money = countChangeData;
                break;
            case DataType.Health:
                _fightWindow.CountHealthText.text = $"Player Health {countChangeData.ToString()}";
                _heath.Health = countChangeData;
                break;
            case DataType.Power:
                _fightWindow.CountPowerText.text = $"Player Power {countChangeData.ToString()}";
                _force.Power = countChangeData;
                break;
            case DataType.Banditizm:
                _fightWindow.CountBanditizmPlayerText.text = $"Player Banditizmo {countChangeData.ToString()}";
                _banditizm.Banditizm = countChangeData;
                break;
        }
        _fightWindow.CountPowerEnemyText.text = $"Enemy Power {_enemy.Power}";
    }

    private void CloseWindow()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }
    protected override void OnChildDispose()
    {
        _fightWindow.AddCoinsButton.onClick.RemoveAllListeners();
        _fightWindow.MinusCoinsButton.onClick.RemoveAllListeners();
        _fightWindow.AddHealthButton.onClick.RemoveAllListeners();
        _fightWindow.MinusHealthButton.onClick.RemoveAllListeners();
        _fightWindow.AddPowerButton.onClick.RemoveAllListeners();
        _fightWindow.MinusPowerButton.onClick.RemoveAllListeners();
        _fightWindow.FightButton.onClick.RemoveAllListeners();
        _fightWindow.AddPBanditizmButton.onClick.RemoveAllListeners();
        _fightWindow.MinusBanditizmButton.onClick.RemoveAllListeners();
        _money.Detach(_enemy);
        _heath.Detach(_enemy);
        _force.Detach(_enemy);
        _banditizm.Detach(_enemy);
        base.OnChildDispose();
    }
}

