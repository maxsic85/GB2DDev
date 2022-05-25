using Profile;
using System;
using System.Text;
using TMPro;
using UnityEngine;

public class CarInfoView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _speedText;
    [SerializeField] private TextMeshProUGUI _powerText;
    [SerializeField] private TextMeshProUGUI _banditryText;


    public TextMeshProUGUI MoneyText { get => _moneyText; set => _moneyText = value; }
    public TextMeshProUGUI SpeedText { get => _speedText; set => _speedText = value; }
    public TextMeshProUGUI PowerText { get => _powerText; set => _powerText = value; }
    public TextMeshProUGUI BanditryText { get => _banditryText; set => _banditryText = value; }


    public void Init(ProfilePlayer dataPlayer)
    {
        UpdateViewMoney(dataPlayer.CurrenMoney.Value);
        dataPlayer.CurrenMoney.SubscribeOnChange(UpdateViewMoney);

        UpdateViewHealth(dataPlayer.CurrenHealth.Value);
        dataPlayer.CurrenHealth.SubscribeOnChange(UpdateViewHealth);

        UpdateViewPower(dataPlayer.CurrenPower.Value);
        dataPlayer.CurrenPower.SubscribeOnChange(UpdateViewPower);

        UpdateViewBandetry(dataPlayer.CurrenBandetry.Value);
        dataPlayer.CurrenBandetry.SubscribeOnChange(UpdateViewBandetry);
    }
    public void UpdateViewMoney(int money)
    {
        StringBuilder sb = new StringBuilder();

        _moneyText.text = money.ToString();

    }

    private void UpdateViewBandetry(int value)
    {
        _banditryText.text = value.ToString();
    }

    private void UpdateViewPower(int value)
    {
        _powerText.text = value.ToString();
    }

    private void UpdateViewHealth(int value)
    {
        _speedText.text = value.ToString();
    }
}
