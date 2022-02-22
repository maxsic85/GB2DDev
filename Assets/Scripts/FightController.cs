using System;
using UnityEngine;

public class FightController : BaseController
{
    private readonly FightWindowView _view;
    private readonly ProfilePlayer _player;
    
    private Enemy _enemy;

    private Money _money;
    private Health _health;
    private Power _power;

    private UiListener _uiListener;


    public FightController(FightWindowView view, ProfilePlayer player)
    {
        _view = view;
        _player = player;
        CreatePaticipants();
        InitView();
    }

    private void InitView()
    {
        _view.Init(ChangeData, Fight);
        _uiListener = new UiListener(_view._countPowerText, _view._countMoneyText, _view._countHealthText);
        _money.Attach(_uiListener);
        _health.Attach(_uiListener);
        _power.Attach(_uiListener);
    }

    private void ChangeData(DataType type, int count)
    {
        switch (type)
        {
            case DataType.Money:
                _money.CountMoney += count;
                break;
            case DataType.Health:
                _health.CountHealth += count;
                break;
            case DataType.Power:
                _power.CountPower += count;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        _view._countPowerEnemyText.text = $"Enemy power: {_enemy.Power}";
    }

    private void CreatePaticipants()
    {
        _enemy = new Enemy("Flappy");

        _money = new Money(nameof(Money));
        _money.Attach(_enemy);

        _health = new Health(nameof(Health));
        _health.Attach(_enemy);

        _power = new Power(nameof(Power));
        _power.Attach(_enemy);
    }

    private void Fight()
    {
        Debug.Log(_power.CountPower >= _enemy.Power ? "Win" : "Lose");
    }


}