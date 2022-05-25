using Profile;
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

    public void UpdateViewMoney(DataPlayer dataPlayer)
    {
        StringBuilder sb = new StringBuilder();

        _moneyText.text = dataPlayer.Money.ToString();
        _speedText.text = dataPlayer.Health.ToString();
        _powerText.text = dataPlayer.Power.ToString();
        _banditryText.text = dataPlayer.Bandentry.ToString();

    }

    public void Init(ProfilePlayer dataPlayer)
    {
        UpdateViewMoney(dataPlayer.CurrenProfile.Value);
        dataPlayer.CurrenProfile.SubscribeOnChange(UpdateViewMoney);
    }

}
