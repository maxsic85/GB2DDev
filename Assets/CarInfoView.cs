using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarInfoView : MonoBehaviour
{
    [SerializeField] private Text _moneyText;

    public Text MoneyText { get => _moneyText; set => _moneyText = value; }

    public void UpdateView(float money)
    {
        _moneyText.text = money.ToString();
       
    }

    public void Init(Profile.ProfilePlayer dataPlayer)
    {
        UpdateView(dataPlayer.CurrenMoney.Value);
        dataPlayer.CurrenMoney.SubscribeOnChange(UpdateView);
    }
}
